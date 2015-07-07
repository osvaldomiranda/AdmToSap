using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace AdmToSap
{
    class LocalDataBase
    {
        String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";

        public bool creaDB()
        {
            try
            {
                if (!System.IO.File.Exists(@"C:/admtosap/DataB.sqlite"))
                {
                    Directory.CreateDirectory(@"c://admtosap");
                    SQLiteConnection.CreateFile(@"C:/admtosap/DataB.sqlite");

                    MessageBox.Show("Base de Datos Se ha creado con Exito");

                    // agrego las tablas
                    creaTablaConnectDb();
                    creaTablaLog();
                    creaTablaDocumento();
                    creaTablaBodegas();
                    creaTablaEmpresas();
                    creaTablaRespuestas();
                    creaTablaBancos();
                }
                else
                {
                    Console.WriteLine("La Base de datos existe");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
                return false;
            }

            return true;
        }

        public void creaTablaConnectDb()
        {
                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                String sql1 = "CREATE TABLE [connectdb] "
                + "([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"
                + "[server] VARCHAR(255) DEFAULT 'Server',"
                + "[database] VARCHAR(255) NULL,"
                + "[user] VARCHAR(255) NULL,"
                + "[pass] VARCHAR(255) NULL"
                + ")";

                String sql2 = "INSERT INTO connectdb "
                + "(id,server,database,user,pass) VALUES "
                + "(1,'server','database','user','pass'"
                + ")";

                SQLiteCommand cmd1 = new SQLiteCommand(sql1, myConn);
                cmd1.ExecuteNonQuery();

                SQLiteCommand cmd2 = new SQLiteCommand(sql2, myConn);
                cmd2.ExecuteNonQuery();
                myConn.Close();

        }

        public void creaTablaLog()
        {

            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();

            String sql1 = "CREATE TABLE log "
                         + "(fch VARCHAR(20), "
                         + "suceso TEXT, "
                         + "estado VARCHAR(20))"; 

            String sql2 = "INSERT INTO log "
            + "(fch,suceso,estado) VALUES "
            + "('"+String.Format("{0:yyyyMMddTHHmmss}", DateTime.Now)+ "','inicio Base','OK'"
            + ")";

            SQLiteCommand cmd1 = new SQLiteCommand(sql1, myConn);
            cmd1.ExecuteNonQuery();

            SQLiteCommand cmd2 = new SQLiteCommand(sql2, myConn);
            cmd2.ExecuteNonQuery();
            myConn.Close();
        }

        public void creaTablaDocumento()
        {

            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();

            String sql1 = "CREATE TABLE documento ("
                         + "tipodteadm VARCHAR(2), "
                         + "tipodtesap,VARCHAR(2)"
                         + "nombretipo,VARCHAR(255)"
                         + "tipodeobjeto,VARCHAR(255)" 
                         + "subtipoobjeto,VARCHAR(255)" 
                         + ")";

            SQLiteCommand cmd1 = new SQLiteCommand(sql1, myConn);
            cmd1.ExecuteNonQuery();
            myConn.Close();

        }

        public void creaTablaBodegas()
        {

            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();

            String sql1 = "CREATE TABLE bodegas ("
                         + "nom_bodega VARCHAR(255), "
                         + "codigoadm,VARCHAR(255)"
                         + "codigosap,VARCHAR(255)"
                         + ")";

            SQLiteCommand cmd1 = new SQLiteCommand(sql1, myConn);
            cmd1.ExecuteNonQuery();
            myConn.Close();

        }

        public void creaTablaEmpresas()
        {
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();

            String sql1 = "CREATE TABLE empresas ("
                         + "cod_empresa,INTEGER "
                         + "nom_empresa, TEXT"
                         + "cod_sucursal,INTEGER"
                         + "nom_sucursal,TEXT"
                         + ")";

            SQLiteCommand cmd1 = new SQLiteCommand(sql1, myConn);
            cmd1.ExecuteNonQuery();
            myConn.Close();

        }

        public void creaTablaRespuestas()
        {
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();

            String sql1 = "CREATE TABLE respuestas ("
                         + "fecha,TEXT "
                         + "tipodte, TEXT"
                         + "folio,INTEGER"
                         + "mensaje,TEXT"
                         + "tiporesp,TEXT"
                         + "xml,TEXT"
                         + "json,TEXT" 
                         + ")";

            SQLiteCommand cmd1 = new SQLiteCommand(sql1, myConn);
            cmd1.ExecuteNonQuery();
            myConn.Close();

        }

        public void creaTablaBancos()
        {
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();

            String sql1 = "CREATE TABLE bancos ("
                         + "codadm,TEXT "
                         + "codsap, TEXT"
                         + "nombre,TEXT"
                         + "cuentaadm,TEXT"
                         + "cuantasap,TEXT"
                         + ")";

            SQLiteCommand cmd1 = new SQLiteCommand(sql1, myConn);
            cmd1.ExecuteNonQuery();
            myConn.Close();

        }



    }// fin clase


}
