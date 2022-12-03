using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4.ucPanel
{
    public partial class ucScreen3 : UserControl
    {
        public ucScreen3()
        {
            InitializeComponent();
        }

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			for (int i = 1; i <= 50; i++)
			{
				circularProgressBar1.Value = i;
				circularProgressBar1.Update();
			}
		}

		private void ucScreen3_Load(object sender, EventArgs e)
		{
			circularProgressBar1.Value = 0;
			circularProgressBar1.Minimum = 0;
			circularProgressBar1.Maximum = 100;
		}
	}
}
