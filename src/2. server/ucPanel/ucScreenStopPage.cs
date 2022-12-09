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
	public partial class ucScreenStopPage : UserControl
	{
		ucScreen1 ucsrennl;
		main main;
		bool state;
		public ucScreenStopPage()
		{
			InitializeComponent();
		}
		public ucScreenStopPage(object mainForm)
		{
			InitializeComponent();
			ucsrennl = ((main)mainForm).ucSc1;
			main = (main)mainForm;
		}
		private void ucScreenStopPage_Load(object sender, EventArgs e)
		{

		}

        private void button1_Click(object sender, EventArgs e)
        {
			main.allstop(main.stop, ucsrennl);
        }
    }
}
