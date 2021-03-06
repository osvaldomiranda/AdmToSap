﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AdmToSap
{
    class PaymentDb
    {
        ConnectDb con = new ConnectDb();

        private Decimal SumcashSum(Payment payment)
        {
            Decimal suma = 0;

            OdbcConnection conexion = con.getConnect();
            List<Documentsap> docsap = new List<Documentsap>();
            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select * from cabezalventas "
                + " where COD_EMPRESA = " + payment.codEmpresa
                + " and COD_SUCURSAL = " + payment.codSucursalAbono
                + " and CAJA = " + payment.caja
                + " and fecha_cierre IS NULL "
                + " and  NRO_ABONO = " + payment.nroAbono + ";";  // numero de abono

            OdbcDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                suma += reader.GetDecimal(reader.GetOrdinal("MONTO")); ; 
            }
            conexion.Close();

            return suma;

        }

        public List<Payment> getComprobantePago()
        {
            OdbcConnection conexion = con.getConnect();
            List<Payment> payments = new List<Payment>();
            List<Checks> cheques = new List<Checks>();
            Empresa empresa = new Empresa();
            empresa = new EmpresaDb().getEmpresaSqlite();
            ConvertAdmSap convertAdmSap = new ConvertAdmSap();

            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select * from cabezalventas "
                                + "where cod_empresa = " + empresa.cod_empresa
                                + " and cod_sucursal_abono = " + empresa.cod_sucursal
                                + " and tipo_abono = 21 and tipo_cargo>0 and nro_cargo>0 and fecha_cierre IS NULL "
                                + "and tipodefactura > 0 and anulada='N' "
                                + "order by cod_sucursal_abono, tipo_abono, nro_abono, tipo_cargo, nro_cargo;";
            OdbcDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {

                Payment payment = new Payment();

                payment.CardCode = reader.GetString(reader.GetOrdinal("RUT_CLTE"));
                payment.DocDate = reader.GetDateTime(reader.GetOrdinal("FECHA_EM"));
                payment.tipoCargoAdm = convertAdmSap.typeDocument(reader.GetByte(reader.GetOrdinal("TIPO_CARGO")));
                payment.folioDte = reader.GetDecimal(reader.GetOrdinal("NRO_CARGO"));


                payment.CashAccount =  getcashAccount(reader.GetInt32(reader.GetOrdinal("COD_SUCURSAL_ABONO")).ToString());  // cuenta corriente cotilloncentral
                payment.TransferAccount = ""; // cuenta corriente cotilloncentral
                payment.TransferSum = "";
                payment.TransferDate = "";
                payment.TransferReference = "";
                payment.codEmpresa = reader.GetByte(reader.GetOrdinal("COD_EMPRESA"));
                payment.codSucursalAbono = reader.GetInt32(reader.GetOrdinal("COD_SUCURSAL_ABONO"));
                payment.caja = reader.GetByte(reader.GetOrdinal("CAJA"));
                payment.tipoAbono = reader.GetByte(reader.GetOrdinal("TIPO_ABONO"));
                payment.nroAbono = reader.GetInt32(reader.GetOrdinal("NRO_ABONO"));
                payment.CashSum = SumcashSum(payment).ToString(); // esta es la suma de las formas de pago              

                payment.udf.U_SEI_CAJA = reader.GetByte(reader.GetOrdinal("CAJA")).ToString();
                payment.udf.U_SEI_CAJERO = reader.GetInt64(reader.GetOrdinal("COD_CAJERO")).ToString();


                payment.documentsap = getDocSap(payment.codEmpresa, payment.codSucursalAbono, payment.caja, payment.tipoAbono, payment.nroAbono, reader.GetByte(reader.GetOrdinal("TIPO_CARGO")), payment.folioDte);
                
  

                payment.checks = getCheques(empresa.cod_empresa, empresa.cod_sucursal, payment.caja, payment.tipoAbono, payment.nroAbono);

                payment.creditcard = getTarjetas(empresa.cod_empresa, empresa.cod_sucursal, payment.caja, payment.tipoAbono, payment.nroAbono);
                if (payment.creditcard.Count != 0)
                    payment.CashSum = "";
                payments.Add(payment);

                Console.WriteLine("{0} {1}", reader.GetString(reader.GetOrdinal("nro_comprobante")) + " - ",
                                             reader.GetString(reader.GetOrdinal("MONTO"))

                                             );
            }


            conexion.Close();

            return payments;
        }

        public List<Documentsap> getDocSap(byte empreas, Int32 sucAbono, byte caja, int tipo, int numero, int tipodte, decimal foliodte)
        {
            OdbcConnection conexion = con.getConnect();
            List<Documentsap> docsap = new List<Documentsap>();
            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select * from cabezalventas "
                + " where COD_EMPRESA = " + empreas
                + " and COD_SUCURSAL = " + sucAbono
                + " and CAJA = " + caja 
                + " and fecha_cierre IS NULL "
                + " and  NRO_ABONO = " + numero +" order by NRO_ABONO asc;";  // codigo de abono

            OdbcDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                Documentsap item = new Documentsap();
                RespuestasDb respdb = new RespuestasDb();
                ConvertAdmSap convadmsap = new ConvertAdmSap();
                Respuesta respuesta = new Respuesta();


                item.InvoiceType = convadmsap.tipoInvoiceSap(tipodte); // tipo de clase sap para documento
                if (reader.GetByte(reader.GetOrdinal("TIPO_CARGO")) == 7)
                {
                    item.DocEntry = respdb.getMensaje(convadmsap.typeDocument(tipodte), reader.GetDecimal(reader.GetOrdinal("NRO_FISCAL"))); // mensaje de retorno documento
                }
                else
                {
                    item.DocEntry = respdb.getMensaje(convadmsap.typeDocument(tipodte), reader.GetDecimal(reader.GetOrdinal("NRO_CARGO")));
                }
                if (item.DocEntry == "")
                {
                     //MessageBox.Show("El documento Folio: " + reader.GetDecimal(reader.GetOrdinal("NRO_CARGO")) + " Tipo: "+tipodte+" todavía no fue enviado a SAP, favor verificar los errores de envío");
                    //Environment.Exit(0);
                    item.error = "El documento Folio: " + reader.GetDecimal(reader.GetOrdinal("NRO_CARGO")) + " Tipo: " + tipodte + " todavía no fue enviado a SAP, favor verificar los errores de envío";
                    respuesta.fecha = DateTime.Now.ToString();
                    respuesta.folio = reader.GetDecimal(reader.GetOrdinal("NRO_CARGO")).ToString();
                    respuesta.tipodete = tipodte.ToString();
                    respuesta.tiporesp = "Envío de Pago con Error";
                    respuesta.json= "El documento Folio: " + reader.GetDecimal(reader.GetOrdinal("NRO_CARGO")) + " Tipo: "+tipodte+" todavía no fue enviado a SAP, favor verificar los errores de envío";
                    respuesta.xml = "";
                    respdb.addRespuesta(respuesta);
                }
                else
                {
                    item.SumApplied = reader.GetDouble(reader.GetOrdinal("MONTO")).ToString(); //  TODO total o parcial del doc
                    docsap.Add(item);
                }
            }
            conexion.Close();
            return docsap;

        }

        public List<Checks> getCheques(int codEmpresa, int codSucursal, int caja, int tipo, int numero)
        {
            OdbcConnection conexion = con.getConnect();
            List<Checks> cheques = new List<Checks>();
            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select * from doc_clientes "
                + " where COD_EMPRESA = " + codEmpresa
                + " and CAJA = " + caja
                + " and fecha_cierre IS NULL "
                + " and TIPO_PAGO in (2,3)"   
                + " and TIPO_DOCTO = " + tipo  // tipo de abono
                + " and NRO_DOCTO = " + numero + ";";  // codigo de abono

            OdbcDataReader reader = select.ExecuteReader();

            while (reader.Read())
            {
                Checks cheque = new Checks();
                ConvertAdmSap conv = new ConvertAdmSap();
                // Solucion campos nulos o null IsDBNull
                cheque.DueDate = reader.IsDBNull(reader.GetOrdinal("FECHA_CAN")) ? DateTime.Now  : reader.GetDateTime(reader.GetOrdinal("FECHA_CAN")); 
                cheque.CheckNumber = reader.GetDecimal(reader.GetOrdinal("NRO_DOCUMENTO"));
                cheque.BankCode = conv.codBanco( reader.GetInt32(reader.GetOrdinal("COD_BANCO")));
                cheque.CheckSum = reader.GetDouble(reader.GetOrdinal("MONTO")).ToString();
                cheque.CheckAccount = getCheckAccount(reader.GetInt32(reader.GetOrdinal("COD_SUCURSAL_ABONO")).ToString());



                cheques.Add(cheque);

            }
            conexion.Close();
            return cheques;
        }

        public List<CreditCards> getTarjetas(int codEmpresa, int codSucursal, int caja, int tipo, int numero)
        {
            // TODO TIPO_DOCTO
            // 1 - Efectivo
            // 2 - cheque al dia
            // 3 - cheque a fecha
            // 4 - tarjeta de credito o debito
            // 5 - deposito bancario
            // 6 - letras
            // 8 - transferencia electronica

            OdbcConnection conexion = con.getConnect();
            List<CreditCards> tarjetas = new List<CreditCards>();
            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select * from doc_clientes "
                + " where COD_EMPRESA = " + codEmpresa
                + " and CAJA = " + caja
                + " and fecha_cierre IS NULL "
                + " and TIPO_PAGO in (4)"   // TODO consultar tipos de pago
                + " and TIPO_DOCTO = " + tipo  // tipo de abono
                + " and NRO_DOCTO = " + numero + ";";  // codigo de abono

            OdbcDataReader reader = select.ExecuteReader();

            while (reader.Read())
            {
                CreditCards tarjeta = new CreditCards();
                ConvertAdmSap conv = new ConvertAdmSap();

                tarjeta.CreditCard = getTipoTarjeta(reader.GetInt32(reader.GetOrdinal("COD_BANCO")).ToString());
                tarjeta.CreditCardNumber = reader.GetDecimal(reader.GetOrdinal("NRO_DOCTO")).ToString(); //  numero de la tarjeta
                // Solucion campos nulos o null IsDBNull
                tarjeta.CardValidUntil = reader.IsDBNull(reader.GetOrdinal("FECHA_VEN")) ? DateTime.Now : reader.GetDateTime(reader.GetOrdinal("FECHA_VEN")); // vencimiento de la tarjeta
                tarjeta.CreditSum = reader.GetDouble(reader.GetOrdinal("MONTO")).ToString();
                tarjeta.VoucherNum = reader.GetDecimal(reader.GetOrdinal("NRO_DOCUMENTO"));
                tarjeta.CreditAcct = getCreditAcct(reader.GetByte(reader.GetOrdinal("COD_SUCURSAL")).ToString());



                tarjetas.Add(tarjeta);

            }
            conexion.Close();
            return tarjetas;
        }

        public void updateReciboAdm(byte empresa, Int32 sucAbono, byte caja, Int32 tipoAbono, Int32 numAbono)
        {

           

            OdbcConnection conexion = con.getConnect();
            OdbcCommand update = new OdbcCommand();
            update.Connection = conexion;

            update.CommandText = "update cabezalventas "
                                 + " set fecha_cierre = now()"
                                 + " where cod_empresa=" + empresa
                                 + " and cod_sucursal=" + sucAbono
                                 + " and caja=" + caja
                                 + " and tipo_abono=" + tipoAbono
                                 + " and nro_abono=" + numAbono
                                 + " and anulada='N'"
                                 + " and fecha_cierre IS NULL "
                                 + " and tipodefactura > 0 ;";


            OdbcDataReader up = update.ExecuteReader();

        }

        public void updateFormaPago(Payment payment)
        {


            OdbcConnection conexion = con.getConnect();
            OdbcCommand update = new OdbcCommand();
            update.Connection = conexion;

            update.CommandText = "update doc_clientes "
                                 + " set fecha_cierre = now()"
                                 + " where cod_empresa = " + payment.codEmpresa
                                 + " and cod_sucursal = " + payment.codSucursalAbono
                                 + " and caja = " + payment.caja
                                 + " and tipo_docto = " + payment.tipoAbono
                                 + " and nro_docto = " + payment.nroAbono
                                 + " and rut_clte = '" +payment.CardCode+ "'"
                                 + " and fecha_cierre IS NULL;";



            OdbcDataReader up = update.ExecuteReader();


        }

        public String getcashAccount(String cod_suc)
        {
            String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";
            String cashAccount = String.Empty;
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            String sql1 = "SELECT * FROM sucursales where cod_adm = " + cod_suc;
            SQLiteCommand command = new SQLiteCommand(sql1, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cashAccount = reader.GetString(reader.GetOrdinal("cashaccount"));
            }

            myConn.Close();

            return cashAccount;
        }

        public String getCreditAcct(String cod_suc)
        {

            String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";
            String creditacct = String.Empty;
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            String sql1 = "SELECT * FROM sucursales where cod_adm = " + cod_suc;
            SQLiteCommand command = new SQLiteCommand(sql1, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                creditacct = reader.GetString(reader.GetOrdinal("creditacct"));
            }

            myConn.Close();


            return creditacct;
        }

        public String getCheckAccount(String cod_suc)
        {

            String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";
            String checkaccount = String.Empty;
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            String sql1 = "SELECT * FROM sucursales where cod_adm = " + cod_suc;
            SQLiteCommand command = new SQLiteCommand(sql1, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                checkaccount = reader.GetString(reader.GetOrdinal("checkaccount"));
            }

            myConn.Close();


            return checkaccount;
        }

        public String getTipoTarjeta(String codTarjeta)
        {
            String tipoTarjeta = String.Empty;
            OdbcConnection conexion = con.getConnect();
            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select * from tarjetas "
                + "where cod_tarjeta = " + codTarjeta + ";";

            OdbcDataReader reader = select.ExecuteReader();

            while (reader.Read())
            {

                tipoTarjeta =  reader.GetByte(reader.GetOrdinal("TIPO")).ToString();
            }
            conexion.Close();
            return tipoTarjeta;

        }
    


    }
}
