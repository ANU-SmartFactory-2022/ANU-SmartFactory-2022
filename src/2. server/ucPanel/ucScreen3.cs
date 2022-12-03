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
			
			comboBox1.SelectedIndex = 0;
			comboBox2.SelectedIndex = 0;
			comboBox3.SelectedIndex = 0;

			
			chart1.Series[0].Points.AddXY("정상", 45);
			chart1.Series[0].Points.AddXY("비정상", 50);

			chart3.Series[0].Points.AddXY("핫픽셀",45);
			chart3.Series[0].Points.AddXY("데드픽셀", 45);
			chart3.Series[0].Points.AddXY("스턱픽셀", 45);




		}

		private void button1_Click(object sender, EventArgs e)
		{
	

			string str_inch = comboBox1.SelectedItem.ToString();
			string str_panel = comboBox2.SelectedItem.ToString();
			string str_hz = comboBox3.SelectedItem.ToString();

			DataTable dt = Program.f_function.select_PRD(str_inch, str_panel, str_hz);
			dataGridView1.DataSource = dt;
		}

		
	}
}
