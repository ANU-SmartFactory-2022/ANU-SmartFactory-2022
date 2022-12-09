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
        ucScreen4 ucScreenl;
        public ucScreen4()
        {
            InitializeComponent();
        }
        public ucScreen4(object mainForm)
        {
            InitializeComponent();
            ucScreenl = ((main)mainForm).ucSc4;
        }
        private void ucScreen4_Load(object sender, EventArgs e)
		{
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GridChnage(ucScreenl);
        }
        public void GridChnage(ucScreen4 ucScreenl)
        {
            DataSet ds = Program.f_function.dataColumn("2", "3", "4", ucScreenl);
            ucScreenl.dataGridView2.DataSource = ds.Tables[0].DefaultView;
            ucScreenl.dataGridView2.Update();
        }
    }
}
