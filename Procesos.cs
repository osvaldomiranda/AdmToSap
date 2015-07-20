using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdmToSap
{
    class Procesos
    {
        Log log = new Log();
        Respuesta respuesta = new Respuesta();
        RespuestasDb respdb = new RespuestasDb();
        Connect consqlite = new Connect();
        ConnectDb condbsqlite = new ConnectDb();


        public void addClientes(frmMain frmain)
        {

            PartnerDb partnerdb = new PartnerDb();
            List<Partner> partners = new List<Partner>();
            Log log = new Log();
            consqlite = condbsqlite.getConectSqlite();
            partners = partnerdb.getPartners();
            if (partners.Count == 0)
            {
                frmain.listBoxLog.Items.Insert(0,"No se encuentran clientes nuevos");
            }

            foreach (Partner p in partners)
            {

                string url = "http://"+consqlite.ip_sap +""+
         "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?" +
         "wsaction=" +
         "AddBPartner";
                // agrega separador
                String rut = p.LicTradNum;
                string json = "{"
                       + " \"BusinessPartner\": { "
                       + " \"CardCode\": \"CF-" + (rut).Substring(0,8) + "\", " // falta el campo de adm
                       + " \"CardName\": \"" + p.CardName + "\", "
                       + " \"LicTradNum\": \"" + rut.Insert(8,"-") + "\","
                       + " \"Notes\": \"" + p.Notes + "\","
                       + " \"GroupNum\": \"" + p.GroupNum + "\","
                       + " \"SlpCode\": \"" + p.SlpCode + "\","
                       + " \"Street\": \"" + p.Street + "\","
                       + " \"Block\": \"" + p.Block + "\","
                       + " \"City\": \"" + p.City + "\","
                       + " \"County\": \"" + p.County + "\","
                       + " \"GroupCode\": \"102\"," // TODO pedir datos a adm
                    //   + " \"udf\": { \"U_SEI_*\": \"0\" }" campo opcional
                       + "}"
                       + "}";

                Connect conn = new Connect();
                String responce = conn.HttpPOST(url, json);

                partnerdb.updateInAdm(p.codEmpresa, p.LicTradNum);

                respdb.extraeMensajeCliente(responce);

                String evento = "ENVIO: Cliente - RUT: " + rut.Insert(8, "-") + " - NOMBRE: " + p.CardName + " - ESTADO: " + respdb.extraeMensajeCliente(responce) +"";
                
                log.addLog("Respuesta Sap: " + responce.Replace("'","") + "Rut Actualizado: " + rut.Insert(8, "-"), "OK",evento);

                frmain.listBoxLog.Items.Insert(0, evento);


                // instanciar clase de envio adm que recibe una lista de respuestas
                // un metodo de esta clase recorrera la lista de respuestas y las enviara a adm
                System.Console.WriteLine("LA RESPUESTA ES :" + responce);
            }

        }

        public void addDocuments(frmMain frmain)
        {
            string cardcade = string.Empty;

            DocumentDb docdb = new DocumentDb();
            List<Document> documents = new List<Document>();
            Log log = new Log();
            ConvertAdmSap convadmsap = new ConvertAdmSap();
            consqlite = condbsqlite.getConectSqlite();
            documents = docdb.getDocuments();
            if (documents.Count == 0)
            {
                frmain.listBoxLog.Items.Insert(0, "No se encuentran Documentos");
            }

            foreach (Document p in documents)
            {
                string url = "http://"+consqlite.ip_sap+"" +
                    "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?" +
                    "wsaction=" +
                    "AddDocument";

                string detalles = string.Empty;
                string json = string.Empty;
                string cabecerajson = "{"
                        + "        \"BoObjectType\":\""+p.BoObjectType+"\",  "
                        + "        \"Document\": { "
                        + "        \"DocumentSubType\":\"" + p.DocumentSubType + "\", "  // si es factura = --
                        + "        \"CardCode\": \"CF-" + (p.CardCode).Substring(0, 8) + "\", "
                        + "        \"DocDate\": \"" + String.Format("{0:yyyyMMdd}", p.DocDate) + "\", "
                        + "        \"DocDueDate\": \"" + String.Format("{0:yyyyMMdd}", p.DocDueDate) + "\", "
                        + "        \"TaxDate\": \"" + String.Format("{0:yyyyMMdd}", p.TaxDate) + "\", "
                        + "        \"FolioNumber\": \"" + p.Nro_Fiscal + "\", "
                        + "        \"FolioPrefixString\": \"" + p.FolioPrefixString + "\", "
                        + "        \"DiscountPercent\": \"" + p.DiscountPercent + "\", "
                        + "        \"Indicator\": \"" + p.Indicator + "\", "
                        + "        \"udf\": {"
                        + "        \"U_SEI_FEBOSID\": \""+p.udf.U_SEI_FEBOSID+"\","
                        + "        \"U_SEI_CAJA\": \"1\","
                        + "        \"U_SEI_CAJERO\": \"CAJ001\""
                        + "         }, "
                        + "        \"Items\": "
                        + "         [ ";
                int count = 0;
                string llave = string.Empty;
                foreach(var det in p.items)
                {
                    count += 1;
                    string detallejson = "{"
                       //  + "                \"BaseEntry\" : \"0\"," // TODO 
                       //  + "                \"BaseType\" : \"0\"," // TODO 
	                   //  + "                \"BaseLine\": \"0\","  // TODO
                           + "                \"ItemCode\": \"" + det.ItemCode + "\", "
                           + "                \"Quantity\": \"" + det.Quantity + "\", "
                           + "                \"UnitPrice\": \"" + det.UnitPrice + "\", "
                           + "                \"WarehouseCode\": \"" + det.WarehouseCode + "\",  "
                       //    + "                \"GroupCode\": \" 102\"," // TODO pedir datos a adm
                        // + "                 \"COGSCostingCode\": \""+ convadmsap.codSucursal(p.Cod_Sucursal).ToString()+"\", " // add transform
                           + "                \"TaxCode\": \"IVA\", "
                           + "                \"DiscountPercent\": \"" + det.DiscountPercent + "\" ";
                       if(p.items.Count > count)
                       {
                               llave =  "            },";
                       }
                       else
                       {
                                llave =  "            }";
                       }

                detalles += detallejson + llave;
                }
                string piejson ="]"
                        + "    }"
                        + "}";

               json = cabecerajson + detalles+ piejson;

                Connect conn = new Connect();
                String responce = conn.HttpPOST(url, json);
                
                
                // cargo los datos para el updateadm
                CabezalVentaAdm cvadm = new CabezalVentaAdm();
                cvadm.COD_EMPRESA = p.Cod_Empresa.ToString();
                cvadm.COD_SUCURSAL = p.Cod_Sucursal.ToString();
                cvadm.TIPO_CARGO = p.Tipo_Cargo.ToString();
                cvadm.NRO_CARGO = p.Nro_Cargo.ToString();
                cvadm.CAJA = p.Caja.ToString();
                cvadm.ID_SAP = respdb.extraeMensaje(responce.Replace("'",""));
                // Actualizo Adm
                docdb.updateInAdm(cvadm);

                // si el ducumento es una nota de credito
                if (p.tipoAbono.ToString() == "61" || p.tipoAbono.ToString() == "60" || p.tipoAbono.ToString() == "22")
                {
                    docdb.updateCabezNCAdm(p.Cod_Empresa.ToString(), p.codSucursalAbono.ToString(), p.tipoAbono.ToString(), p.numAbono.ToString());
                }
                // cargo la respuesta
                respuesta.tipodete = p.Indicator.ToString();
                respuesta.folio = p.Nro_Cargo.ToString();
                respuesta.tiporesp = "Documento";
                respuesta.xml = responce.Replace("'", "");
                respuesta.json = json;
                // agrego la respuesta
                respdb.addRespuesta(respuesta);
                String numcargoabono = "";
                if (p.tipoAbono.ToString() == "61" || p.tipoAbono.ToString() == "60" || p.tipoAbono.ToString() == "22")
                {
                    numcargoabono = p.numAbono.ToString();
                }
                else
                {
                    numcargoabono = p.Nro_Cargo.ToString(); ;
                }
                String evento = "ENVIO: Documento - TIPO: " + p.Indicator.ToString() + " - FOLIO: " + numcargoabono + " - ESTADO: Actualizado en ADM";

                log.addLog(" Respuesta Sap: " + responce.Replace("'", "") + " Tipo: " + p.Indicator.ToString() + " Folio: " + p.Nro_Cargo.ToString(), "OK", evento);

                frmain.listBoxLog.Items.Insert(0, evento);

                 System.Console.WriteLine("LA RESPUESTA  DE DOCUMENTO ES :" + responce);
            }

        }

        public void addPayments(frmMain frmain)
        {
            PaymentDb paymentdb = new PaymentDb();
            List<Payment> payments = new List<Payment>();
            Log log = new Log();
            consqlite = condbsqlite.getConectSqlite();
            payments = paymentdb.getComprobantePago();
            if(payments.Count == 0)
            {
                frmain.listBoxLog.Items.Insert(0, "No se encuentran mas Pagos");
            }
            foreach (Payment p in payments)
            {
                 
                string url = "http://"+consqlite.ip_sap+"" +
                    "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?" +
                    "wsaction=" +
                    "AddInPayment";
                string json = string.Empty;
                string cabecera = "{"
                              + "\"Payment\": {"
                              + "\"CardCode\": \"CF-" + (p.CardCode).Substring(0, 8) + "\","
                              + "\"DocDate\": \"" + String.Format("{0:yyyyMMdd}", p.DocDate) + "\","
                              + "\"CashSum\": \"" + p.CashSum +"\","
                              + "\"TransferAccount\": \""+p.TransferAccount+"\"," // TODO
                              + "\"TransferSum\": \""+p.TransferSum+"\"," // TODO
                              + "\"TransferDate\": \""+p.TransferDate+"\"," // TODO
                              + "\"TransferReference\": \""+p.TransferReference+"\"," // TODO
                              + "\"udf\": {"
                              + "\"U_SEI_CAJA\": \"1\","
                              + "\"U_SEI_CAJERO\": \"CAJ001\""
                              + "},"

                              + "\"Documents\": [";
                json += cabecera;
                int count = 0;
                string docssap = string.Empty;
                string llave = string.Empty;
                foreach(var docsap in p.documentsap)
                {
                    count += 1;

                      docssap  ="{" 
                               // +"\"BoObjectType\" : \""+ docsap.InvoiceType+"\","
                                +"\"DocEntry\": \""+ docsap.DocEntry +"\","
                             //   +"\"DocumentSubType\": \"--\","
                                +"\"SumApplied\": \""+ docsap.SumApplied+"\"";
               if(p.documentsap.Count > count)
                       {
                               llave =  "            },";
                       }
                       else
                       {
                                llave =  "            }";
                       }
               
               json += docssap + llave; 
                }



                String findocsap = "],"
                              + "\"Checks\": [";
                json += findocsap;

                int count2 = 0;
                string llave2 = string.Empty;
                foreach(var cheque in p.checks)
                {
                    count2 += 1;

                 String cheques = "{"
                                  + "\"DueDate\": \""+ String.Format("{0:yyyyMMdd}", cheque.DueDate) +"\","
                                  + "\"CheckNumber\": \""+ cheque.CheckNumber+"\","
                                  + "\"BankCode\": \""+ cheque.BankCode+"\","
                                  + "\"CheckSum\": \""+ cheque.CheckSum +"\"";
                if(p.checks.Count > count2) 
                       {
                               llave2 =  "            },";
                       }
                       else
                       {
                                llave2 =  "            }";
                       }
                
                json += cheques + llave2; 

                }
                String fincheques = "],"
                                     + "\"CreditCards\": [";
                json += fincheques;

                int count3 = 0;
                string llave3 = string.Empty;
                foreach (var tarjeta in p.creditcard)
                {
                    count3 += 1;

                    String tarjetas = "{"
                    +"\"CreditCard\": \""+tarjeta.CreditCard+"\"," // tipo de tarjeta TODO TABLAS DE PARIDAD
                    + "\"CreditCardNumber\": \""+ tarjeta.CreditCardNumber+"\","  //numero de tarjeta DEL CLIENTE 
                    + "\"CardValidUntil\": \"" + String.Format("{0:yyyyMMdd}", tarjeta.CardValidUntil) + "\"," // fecha vencimiento
                    + "\"CreditSum\": \""+ tarjeta.CreditSum + "\"," // Monto total de pàgo
                    + "\"VoucherNum\": \""+ tarjeta.VoucherNum +"\""; // numero de voucher
                    if (p.creditcard.Count > count3)
                    {
                        llave3 = " },";
                    }
                    else
                    {
                        llave3 = "}";
                    }

                    json += tarjetas + llave3;
                }
            String  finjson  =     "]"
                             +"}"
                             +"}";

                    json += finjson;
                
                Connect conn = new Connect();
                String responce = conn.HttpPOST(url, json);

                // Actualizo Recibo Adm
                paymentdb.updateReciboAdm(p.codEmpresa, p.codSucursalAbono, p.caja, p.tipoAbono, p.nroAbono);
                paymentdb.updateFormaPago(p);


                // cargo la respuesta
                respuesta.tipodete = p.tipoAbono.ToString();
                respuesta.folio = p.nroAbono.ToString();
                respuesta.tiporesp = "Pago";
                respuesta.json = json;
                respuesta.xml = responce.Replace("'", "");
                // agrego la respuesta
                respdb.addRespuesta(respuesta);

                // Agrego log
                String evento = "ENVIO: Pagos - TIPO DOC: " + respuesta.tipodete + " - FOLIO PAGO: " + respuesta.folio + " - ESTADO: " + respdb.extraeMensajeCliente(responce) + "";
                log.addLog("Respuesta Sap: " + responce.Replace("'", ""), "OK", evento);

                //Agrego list box
                frmain.listBoxLog.Items.Insert(0, evento);


                System.Console.WriteLine("LA RESPUESTA ES :" + responce);
            }

        
        }

        public void getProductos(string fecha, string intervalo, frmMain frmain)
        {

            string fechaS = fecha;
            string first = "1";
            int last = 0;
            consqlite = condbsqlite.getConectSqlite();
            string url = "http://"+consqlite.ip_sap+"" 
                        +"/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?" 
                        +"wsaction=" 
                        +"GetItemList";
            String jsonResponce = String.Empty;
            while (jsonResponce != "{\"rowCount\":\"0\",\"Items\":[]}")
            {
                last = last + Convert.ToInt32(intervalo);
                string json = "{ \"UpdateDate\": \"" + fechaS + "\","
                        + "\"first\": \"" + first + "\","
                        + "\"last\": \"" + last + "\""
                          + "} ";
                Connect conn = new Connect();

                String responce = conn.HttpPOST(url, json);
                System.Console.WriteLine("LA RESPUESTA ES :" + responce);
                ProductosDb productosdb = new ProductosDb();
                jsonResponce = respdb.extraeJsonProducto(responce);
                productosdb.upProdAdm(jsonResponcem, frmain);
            }
        }

        public void getInventarios()
        {
            consqlite = condbsqlite.getConectSqlite();
            string url = "http://"+consqlite.ip_sap+""
                        + "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?"
                        + "wsaction="
                        + "GetWhsInventory";
            string json = "{\"WhsCode\": \"B06\"," // TODO 
                          + "\"first\": \"1\","
                          + "\"last\": \"50\""
                          +"}";

            Connect conn = new Connect();
            String responce = conn.HttpPOST(url, json);
            System.Console.WriteLine("LA RESPUESTA ES :" + responce);
            ProductosDb productosdb = new ProductosDb();
            productosdb.upInvAdm(respdb.extraeJsonProducto(responce));
        }

        public void getPrecios()
        {
            consqlite = condbsqlite.getConectSqlite();
            string url = "http://"+consqlite.ip_sap+""
                        + "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?"
                        + "wsaction="
                        + "GetPriceList";
            string json = "{ \"UpdateDate\": \"20150106\","
            + "\"first\": \"3\","
            + "\"last\": \"4\""
              + "} ";

            Connect conn = new Connect();
            String responce = conn.HttpPOST(url, json);
            System.Console.WriteLine("LA RESPUESTA ES :" + responce);
            PreciosDb preciosdb = new PreciosDb();
            preciosdb.upPrecAdm(respdb.extraeJsonPrecios(responce));
        }

        public void addJournalEntry(frmMain frmain)
        {
            List<JournalEntry> jentries = new List<JournalEntry>();
            JournalEntryDb jentriesdb = new JournalEntryDb();
            jentries = jentriesdb.getjournalEntry();
            consqlite = condbsqlite.getConectSqlite();
            if (jentries.Count == 0)
            {
                frmain.listBoxLog.Items.Insert(0, "No se encuentran mas Ingresos o Egresos");
            }

            foreach (JournalEntry jentry in jentries)
            {
                string url = "http://" + consqlite.ip_sap + ""
                            + "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?"
                            + "wsaction="
                            + "AddJournalEntry";

                string json = "{\"JournalEntry\": { "
                            + "\"TaxDate\": \"" + String.Format("{0:yyyyMMdd}", jentry.TaxDate) + "\", " 
                            + "\"Amount\": \""+jentry.Amount+"\", "  
                            + "\"AccountC\": \""+jentry.AccountC+"\", "   
                            + "\"AccountD\": \""+jentry.AccountD+"\", "  
                            + "\"Reference2\":\""+jentry.Reference2+"\", "
                            + "\"Memo\": \""+jentry.Memo+"\", "
                           // + "\"udf\": { \"U_SEI_*\": \"0\" } "
                            + "}"
                            + "}";


                Connect conn = new Connect();
                String responce = conn.HttpPOST(url, json);
                System.Console.WriteLine("LA RESPUESTA ES :" + responce);

                //Udate ADM
                jentriesdb.updateJEntry(jentry.cod_empresa, jentry.cod_sucursal);
                
                // Agrego log
                String evento = "ENVIO: Ing/Egr - REFERENCIA: " + jentry.Reference2 + " - TIPO PAGO: " + jentry.tipo_pago.ToString() + " - ESTADO: " + respdb.extraeMensajeCliente(responce) +"";
                log.addLog("Respuesta Sap: " + responce.Replace("'",""), "OK",evento);

                //Agrego list box
                frmain.listBoxLog.Items.Insert(0, evento);

            }
        }



    }// FIN CLASE
}
