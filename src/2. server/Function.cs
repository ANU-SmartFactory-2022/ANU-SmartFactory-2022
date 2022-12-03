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
            dataTable.Columns.Add("완료수량", typeof(string));

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
        public DataTable select_PRD(string str_inch, string str_panel, string str_hz)
        {
            string query = "SELECT * FROM PRD ";
            List< string > where_item = new List<string>();
            
            if (str_inch != "전체")
            {
                where_item.Add("PINCH = '" + str_inch + "'");
            }
            if (str_panel != "전체")
            {
                where_item.Add("PPN = '" + str_panel + "'");
            }
            if (str_hz != "전체")
            {
                where_item.Add("PRFH = '" + str_hz + "'");
            }

            int where_item_cnt = where_item.Count();
            if (where_item_cnt > 0)
            {
                query += "where ";
                for ( int i = 0; i < where_item_cnt; i++)
                {
                    query += where_item[i];
                    if( i < where_item_cnt - 1)
                    {
                        query += " AND ";
                    }
                }
            }
            
            DataTable dt = new DataTable();
            dt.Columns.Add("사이즈", typeof(string));
            dt.Columns.Add("패널", typeof(string));
            dt.Columns.Add("주사율", typeof(string));
            cmd.CommandText = query;
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                string pinch = rdr["PINCH"].ToString();
                string ppn = rdr["PPN"].ToString();
                string prfh = rdr["PRFH"].ToString();

                dt.Rows.Add(pinch, ppn, prfh);
            }
            return dt;
        }

        // 오라클 데이터 삽입을 위한 함수s
        public void INSERTCommand(string[] Speci, string tname)
        {
            string commad = $"INSERT INTO {tname} VALUES (";
            for (int i = 0; i < Speci.Length; i++)
            {
                if (i != Speci.Length - 1)
                {
                    commad += $"'{Speci[i]}',";
                }
                else
                {
                    commad += $"'{Speci[i]}'";
                }
            }
            commad += ")";
            cmd.CommandText = commad;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Commit";
            cmd.ExecuteNonQuery();
        }

    }
}
