using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4.ucPanel
{
    public partial class ucScreen1 : UserControl
    {
        public ucScreen1()
        {
            InitializeComponent();
        }

		private void btn_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			DialogResult result= MessageBox.Show("해당 공정에 문제가 발생하였습니다. 조치 하시겠습니다?", "공정 오류", MessageBoxButtons.YesNo);
			picBoxColor(27, "ON");  //테스트용
			if (result == DialogResult.Yes)
			{
				btn.BackColor= SystemColors.Window;
			}

		}	
		
		//문제가 생긴 공정 버튼을 빨간색으로 표시하는 코드
        public void buttonColor(int _inch, int _proc, Color _clr )
		{
			var panel_list = Controls
				.OfType<Panel>();

			foreach (var panel in panel_list)
			{
				try
				{
					var b = panel.Controls
										.OfType<Button>()
										.Where(btn => btn.Name == "btn_" + _inch.ToString() + "_" + _proc.ToString() )
										.First();

					b.BackColor = _clr;
				}
				catch( Exception ex )
				{

				}
			}
		}
		// 모니터 이동 중 화살표 색상 변경
		public void picBoxColor(int _inch , string state)
		{
			try
			{
				var picBox = Controls
					.OfType<PictureBox>()
					.Where(pib => pib.Name == "pib_" + _inch.ToString())
					.First();
				if(state == "OFF")
                {
					picBox.Visible = false;
				}
				else 
                {
					Image img = (Image)Properties.Resources.ResourceManager.GetObject(picBox.Name + state, Properties.Resources.Culture);
					picBox.Image = img;
					picBox.Visible = true;
				}
			}
			catch (Exception ex)
			{
				
			}
		}
		
		public void picBoxColor2(string _num, string state)
		{
			try
			{
				var picBox1 = Controls
					.OfType<PictureBox>()
					.Where(pib => pib.Name == "pib_" + _num.ToString())
					.First();
				if (state == "OFF")
				{
					picBox1.Visible = false;
				}
				else
				{
					string image = "";
					if ( _num  == "1")
                    {
						image = "pib_32" + state;

					}
					else if ( _num == "2")
                    {
						image = "pib_27" + state;
					}
					else
                    {
						image = "pib_24" + state;
					}
					Image img = (Image)Properties.Resources.ResourceManager.GetObject(image, Properties.Resources.Culture);
					picBox1.Image = img;
					picBox1.Visible = true;
				}
			}
			catch (Exception ex)
			{

			}
		}
		public void Colorred()
        {
			panel7.BackColor = Color.Red;
        }
        private void ucScreen1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
			
		}

        private void panel7_Paint_1(object sender, PaintEventArgs e)
        {
			
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
			
		}

        private void ucScreen1_Load_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
