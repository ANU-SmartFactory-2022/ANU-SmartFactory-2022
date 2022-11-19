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

namespace WindowsFormsApp4
{
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //test---
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
                case "모니터링": panel_main.Controls.Add(ucSc1); break;
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

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = true;
            MValX = e.X;
            MValY = e.Y;
        }
    }
}

