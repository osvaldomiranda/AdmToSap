using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace AdmToSap
{
    class ConvertAdmSap
    {
        String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";

        public int typeDocument(int type)
        {
            string dbtype = "";
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            String sql1 = "SELECT * FROM documento where tipodteadm = " + type;
            SQLiteCommand command = new SQLiteCommand(sql1, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dbtype = reader.GetString(reader.GetOrdinal("tipodtesap"));
            }

            myConn.Close();
            return Convert.ToInt32(dbtype);
        }

        public string codBodega(string codbod)
        {
            string dbcod = "";
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            String sql1 = "SELECT * FROM bodegas where codigoadm = " + codbod;
            SQLiteCommand command = new SQLiteCommand(sql1, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dbcod = reader.GetString(reader.GetOrdinal("codigosap"));
            }
            myConn.Close();
            return dbcod;
        }

        public string tipoInvoiceSap(int tipoDte)
        {
            string tipoObjeto = "";
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            String sql1 = "SELECT * FROM documento where tipodteadm = " + tipoDte;
            SQLiteCommand command = new SQLiteCommand(sql1, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               tipoObjeto = reader.GetString(reader.GetOrdinal("tipodeobjeto"));
            }
            myConn.Close();
            return tipoObjeto;
        }

        public string DocumentSubType(int tipoDte)
        {
            string tipoObjeto = "";
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            String sql1 = "SELECT * FROM documento where tipodteadm = " + tipoDte;
            SQLiteCommand command = new SQLiteCommand(sql1, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tipoObjeto = reader.IsDBNull(reader.GetOrdinal("subtipoobjeto")) ? String.Empty : reader.GetString(reader.GetOrdinal("subtipoobjeto"));
            }
            myConn.Close();
            return tipoObjeto;
        }

        public String codBanco(int codBanco)
        {
            String codigo = "";

            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            String sql1 = "SELECT * FROM bancos where codadm  = " + codBanco;
            SQLiteCommand command = new SQLiteCommand(sql1, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                codigo = reader.GetString(reader.GetOrdinal("codsap"));
            }
            myConn.Close();
            
            return codigo;
        }

        public String cuentaBanco(int codBanco)
        {
            String cuenta = "";

            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            String sql1 = "SELECT * FROM bancos where codadm  = " + codBanco ;
            SQLiteCommand command = new SQLiteCommand(sql1, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cuenta = reader.GetString(reader.GetOrdinal("cuentasap"));
            }
            myConn.Close();

            return cuenta;
        }

        public string codSucursal(int codsuc)
        {
            string dbcod = "";
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            String sql1 = "SELECT * FROM sucursales where cod_adm = " + codsuc;
            SQLiteCommand command = new SQLiteCommand(sql1, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dbcod = reader.GetString(reader.GetOrdinal("cod_sap"));
            }
            myConn.Close();
            return dbcod;
        }


        public int getSalesPersonCode(int codsuc)
        {
            int salesPCode = 0;
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            String sql1 = "SELECT * FROM sucursales where cod_adm = " + codsuc;
            SQLiteCommand command = new SQLiteCommand(sql1, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                salesPCode = Convert.ToInt32(reader.GetString(reader.GetOrdinal("salesperson")));
            }
            myConn.Close();
            return salesPCode;
        }

    
    }
}
