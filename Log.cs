using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace AdmToSap
{
    class Log
    {
        String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";


        public void addLog( String suceso, String estado, String evento)
        {
            try
            {
                DateTime thisDay = DateTime.Now;
                String fecha = String.Format("{0:yyyyMMddTHHmmss}", thisDay);

                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                string sql = "insert into log (fch, suceso, estado,evento) values ('" + fecha + "' , '" + suceso + "', '" + estado + "', '" + evento + "')";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                command.ExecuteNonQuery();

                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
            }
        }

      

        public String verLog()
        {

            String logRes = String.Empty;

            try
            {

                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                string sql = "select * from log order by fch";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    Console.WriteLine("Estado :" + reader["estado"] + "\tFecha: " + reader["fch"] + "\tSuceso: " + reader["suceso"]);


                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
                return logRes;
            }

            return logRes;
        }


        public String verEvento()
        {
            String logRes = String.Empty;

            try
            {

                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                string sql = "select * from log order by fch desc limit 1";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                   
                    // Console.WriteLine(reader["evento"]);
                     logRes =  reader["evento"].ToString();

                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
                return logRes;
            }

            return logRes;

        }

      

    }

    }

