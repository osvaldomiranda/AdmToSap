using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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

                var horaEnvio = new DateTime(1, 1, 1, 22, 0, 0);
                var horaRecibo = new DateTime(1, 1, 1, 22, 0, 0);
                // comparar la hora de envío con la hora actual
                var date = DateTime.Now;
                int h = date.Hour;

                if (horaEnvio.Hour == h)                   
                {
                    pro.EnvioDiario(frm);
                }

                if (horaRecibo.Hour == h)
                {
                    pro.reciboDiario(frm);
                }
            }
        }

        private int intervalo()
        {
            return 3600000; //sacar este valor de la base de datos
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
    }
}