using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AdmToSap
{
    class ConnectDb
    {     
  
        public OdbcConnection getConnect()
        {
            String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";
            String server = "";
            String database = "";
            String user = "";
            String pass = "";

            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            string sql = "SELECT * FROM connectdb";
            SQLiteCommand command = new SQLiteCommand(sql, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                server = reader["server"].ToString();
                database = reader["database"].ToString();
                user = reader["user"].ToString();
                pass = reader["pass"].ToString();
            }

            myConn.Close();

            String stringConn = "DRIVER={MySQL ODBC 3.51 Driver}; SERVER="+server+"; PORT=3306; DATABASE="+database+"; USER="+user+"; PASSWORD="+pass+"; OPTION=0;";
            OdbcConnection conn = new OdbcConnection(stringConn);
            try
            {
                conn.Open();
                Console.WriteLine("Conección OK");
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Problemas al conectar a la base datos \n - verifique los datos ingresados", "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message + "\n\n" + "*********************StackTrace: \n\n" + ex.StackTrace);
                //Environment.Exit(0);
               
                frmBaseDato frmbd = new frmBaseDato();
                frmbd.ShowDialog();

                return null;

            }
            return conn;
        }

        public void SqliteConnect()
        {

            String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3"; 
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
        }


        public Connect getConectSqlite()
        {
            Connect con = new Connect();
            String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            string sql = "SELECT * FROM connectdb";
            SQLiteCommand command = new SQLiteCommand(sql, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                con.server = reader["server"].ToString();
                con.database = reader["database"].ToString();
                con.user = reader["user"].ToString();
                con.pass = reader["pass"].ToString();
                con.ip_sap = reader["ip_sap"].ToString();

            }

            return con;

        }


    }
}
