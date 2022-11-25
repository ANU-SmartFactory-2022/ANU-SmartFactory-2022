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
            
            MessageBox.Show("해당 공정에 문제가 발생하였습니다. 조치 하시겠습니다?", "공정 오류", MessageBoxButtons.YesNo);
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
    }
}
