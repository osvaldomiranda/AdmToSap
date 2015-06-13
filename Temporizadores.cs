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

        public void startProcessClientes()
        {
            Thread processIatThread = new Thread(doProcessClientes);
            processIatThread.Start();
            Console.WriteLine("main thread: Starting ProcessIat thread...");
            while (!processIatThread.IsAlive) ;
        }

        public void doProcessClientes()
        {


            while (!_shouldStop)
            {
                Console.WriteLine("ProcessIat thread: working...");
                Thread.Sleep(intervalo()); 

            }
        }

        private int intervalo()
        {
            return 5000; //sacar este valor de la base de datos
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
