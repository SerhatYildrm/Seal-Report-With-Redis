using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Seal.Model
{
    public class MSSql
    {

        public string sql = "";
        public string connectionString = "";
        public MSSql(string sql, string connectionString)
        {
            this.sql = sql;
            this.connectionString = connectionString;
        }
        
        public List<string> Connection()
        {

            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataAdapter DA = new OleDbDataAdapter(command);


            System.Data.DataSet ds = new System.Data.DataSet();
            DA.Fill(ds);

            command.Dispose();
            connection.Close();

            string ColumnName = "";
            string RowValue = "";
            string strjson = "";

            List<string> SecondData = new List<string>();
            

            for (int rowindex = 0; rowindex < ds.Tables[0].Rows.Count; rowindex++)
            {
                strjson = "{";
                for (int columnindex = 0;columnindex< ds.Tables[0].Columns.Count; columnindex++)
                {
                    ColumnName = ds.Tables[0].Columns[columnindex].ColumnName;
                    RowValue = ds.Tables[0].Rows[rowindex].ItemArray[columnindex].ToString();

                    strjson += "'" + ColumnName + "':'" + RowValue + "',";

                }
                strjson += "}";
                SecondData.Add(strjson);
            }



            return SecondData;

            
        }

    }
}
