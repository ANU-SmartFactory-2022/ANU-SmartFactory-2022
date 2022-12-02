using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    internal class Function
    {
        OracleConnection conn;
        OracleCommand cmd;
        OracleDataReader rdr;
        string strconn = "data source=(description=" +
               "(address_list=(address=(protocol=tcp)" +
               "(host=localhost)(port=1521)))" +
               "(connect_data=(server=dedicated)" +
               "(service_name=xe)));" +
               "user id=hr;password=hr;";
        public void connect()
        {
            conn = new OracleConnection(strconn);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;

        }
        public DataTable select_ORD(string _ORDN = "")
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("주문번호", typeof(string));
            dataTable.Columns.Add("사이즈", typeof(string));
            dataTable.Columns.Add("패널", typeof(string));
            dataTable.Columns.Add("주사율", typeof(string));
            dataTable.Columns.Add("주문수량", typeof(string));

            cmd.CommandText = $"select * from ORD";
            if (_ORDN != "")
            {
                cmd.CommandText += $" where  = '{_ORDN}'";
            }

            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string ordn = rdr["ORDN"].ToString();
                string oinch = rdr["OINCH"].ToString();
                string orfh = rdr["ORFH"].ToString();
                string opn = rdr["OPN"].ToString();
                string onum = rdr["ONUM"].ToString();

                dataTable.Rows.Add(ordn, oinch, orfh, opn, onum);

            }




            return dataTable;
        }
    }
}
