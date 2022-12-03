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

        public string CreateName(string inch ,string panel, string hz, string num)
        {
            string code = inch[0] + "I" + panel[0] + "P" + hz[0] + "H" + DateTime.Now.ToString("dd - MM - yy") + num;
            return code;
        }
        private void ucScreen2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Program.f_function.select_ORD("");
        }

        public void GridAdd(string inch, string panel ,string hz)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[1].Value.ToString() == inch && row.Cells[2].Value.ToString() == panel && row.Cells[3].Value.ToString() == hz)
                    {
                        row.Cells[4].Value = Int32.Parse(row.Cells[4].Value.ToString()) + 1;
                    }
                }
                catch (Exception ex)
                {


                }

            }
        }
    }
}
