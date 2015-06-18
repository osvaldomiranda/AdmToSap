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

        public List<Payment> getCabezalDoc()
        {
            OdbcConnection conexion = con.getConnect();
            List<Payment> payments = new List<Payment>();

            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select * from cabezalventas " 
                                + "where cod_empresa=1 and cod_sucursal_abono=1 and tipo_abono = 21 and tipo_cargo>0 and nro_cargo>0 and ISNULL(fecha_cierre) " 
                                +"and tipodefactura > 0 and anulada='N' " 
                                +"order by cod_sucursal_abono, tipo_abono, nro_abono; ";
            OdbcDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                Payment payment = new Payment();

                payment.CardCode = reader.GetString(reader.GetOrdinal("RUT_CLTE"));
                payment.DocDate = "";
                payment.CashSum = "";
                payment.CashAccount = "";
                payment.TransferAccount = "";
                payment.TransferSum = "";
                payment.TransferDate = "";
                payment.TransferReference = "";

                payment.udf.U_SEI_CAJA = "";
                payment.udf.U_SEI_CAJERO = "";
                
                foreach (var doc in payment.documentsap)
                {
                    doc.InvoiceType = "";
                    doc.DocEntry = "";
                    doc.SumApplied = "";
                }





                payments.Add(payment);

                Console.WriteLine("{0} {1}", reader.GetString(reader.GetOrdinal("nro_comprobante")) + " - ", 
                                             reader.GetString(reader.GetOrdinal("MONTO"))
                                             
                                             );
            }

            
            conexion.Close();

            return payments;
        }

        
    }
}
