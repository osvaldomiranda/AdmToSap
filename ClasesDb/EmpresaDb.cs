using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace AdmToSap
{
    class EmpresaDb
    {
        String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";
        public Empresa getEmpresaSqlite()
        {
            

            Empresa empresa = new Empresa();
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            string sql = "SELECT * FROM empresas";
            SQLiteCommand command = new SQLiteCommand(sql, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                empresa.cod_empresa = reader.GetInt32(reader.GetOrdinal("cod_empresa"));
                empresa.nom_empresa = reader.GetString(reader.GetOrdinal("nom_empresa"));
                empresa.cod_sucursal = reader.GetInt32(reader.GetOrdinal("cod_sucursal"));
                empresa.nom_sucursal = reader.GetString(reader.GetOrdinal("nom_sucursal"));
            }

            myConn.Close();

            return empresa;
        }

        public void updateEmpresa(int id_empresa, string nom_empresa,int id_sucursal,string nom_sucursal)
        {

            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();

            string sql = "UPDATE empresas set " +
                           "cod_empresa = " + id_empresa + ", " +
                           "nom_empresa = '" + nom_empresa + "', " +
                           "cod_sucursal = " + id_sucursal + ", " +
                           "nom_sucursal = '" + nom_sucursal + "';";

            SQLiteCommand command = new SQLiteCommand(sql, myConn);
            command.ExecuteNonQuery();

            myConn.Close();

        }

    
    }
}
