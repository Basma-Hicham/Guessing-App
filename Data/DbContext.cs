using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows;
namespace guessing_app.Data
{ // where the db connection is made
    // its deriven in dbservice where queries excuted
    public class DbContext
    {
       
       private readonly string connString= "Server=localhost;Database=GuessingApp;User Id=student;Password=19112001;Encrypt=False;";

        public DbContext(string _connStr)
        {
            this.connString = _connStr;
        }
        //DRY applying
        public SqlConnection sqlConn()
        {
            return new SqlConnection(connString);
        }
//        public void TestConnection()
//        {
//            using (SqlConnection conn = sqlConn()) 
//            {
//                conn.Open();
//            }
//}

    }
}
