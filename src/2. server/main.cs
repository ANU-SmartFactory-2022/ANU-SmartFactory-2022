using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Oracle.ManagedDataAccess.Client;
using TCPIP_Sample_CSharp;

namespace WindowsFormsApp4
{
    //패널 객체 생성, 메인창 선택 버튼 옆 작은 선택 패널 옮기기
    public partial class main : Form
    {
        public ucPanel.ucScreen1 ucSc1;
        public ucPanel.ucScreen2 ucSc2;
        public ucPanel.ucScreen3 ucSc3;
        public ucPanel.ucScreen4 ucSc4;
        public ucPanel.ucScreenHome ucScHome;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn

    (
     int nLeftRect,
     int nTopRect,
     int nRightRect,
     int nBottomRect,
     int nWidthEllipse,
     int nHeightEllipse
    );
        List<Button> btn_list = new List<Button>();

        //오라클 통신위한 객체 지정 및 설정
        OracleCommand cmd = new OracleCommand();
        OracleDataReader rdr;
        OracleConnection conn = new OracleConnection(strConn);
        static string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=hr ;Password=hr;";
        OracleDataAdapter adapt = new OracleDataAdapter();

        //서버 클라이언트 설정을 위한 객체 설정
        socket_server m_server = null;
        

        public main()
        {
            InitializeComponent();

            ucSc1 = new ucPanel.ucScreen1();
            ucSc2 = new ucPanel.ucScreen2(this);
            ucSc3 = new ucPanel.ucScreen3();
            ucSc4 = new ucPanel.ucScreen4();
            ucScHome = new ucPanel.ucScreenHome();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            btn_list.Add(btn_monitoring);
            btn_list.Add(btn_running);
            btn_list.Add(btn_summary);
            btn_list.Add(btn_detail);
            btn_list.Add(btn_home);
            btn_list.Add(btn_logout);
        }

        public string login_Number;
        public string login_Name;

        private void Form1_Load(object sender, EventArgs e)
        {
            //test---
            conn.Open();
            cmd.Connection = conn;
            m_server = new socket_server(recv_callback);
            m_server.start();
            label2.Text = login_Number;
            label3.Text = login_Name;

            button_click( btn_home, e );
        }
       
        private void recv_callback(string _msg)
        {
            if(_msg == "Accept Client")
            {
                m_server?.send("START");
            }
            else
            {
                checkmsg(_msg);
            }
        }

        delegate void StringArgReturningVoidDelegate(string _msg);
        private void checkmsg(string _msg)
        {
            string[] TCPmsg = _msg.Split(',');
            string P_NUM = "";
            string P_inch = "";
            string NOWINCH = "";
            string NOWPANEL = "";
            string NOWHZ = "";
            switch (TCPmsg[0])
            {
                case "QR_READING":
                    // DB 조회 및 인치값 발사하기
                    P_NUM = TCPmsg[1];
                    string[] RESULTP = selectCommand( "PRD", P_NUM).Split(',');
                    m_server?.send("REQUEST_RESULT," + RESULTP[0]);
                    break;
                case "RESULT":
                    //오라클 정리 DB축적
                    string RESULT = RESULTCH(TCPmsg[2]);
                    string[] RESULTARRAY = new string[4];
                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    RESULTARRAY[0] = date;
                    RESULTARRAY[1] = TCPmsg[1];
                    RESULTARRAY[2] = login_Number;
                    RESULTARRAY[3] = RESULT;
                    Program.f_function.INSERTCommand(RESULTARRAY, "PRM");
                    P_NUM = TCPmsg[1];
                    string[] RESULTP1 = selectCommand("PRD", P_NUM).Split(',');
                    NOWINCH = RESULTP1[0];
                    NOWPANEL = RESULTP1[1];
                    NOWHZ = RESULTP1[2];
                    m_server?.send("DB_END");
                    ucSc1.picBoxColor2(TCPmsg[2], "ON");
                    break;
                case "STUCK":
                    ucSc1.Colorred();
                    break;
                case "ROLLING_END":
                    FINDERROR(P_inch);
                    ucSc2.GridAdd(NOWINCH,NOWPANEL,NOWHZ);
                    break;
            }
        }

        //값 변환 함수 들어온 숫자에 따라 결과로 변환
        public string RESULTCH(string RESULT)
        {
            string ru = "";
            if (RESULT == "1")
            {
                ru = "데드";
            }
            else if (RESULT == "2")
            {
                ru = "정상";
            }
            else if (RESULT == "3")
            {
                ru = "핫";
            }
            else if (RESULT == "4")
            {
                ru = "스턱";
            }
            return ru;
        }
        // 제품의 정보를 을 도출하기 위한 함수, split 0 인치 1패널 2 hz
        public string selectCommand( string table , string result)
        {
            cmd.CommandText = $"select * from {table} WHERE PPdNumber = '{result}' ";
            rdr = cmd.ExecuteReader();
            string inch = "";
            string panel = "";
            string hz = "";
            while (rdr.Read())
            {
                inch = rdr["PINCH"].ToString();
                panel = rdr["PPn"].ToString();
                hz = rdr["PRfh"].ToString();
            }
            return inch +","+ panel+ "," + hz;
        }
        // 결과값을 확인 후 에러창을 띄위기 위한 함수 
        public void FINDERROR(string inch)
        {
            cmd.CommandText = $"SELECT  PRResult, PINCH,COUNT(*) cnt , RATIO_TO_REPORT(COUNT(*)) OVER() rat FROM PRD INNER JOIN PRM ON PRD.PPdNumber = PRM.PRPdNumber Where PINCH = '{inch}' and PRResult != 4 GROUP BY PRResult,PINCH";
            rdr = cmd.ExecuteReader();
            double num = 0.0;
            while (rdr.Read())
            {
                num = Convert.ToDouble(rdr["RAT"]);
                if (num >= 0.10)
                {
                    string Result1 = rdr["PRResult"].ToString();
                    if (Result1 == "핫")
                    {
                        ucSc1.buttonColor(Int32.Parse(inch), 1, Color.Red, ucSc1);
                    }
                    else if (Result1 == "스턱")
                    {
                        ucSc1.buttonColor(Int32.Parse(inch), 2, Color.Red, ucSc1);
                    }
                    else if (Result1 == "데드")
                    {
                        ucSc1.buttonColor(Int32.Parse(inch), 3, Color.Red, ucSc1);
                    }
                }
            }
        }
        private void button_click( object sender, EventArgs e )
        {
            Button btn = (Button)sender;
            PnlNav.Height = btn.Height;
            PnlNav.Top = btn.Top;
            PnlNav.Left = btn.Left;

            
            foreach( var item in btn_list )
			{
                item.BackColor = Color.FromArgb(24, 30, 54);
            }
            btn.BackColor = Color.FromArgb(46, 51, 73);


            panel_main.Controls.Clear();
            switch (btn.Text)
            {
                case "모니터링":
                    {
                        panel_main.Controls.Add(ucSc1);
                        this.Invalidate();
                        this.Update();
                        this.Refresh();
                    }
                    break;
                case "공정 가동": panel_main.Controls.Add(ucSc2);                
                    break;
                case "통계": panel_main.Controls.Add(ucSc3);
                    break;
                case "불량품 상세정보": panel_main.Controls.Add(ucSc4);
                    break;
                case "모니터 공정": panel_main.Controls.Add(ucScHome);
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ucSc2.factoryoperation(ucSc1);
            ucSc1.Invalidate();
            ucSc2.Invalidate();
            // message box
        }
        public void doit()
        {
            ucSc2.factoryoperation(ucSc1);
            ucSc1.Invalidate();
            ucSc2.Invalidate();
        }
        // 종료 x 버튼 
        private void button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        // Form을 마우스로 이동하는 소
        bool TagMove;
        int MValX, MValY;

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (TagMove == true)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            TagMove = false;
        }

        private void panel_main_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel_title_Paint(object sender, PaintEventArgs e)
        {

        }

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void btn_stop_Click(object sender, EventArgs e)
		{
            Button btn = (Button)sender;
            DialogResult result = MessageBox.Show("공정을 멈추시겠습니까?", "라인 긴급 중지", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

		private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = true;
            MValX = e.X;
            MValY = e.Y;
        }

    }
}

