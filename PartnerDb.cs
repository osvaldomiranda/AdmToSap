using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;

namespace AdmToSap
{
    class PartnerDb
    {
        ConnectDb con = new ConnectDb();
        public void getPartner()
        {
            OdbcConnection conexion = con.getConnect();

            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
                select.CommandText = "select clientes.*, paises.pais as country, ciudades.ciudad as city, comunas.comuna as county " +
                                 "from clientes " +
                                 "inner join paises on clientes.cod_pais=paises.cod_pais " +
                                 "inner join ciudades on clientes.cod_pais=ciudades.cod_pais " +
                                 "and clientes.cod_ciudad=ciudades.cod_ciudad " +
                                 "inner join comunas on clientes.cod_pais=comunas.cod_pais " +
                                 "and clientes.cod_ciudad=comunas.cod_ciudad " +
                                 "and clientes.cod_comuna=comunas.cod_comuna " +
                                 "where isnull(clientes.estado) or clientes.estado in (0,1) " +
                                 "order by clientes.cod_empresa, clientes.rut";
                                
            OdbcDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0} {1} {2}",
                                             reader.GetString(reader.GetOrdinal("R_SOCIAL")) + " | ",
                                             reader.GetString(reader.GetOrdinal("RUT")) + " | ",
                                             reader.GetString(reader.GetOrdinal("country")) + " | ",
                                             reader.GetString(reader.GetOrdinal("city")) + " | ",
                                             reader.GetString(reader.GetOrdinal("county"))

                                             );
            }
            conexion.Close();
        }
    }
}
