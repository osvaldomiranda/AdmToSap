using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data.SQLite;

namespace AdmToSap
{
    class PartnerDb
    {
        ConnectDb con = new ConnectDb();
        public List<Partner> getPartners()
        {
            OdbcConnection conexion = con.getConnect();
            List<Partner> partners = new List<Partner>();

            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select clientes.*, paises.pais as country, ciudades.ciudad as city, comunas.comuna as county "
            + "from clientes "
            + "inner join paises on clientes.cod_pais=paises.cod_pais "
            + "inner join ciudades on clientes.cod_pais=ciudades.cod_pais "
            + "and clientes.cod_ciudad=ciudades.cod_ciudad "
            + "inner join comunas on clientes.cod_pais=comunas.cod_pais "
            + "and clientes.cod_ciudad=comunas.cod_ciudad "
            + "and clientes.cod_comuna=comunas.cod_comuna "
            + "where isnull(clientes.estado) or clientes.estado in (0,1) "
            + "order by clientes.cod_empresa, clientes.rut";

            OdbcDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                Partner partner = new Partner();
                String codempresa = reader.GetString(reader.GetOrdinal("COD_EMPRESA"));

                partner.CardCode = "";
                partner.CardName = reader.GetString(reader.GetOrdinal("R_SOCIAL"));
                partner.LicTradNum = reader.GetString(reader.GetOrdinal("RUT"));
                partner.Notes = reader.GetString(reader.GetOrdinal("GIRO"));
                partner.GroupNum = "";
                partner.SlpCode = "-1";
                partner.Street = reader.GetString(reader.GetOrdinal("DIRECCION"));
                partner.Block = "";
                partner.City = reader.GetString(reader.GetOrdinal("city"));
                partner.County = reader.GetString(reader.GetOrdinal("county"));
                partner.Country = reader.GetString(reader.GetOrdinal("country"));
                partner.udf = "";
                partner.codEmpresa = codempresa;

                partners.Add(partner);

                Console.WriteLine("{0} {1} {2}",
                reader.GetString(reader.GetOrdinal("R_SOCIAL")) + " | ",
                reader.GetString(reader.GetOrdinal("RUT")) + " | ",
                reader.GetString(reader.GetOrdinal("GIRO")) + " | ",
                reader.GetString(reader.GetOrdinal("DIRECCION")) + " | ",
                reader.GetString(reader.GetOrdinal("country")) + " | ",
                reader.GetString(reader.GetOrdinal("city")) + " | ",
                reader.GetString(reader.GetOrdinal("county"))

                );
            }

            conexion.Close();
            return partners;


        }

        public void updateInAdm(String empresa, String rut)
        {
            OdbcConnection conexion = con.getConnect();
            OdbcCommand update = new OdbcCommand();
            update.Connection = conexion;

            update.CommandText = "update clientes "
            + "set estado = 2 "
            + "where cod_empresa = " + empresa + " and rut='" + rut + "' and estado in (0,1);";


            OdbcDataReader up = update.ExecuteReader();

        }


    }
}
