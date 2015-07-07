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
    public partial class frmBaseDato : Form
    {
        String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";
        public frmBaseDato()
        {
            InitializeComponent();

        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            string sql = "SELECT * FROM connectdb";
            SQLiteCommand command = new SQLiteCommand(sql, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                txtServer.Text = reader["server"].ToString();
                txtDatabase.Text = reader["database"].ToString();
                txtUsuario.Text = reader["user"].ToString();
                txtContrasena.Text = reader["pass"].ToString();
            }

            myConn.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           try
            {
                

                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                string sql = "UPDATE connectdb set " +
                               "server = '" + txtServer.Text + "', " +
                               "database = '" + txtDatabase.Text + "', " +
                               "user = '" + txtUsuario.Text + "', " +
                               "pass = '" + txtContrasena.Text + "';";

                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                command.ExecuteNonQuery();

                myConn.Close();
            }
            catch (Exception empUpdate)
            {
                Console.WriteLine("ERROR: {0}"+ empUpdate.ToString());
                MessageBox.Show("ERROR: {0}"+ empUpdate.ToString());
            }


            MessageBox.Show("Guardado con exito");
         }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
