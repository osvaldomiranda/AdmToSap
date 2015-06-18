using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace AdmToSap
{
    class ConvertAdmSap
    {
        String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";

        public int typeDocument(int type)
        {
            int dbtype = 0;
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            String sql1 = "SELECT * FROM documento where tipodteadm = " + type;
            SQLiteCommand command = new SQLiteCommand(sql1, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dbtype = reader.GetOrdinal("tiposap");
            }

            myConn.Close();
            return dbtype;
        }

        public string codBodega(string codbod)
        {
            string dbcod = "";
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            String sql1 = "SELECT * FROM bodegas where codbodegaadm = " + codbod;
            SQLiteCommand command = new SQLiteCommand(sql1, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dbcod = reader.GetString(reader.GetOrdinal("codbodegasap"));
            }
            myConn.Close();
            return dbcod;
        }
    }
}
