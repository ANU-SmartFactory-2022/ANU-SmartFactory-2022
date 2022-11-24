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
        ucPanel.ucScreen1 ucSc1 = new ucPanel.ucScreen1();
        ucPanel.ucScreen2 ucSc2 = new ucPanel.ucScreen2 ();
        ucPanel.ucScreen3 ucSc3 = new ucPanel.ucScreen3 ();
        ucPanel.ucScreen4 ucSc4 = new ucPanel.ucScreen4 ();
        ucPanel.ucScreenHome ucScHome = new ucPanel.ucScreenHome();

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
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            btn_list.Add(btn_monitoring);
            btn_list.Add(btn_running);
            btn_list.Add(btn_summary);
            btn_list.Add(btn_detail);
            btn_list.Add(btn_home);
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
        }
       
        private void recv_callback(string _msg)
        {
            checkmsg(_msg);
        }

        delegate void StringArgReturningVoidDelegate(string _msg);
        private void checkmsg(string _msg)
        {
            string[] TCPmsg = _msg.Split(',');
            string P_NUM = "";
            switch (TCPmsg[0])
            {
                case "QR_READING":
                    // DB 조회 및 인치값 발사하기
                    P_NUM = TCPmsg[1];
                    cmd.CommandText = $"select PINCH from PRD WHERE PPdNumber = '{P_NUM}' ";
                    rdr = cmd.ExecuteReader();
                    string inch = "";
                    while (rdr.Read())
                    {
                        inch = rdr["PINCH"].ToString();
                    }
                    m_server?.send("REQUEST_RESULT," + inch);
                    break;
                case "FRACTIONATION_RESULT":
                    //오라클 정리 DB축적
                    string ru = "";
                    if(TCPmsg[1] == "1")
                    {
                        ru = "데드";
                    }
                    else if(TCPmsg[1] == "2")
                    {
                        ru = "정상";
                    }
                    else if(TCPmsg[1] == "3")
                    {
                        ru = "핫";
                    }
                    else if(TCPmsg[1] == "4")
                    {
                        ru = "스턱";
                    }
                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    cmd.CommandText = $"INSERT INTO TABLE PRM VALUES('{date}','담장자','사원번호','{ru}')";
                    cmd.ExecuteNonQuery();
                    m_server?.send("ROLLING");
                    break;
                case "ROLLING_END":
                    cmd.CommandText = "SELECT CUME_DIST() OVER(ORDER BY PRResult) AS ResultSUM FROM PRM WHERE != '정상' ";
                    rdr = cmd.ExecuteReader();
                    double num = 0.0;
                    while (rdr.Read())
                    {
                        num = Convert.ToDouble(rdr["ResultSUM"]);
                        if(num >= 0.05 && rdr["PRResult"].ToString() != "정상")
                        {
                            string Result1 = rdr["PRResult"].ToString();
                            if (Result1 == "핫")
                            {
                                //닫는 함수
                            }
                            else if (Result1 == "스턱")
                            {
                                //닫는 함수
                            }
                            else if (Result1 == "데드")
                            {
                                //닫는 함수
                            }
                        }
                    }
                    break;
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
                        ucSc1.buttonColor( 32, 2, Color.Red ); //ucScreen1 문제생긴 공정에 빨간색 들어오게 하기
                    }
                    break;
                case "공정 가동": panel_main.Controls.Add(ucSc2); break;
                case "통계": panel_main.Controls.Add(ucSc3); break;
                case "불량품 상세정보": panel_main.Controls.Add(ucSc4); break;
                case "모니터 공정": panel_main.Controls.Add(ucScHome); break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // message box
        }


        // 종료 x 버튼 
        private void button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        // Form을 마우스로 이동하는 소스
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

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = true;
            MValX = e.X;
            MValY = e.Y;
        }
    }
}

