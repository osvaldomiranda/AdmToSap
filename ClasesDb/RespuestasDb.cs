using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace AdmToSap
{
    class RespuestasDb
    {

     String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";

        public void addRespuesta(Respuesta respuesta)
        {
            try
            {
                DateTime thisDay = DateTime.Now;
                String fecha = String.Format("{0:yyyyMMddTHHmmss}", thisDay);

                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();
    

                RespuestasDb respdb = new RespuestasDb();
                string mensaje =  respdb.extraeMensaje(respuesta.xml.Replace("'", ""));

                string sql = "insert into respuestas (fecha, tipodte, folio, mensaje, tiporesp, xml, json) " 
                            +"values ('" 
                            + fecha + "' , "
                            + respuesta.tipodete + "," 
                            + respuesta.folio + ",'" 
                            + mensaje +"','"
                            + respuesta.tiporesp + "','"
                            + respuesta.xml + "','"
                            + respuesta.json + "')";
               
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                command.ExecuteNonQuery();

                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
            }
        }

        public String extraeMensaje(string xml)
        {
            string mensaje = string.Empty;

            Console.WriteLine(xml);

            int start = xml.IndexOf("msg")+6;
            int end = xml.IndexOf("\"}}</JSONResponse>");
            int largo = end - start;

            mensaje = xml.Substring(start, largo);            
            
            return mensaje;
        }

        public String getMensaje(int tipoDte, Decimal folioDoc)
        {
            String mensaje = "";
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            string sql = "SELECT * FROM respuestas " 
                       +" WHERE tipodte = "
                       + tipoDte + " and folio = " 
                       + folioDoc + ";";
            SQLiteCommand command = new SQLiteCommand(sql, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                mensaje = reader.GetString(reader.GetOrdinal("mensaje"));
            }

            myConn.Close();
            return mensaje;
        }
    }
}
