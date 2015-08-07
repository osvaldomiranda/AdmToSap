using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.SQLite;

namespace AdmToSap
{
    class Temporizadores
    {
        private volatile bool _shouldStop;
        public frmMain frm;
        public void startProcess(frmMain f)
        {
            frm = f;
            Thread processIatThread = new Thread(doProcess);
            processIatThread.Start();
            Console.WriteLine("main thread: Starting ProcessIat thread...");
            while (!processIatThread.IsAlive) ;
        }

        public void doProcess()
        {


            while (!_shouldStop)
            {
                Console.WriteLine("ProcessIat thread: working...");
                Thread.Sleep(intervalo());

                // Instanciar la clase que contiene el proceso
                Procesos pro = new Procesos();

                // Obtener la hora en que debe realizar el proceso
                // Envío

                var horaEnvio = new Temporizadores().getHoraEnvio(); //new DateTime(1, 1, 1, 22, 0, 0);
                var horaRecibo = new Temporizadores().getHoraRecibo();
                // comparar la hora de envío con la hora actual
                var date = DateTime.Now;
                int h = date.Hour;

                if (horaEnvio.Hour == h)                   
                {
                    pro.EnvioDiario(frm);
                }

                if (horaRecibo.Hour == h)
                {
                   // pro.getProductos(DateTime.Now.ToString(), "100", frm);
                   // pro.getInventarios("100", frm);
                   // pro.getPrecios(DateTime.Now.ToString(), "100", frm);

                }
            }
        }

        private int intervalo()
        {
            return 600000; //sacar este valor de la base de datos, esta reflejado en milisegundo
        }

        public void stopProcessIat()
        {
            RequestStop();
            Console.WriteLine("main thread: ProcessIat thread has terminated.");
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

        public DateTime getHoraEnvio()
        {
            String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";
            DateTime horaenvio = DateTime.Now;
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            string sql = "SELECT * FROM temporizadores;";
            SQLiteCommand command = new SQLiteCommand(sql, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                horaenvio = reader.GetDateTime(reader.GetOrdinal("horaenvio"));
            }

            myConn.Close();
            return horaenvio;

            
        }

        public DateTime getHoraRecibo()
        {
            String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";
            DateTime horarecibo = DateTime.Now;
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            string sql = "SELECT * FROM temporizadores;";
            SQLiteCommand command = new SQLiteCommand(sql, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                horarecibo = reader.GetDateTime(reader.GetOrdinal("horarecibo"));
            }

            myConn.Close();
            return horarecibo;


        }
    }
}