using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Model
{
    public class MSSql
    {

        public static String Connection()
        {
            string connectionString = @"Provider=SQLOLEDB.1;Persist Security Info=True;Data Source=192.168.2.10\sahinlogo;Initial Catalog=LOGO;User Id=seal;Password=54605460;";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();



            string sql = "SELECT @@VERSION";
            OleDbCommand command = new OleDbCommand(sql, connection);
            string dwh = Convert.ToString(command.ExecuteScalar());

            

            command.Dispose();
            connection.Close();

            return dwh;
        }

    }
}
