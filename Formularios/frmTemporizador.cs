using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AdmToSap
{
    public partial class frmTemporizador : Form
    {
        public frmTemporizador()
        {
            InitializeComponent();
        }

        private void frmTemporizador_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";
            try
            {
                String ceroEnvio = "0";
                String ceroRecibo = "0";
                if (UpDownHoraEnvio.Value > 9)
                {
                    ceroEnvio = "";
                }

                if (UpDownHoraRecibo.Value > 9)
                {
                    ceroRecibo = "";
                }

                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                string sql = "UPDATE temporizadores set "
                           + "horaenvio = '2015-07-05 " + ceroEnvio + "" + UpDownHoraEnvio.Value + ":00:00', "
                           + "horarecibo = '2015-07-05 " + ceroRecibo + "" + UpDownHoraRecibo.Value + ":00:00';";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                command.ExecuteNonQuery();

                myConn.Close();
            }
            catch (Exception empUpdate)
            {
                Console.WriteLine("ERROR: {0}" + empUpdate.ToString());
                MessageBox.Show("ERROR: {0}" + empUpdate.ToString());
            }


            MessageBox.Show("Guardado con exito");
        }
    }
}
