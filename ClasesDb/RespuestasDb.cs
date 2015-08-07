using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace AdmToSap
{
    class MensajeRespuesta
    {
        public String idSap { get; set; }
        public String errorMsg { get; set; }
    }
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
                MensajeRespuesta mensaje =  respdb.extraeMensaje(respuesta.xml.Replace("'", ""));
                string sql = "insert into respuestas (fecha, tipodte, folio, mensaje, tiporesp, xml, json,mensajerror) " 
                            +"values ('" 
                            + fecha + "' , "
                            + respuesta.tipodete + "," 
                            + respuesta.folio + ",'" 
                            + mensaje.idSap +"','"
                            + respuesta.tiporesp + "','"
                            + respuesta.xml + "','"
                            + respuesta.json + "','"
                            + mensaje.errorMsg + "')";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                command.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
            }
        }

        public MensajeRespuesta extraeMensaje(string xml)
        {
            MensajeRespuesta mensaje = new MensajeRespuesta();
            try
            {
                int start = xml.IndexOf("msg") + 6;
                int end = xml.IndexOf("\"}}</JSONResponse>");
                int largo = end - start;
                if (xml.IndexOf("ErrorMsg") == -1)
                {
                    mensaje.idSap = xml.Substring(start, largo);
                    mensaje.errorMsg = "";
                }
                else
                {
                    mensaje.idSap = "";
                    mensaje.errorMsg = xml.Substring(start, largo);
                }
            }catch(Exception e)
            {
                Console.WriteLine("Error de conección" + e);
                mensaje.errorMsg = "Error de conección";
            }
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
                       + folioDoc + " and mensajerror = '';";
            SQLiteCommand command = new SQLiteCommand(sql, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                mensaje = reader.GetString(reader.GetOrdinal("mensaje"));
            }

            myConn.Close();
            return mensaje;
        }

        public String extraeJsonProducto(string json)
        {
            string mensaje = string.Empty;

            Console.WriteLine(json);

            int start = json.IndexOf("{\"rowCount\"");
            int end = json.IndexOf("</JSONResponse>");
            int largo = end - start;

            mensaje = json.Substring(start, largo);

            return mensaje;
        }

        public String extraeJsonPrecios(string json)
        {
            string mensaje = string.Empty;

            Console.WriteLine(json);

            int start = json.IndexOf("<JSONResponse>[")+15;
            int end = json.IndexOf("]</JSONResponse>");
            int largo = end - start;

            mensaje = json.Substring(start, largo);

            return mensaje;
        }

        public MensajeRespuesta extraeMensajeCliente(String xml)
        {

            MensajeRespuesta mensaje = new MensajeRespuesta();
            try
            {
                int start = xml.IndexOf("msg") + 6;
                int end = xml.IndexOf("\"}}</JSONResponse>");
                int largo = end - start;
                if (xml.IndexOf("ErrorMsg") != -1)
                {
                    mensaje.idSap = "";
                    mensaje.errorMsg = xml.Substring(start, largo);
                }
                else
                {
                    mensaje.idSap = xml.Substring(start, largo);
                    mensaje.errorMsg = "";

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Eror de conección" + e);
                mensaje.errorMsg = "Error de conección";
            }
            return mensaje;
  
        }

        public int getMensajeError(string responce)
        {
            int value = 0;
            value =  responce.LastIndexOf("Error");
            return value;
        }


    }
}
