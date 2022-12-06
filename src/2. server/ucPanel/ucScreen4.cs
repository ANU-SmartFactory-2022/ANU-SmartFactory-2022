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
    public partial class ucScreen4 : UserControl
    {
        public ucScreen4()
        {
            InitializeComponent();
        }

		private void ucScreen4_Load(object sender, EventArgs e)
		{
           
        }

		private void button1_Click(object sender, EventArgs e)
		{
            chart1.Series[0].Points.AddXY("승호짱이", 45);
        }

		private void button2_Click(object sender, EventArgs e)
		{
            chart1.Series[0].Points.AddXY("이해한", 70);
        }

		private void button3_Click(object sender, EventArgs e)
		{
            chart1.Series[0].Points.AddXY("그대로", 90);
        }

		private void button4_Click(object sender, EventArgs e)
		{
            chart1.Series[0].Points.AddXY("만들어봄", 14);
        }
	}
}
