using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;

namespace AdmToSap
{
    class PaymentDb
    {
        ConnectDb con = new ConnectDb();
        public void getPayment()
        {
            OdbcConnection conexion = con.getConnect();

            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select RUT_CLTE as cardcode, FECHA_CAN as docduedate from cabezalventas " +
                                 "where cod_empresa=1 and cod_sucursal_abono=2 and tipo_abono = 21 and tipo_cargo>0 and nro_cargo>0 and ISNULL(fecha_cierre) " +
                                 "and tipodefactura > 0 and anulada='N' " +
                                 "order by cod_sucursal_abono, tipo_abono, nro_abono; ";
            OdbcDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0} {1}", reader.GetString(reader.GetOrdinal("cardcode")) + " - ", 
                                             reader.GetString(reader.GetOrdinal("docduedate"))
                                             
                                             );
            }
            conexion.Close();
        }

        
    }
}
