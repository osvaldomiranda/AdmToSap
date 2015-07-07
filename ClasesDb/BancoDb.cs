using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;

namespace AdmToSap
{
    class BancoDb
    {
        ConnectDb con = new ConnectDb();
        

        public void getBancos()
        {
            OdbcConnection conexion = con.getConnect();

            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "SELECT bancos.COD_BANCO as id_banco, bancos.NOMBRE FROM bancos";
            
            OdbcDataReader reader = select.ExecuteReader();
            
            while (reader.Read())
            {
                Console.WriteLine("{0} {1}", reader.GetString(reader.GetOrdinal("id_banco")) + " - ", reader.GetString(reader.GetOrdinal("NOMBRE")));
            }
            conexion.Close();
        }


    }
}
