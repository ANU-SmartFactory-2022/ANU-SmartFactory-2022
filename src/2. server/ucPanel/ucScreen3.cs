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

		

		private void ucScreen3_Load(object sender, EventArgs e)
		{
			circularProgressBar1.Value = 0;
			circularProgressBar1.Minimum = 0;
			circularProgressBar1.Maximum = 100;

			circularProgressBar2.Value = 0;
			circularProgressBar2.Minimum = 0;
			circularProgressBar2.Maximum = 100;

			comboBox1.SelectedIndex = 0;
			comboBox2.SelectedIndex = 0;
			comboBox3.SelectedIndex = 0;

		}

		private void button1_Click(object sender, EventArgs e)
		{
			for (int i = 1; i <= 50; i++)
			{
				circularProgressBar1.Value = i;
				circularProgressBar1.Update();
			}

			for (int j = 1; j <= 70; j++)
			{
				circularProgressBar2.Value = j;
				circularProgressBar2.Update();
			}

			string str_inch = comboBox1.SelectedItem.ToString();
			string str_panel = comboBox2.SelectedItem.ToString();
			string str_hz = comboBox3.SelectedItem.ToString();

			DataTable dt = Program.f_function.select_PRD(str_inch, str_panel, str_hz);
			dataGridView1.DataSource = dt;
		}
	}
}
