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
        

        public void addClientes()
        {
            PartnerDb partnerdb = new PartnerDb();
            List<Partner> partners = new List<Partner>();
            Log log = new Log();


            partners = partnerdb.getPartners();

            foreach (Partner p in partners)
            {
                string url = "http://192.168.100.43:8080" +
         "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?" +
         "wsaction=" +
         "AddBPartner";
                // agrega separador
                String rut = p.LicTradNum;
                string json = "{"
                       + " \"BusinessPartner\": { "
                       + " \"CardCode\": \"CF-" + (rut).Substring(1,7) + "\", " // falta el campo de adm
                       + " \"CardName\": \"" + p.CardName + "\", "
                       + " \"LicTradNum\": \"" + rut.Insert(8,"-") + "\","
                       + " \"Notes\": \"" + p.Notes + "\","
                       + " \"GroupNum\": \"" + p.GroupNum + "\","
                       + " \"SlpCode\": \"" + p.SlpCode + "\","
                       + " \"Street\": \"" + p.Street + "\","
                       + " \"Block\": \"" + p.Block + "\","
                       + " \"City\": \"" + p.City + "\","
                       + " \"County\": \"" + p.County + "\","
                       + " \"Country\": \"" + p.Country + "\","
                    //   + " \"udf\": { \"U_SEI_*\": \"0\" }" campo opcional
                       + "}"
                       + "}";

                Connect conn = new Connect();
                String responce = conn.HttpPOST(url, json);

                partnerdb.updateInAdm(p.codEmpresa, p.LicTradNum);

                log.addLog("Respuesta Sap: " + responce.Replace("'","") + "Rut Actualizado: " + rut.Insert(8, "-"), "OK");

                // instanciar clase de envio adm que recibe una lista de respuestas
                // un metodo de esta clase recorrera la lista de respuestas y las enviara a adm
                System.Console.WriteLine("LA RESPUESTA ES :" + responce);
            }

        }

        public void addDocuments()
        {
            
            DocumentDb docdb = new DocumentDb();
            List<Document> documents = new List<Document>();
            Log log = new Log();
            ConvertAdmSap convadmsap = new ConvertAdmSap();

            documents = docdb.getDocuments();

            foreach (Document p in documents)
            {
                string url = "http://192.168.100.43:8080" +
                    "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?" +
                    "wsaction=" +
                    "AddDocument";

                string detalles = string.Empty;
                string json = string.Empty;
                string cabecerajson = "{"
                        + "        \"BoObjectType\":\""+p.BoObjectType+"\",  "
                        + "        \"Document\": { "
                        + "        \"DocumentSubType\":\"" + p.DocumentSubType + "\", "  // si es factura = --
                        + "        \"CardCode\": \"CF-" + (p.CardCode).Substring(1, 7) + "\", "
                        + "        \"DocDate\": \"" + String.Format("{0:yyyyMMdd}", p.DocDate) + "\", "
                        + "        \"DocDueDate\": \"" + String.Format("{0:yyyyMMdd}", p.DocDueDate) + "\", "
                        + "        \"TaxDate\": \"" + String.Format("{0:yyyyMMdd}", p.TaxDate) + "\", "
                        + "        \"FolioNumber\": \"" + p.Nro_Fiscal + "\", "
                        + "        \"FolioPrefixString\": \"" + p.FolioPrefixString + "\", "
                        + "        \"DiscountPercent\": \"" + p.DiscountPercent + "\", "
                        + "        \"Indicator\": \"" + p.Indicator + "\", "
                        + "        \"COGSCostingCode\": \"" + p.COGSCostingCode + "\", "
                        + "        \"udf\": {\"U_SEI_FEBOSID\": \""+p.udf.U_SEI_FEBOSID+"\"}, "
                        + "        \"Items\": "
                        + "         [ ";
                int count = 0;
                string llave = string.Empty;
                foreach(var det in p.items)
                {
                    count += 1;
                    string detallejson = "{"
                       //    + "                \"BaseEntry\" : \"0\"," // TODO 
                       //    + "                \"BaseType\" : \"0\"," // TODO 
	                   //   + "                \"BaseLine\": \"0\","  // TODO
                           + "                \"ItemCode\": \"" + det.ItemCode + "\", "
                           + "                \"Quantity\": \"" + det.Quantity + "\", "
                           + "                \"UnitPrice\": \"" + det.UnitPrice + "\", "
                           + "                \"WarehouseCode\": \"" + det.WarehouseCode + "\",  "
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
                if (p.tipoAbono.ToString() == "61" || p.tipoAbono.ToString() == "60")
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

                log.addLog(" Respuesta Sap: " + responce.Replace("'", "") + " Tipo: " + p.Indicator.ToString() + " Folio: " + p.Nro_Cargo.ToString(), "OK");


                System.Console.WriteLine("LA RESPUESTA  DE DOCUMENTO ES :" + responce);
            }

        }

        public void addPayments()
        {
            PaymentDb paymentdb = new PaymentDb();
            List<Payment> payments = new List<Payment>();
            Log log = new Log();

            payments = paymentdb.getComprobantePago();

            foreach (Payment p in payments)
            {
                 
                string url = "http://192.168.100.43:8080" +
                    "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?" +
                    "wsaction=" +
                    "AddInPayment";
                string json = string.Empty;
                string cabecera = "{"
                              + "\"Payment\": {"
                              + "\"CardCode\": \"CF-" + (p.CardCode).Substring(1, 7) + "\","
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
                    +"\"CreditCard\": \""+tarjeta.CreditCard+"\"," // tipo de tarjeta
                    + "\"CreditCardNumber\": \""+ tarjeta.CreditCardNumber+"\","  //numero de tarjeta
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


                System.Console.WriteLine("LA RESPUESTA ES :" + responce);
            }

        
        }

        public void getProductos()
        {
            string url = "http://192.168.100.43:8080" 
                        +"/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?" 
                        +"wsaction=" 
                        +"GetItemList";
            string json = "{ \"UpdateDate\": \"20150101\","
                        + "\"first\": \"20\","
                        + "\"last\": \"40\""
                          +"} ";

            Connect conn = new Connect();  
            String responce = conn.HttpPOST(url, json);
            System.Console.WriteLine("LA RESPUESTA ES :" + responce);
            ProductosDb productosdb = new ProductosDb();
            productosdb.upProdAdm(respdb.extraeJsonProducto(responce));
        }

        public void getInventarios()
        {
            string url = "http://192.168.100.43:8080"
                        + "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?"
                        + "wsaction="
                        + "GetWhsInventory";
            string json = "{\"WhsCode\": \"B06\","
                          + "\"first\": \"20\","
                          + "\"last\": \"40\""
                          +"}";

            Connect conn = new Connect();
            String responce = conn.HttpPOST(url, json);
            System.Console.WriteLine("LA RESPUESTA ES :" + responce);
        }

        public void getPrecios()
        {
            string url = "http://192.168.100.43:8080"
                        + "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?"
                        + "wsaction="
                        + "GetPriceList";
            string json = "{}";

            Connect conn = new Connect();
            String responce = conn.HttpPOST(url, json);
            System.Console.WriteLine("LA RESPUESTA ES :" + responce);
        }

        public void addJournalEntry()
        {
            string url = "http://192.168.100.43:8080"
                        + "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?"
                        + "wsaction="
                        + "AddJournalEntry";
            string json = "{\"JournalEntry\": { "
                        + "\"TaxDate\": \"20150702\", "
                        + "\"Amount\": \"5000\", "
                        + "\"AccountC\": \"110401002\", "   //cuentas credito de cotillón
                        + "\"AccountD\": \"110401002\", "   //cuentas credito de cotillón
                        + "\"Reference2\":\"Para probar referncia 2\", "  
                        + "\"Memo\": \"Para probar Memo \", "
                       // + "\"udf\": { \"U_SEI_*\": \"0\" } "
                        + "}"
                        + "}";

            Connect conn = new Connect();
            String responce = conn.HttpPOST(url, json);
            System.Console.WriteLine("LA RESPUESTA ES :" + responce);
        }


    }// FIN CLASE
}
