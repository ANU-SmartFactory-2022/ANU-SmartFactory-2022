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
    public partial class ucScreen2 : UserControl
    {
        public ucScreen2()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
            
        }

		private void Lookup_Btn_Click(object sender, EventArgs e)
		{
            
        }

        private void ucScreen2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Program.f_function.select_ORD("");
        }
    }
}
