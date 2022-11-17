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
	}
}
