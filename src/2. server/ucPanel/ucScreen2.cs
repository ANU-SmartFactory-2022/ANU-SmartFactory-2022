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
            DataTable table = new DataTable();

            table.Columns.Add("주문번호", typeof(string));
            table.Columns.Add("사이즈", typeof(string));
            table.Columns.Add("패널", typeof(string));
            table.Columns.Add("주사율", typeof(string));
            table.Columns.Add("주문수량", typeof(string));
            table.Columns.Add("완료수량", typeof(string));

            table.Rows.Add("1", "24 inch", "TV패널", "60hz", "3", "1");
            table.Rows.Add("1", "24 inch", "TV패널", "60hz", "3", "1");

             dataGridView1.DataSource = table;
        }
	}
}
