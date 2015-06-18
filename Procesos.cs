using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdmToSap
{
    class Procesos
    {
        Log log = new Log();

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
                        + "        \"BoObjectType\":\"13\",  "
                        + "        \"Document\": { "
                        + "        \"DocumentSubType\":\"--\", "       // si es factura = --
                        + "        \"CardCode\": \"CF-" + (p.CardCode).Substring(1, 7) + "\", "
                        + "        \"DocDate\": \"" + String.Format("{0:yyyyMMdd}", p.DocDate) + "\", "
                        + "        \"DocDueDate\": \"" + String.Format("{0:yyyyMMdd}", p.DocDueDate) + "\", "
                        + "        \"TaxDate\": \"" + String.Format("{0:yyyyMMdd}", p.TaxDate) + "\", "
                        + "        \"FolioNumber\": \"" + p.Nro_Cargo + "\", "
                        + "        \"FolioPrefixString\": \"" + p.Tipo_Cargo + "\", "
                        + "        \"DiscountPercent\": \"" + p.DiscountPercent + "\", "
                        + "        \"Indicator\": \"" + p.Tipo_Cargo + "\", "
                        + "        \"Items\": "
                        + "         [ ";
                int count = 0;
                string llave = string.Empty;
                foreach(var det in p.items)
                {
                    count += 1;
                    string detallejson = "{"
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

                docdb.updateInAdm(p.Cod_Empresa.ToString(), p.Cod_Sucursal.ToString(), p.Tipo_Cargo.ToString(), p.Nro_Cargo.ToString(), p.Caja.ToString());

                log.addLog(" Respuesta Sap: " + responce.Replace("'", "") + " Tipo: " + p.Tipo_Cargo.ToString() + " Folio: " + p.Nro_Cargo.ToString(), "OK");

                System.Console.WriteLine("LA RESPUESTA ES :" + responce);
            }

        }

        public void AddPayments()
        {
            PaymentDb paymentdb = new PaymentDb();
            List<Payment> payments = new List<Payment>();
            Log log = new Log();

            payments = paymentdb.getCabezalDoc();

            foreach (Payment p in payments)
            {
                string url = "http://192.168.100.43:8080" +
                    "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?" +
                    "wsaction=" +
                    "AddPayment";

                string json = "{"
                              +"\"Payment\": {"
                              +"\"CardCode\": \"C00099210-0\","
                              +"\"DocDueDate\": \"20130617\","
                              +"\"CashSum\": \"188135.000000\","
                              +"\"TransferAccount\": \"1-1-010-10-001\","
                              +"\"TransferSum\": \"50.000000\","
                              +"\"TransferDate\": \"20130524\","
                              +"\"TransferReference\": \"123456\","
                              
                              +"\"udf\": {" 
                              +"\"U_SEI_CAJA\": \"1\","
                              +"\"U_SEI_CAJERO\": \"CAJ001\"," 
                              +"},"

                              +"\"Documents\": ["
                                +"{" 
                                +"\"BoObjectType\" : \"13\""
                                +"\"DocEntry\": \"8\","
                                +"\"DocumentSubType\": \"bod_None\","
                                +"\"SumApplied\": \"13002.000000\","
                              +"},"

                              +"],"
                              +"\"Checks\": ["
                               +"{"
                               +"\"DueDate\": \"20130624\","
                               +"\"CheckNumber\": \"1\","
                               +"\"BankCode\": \"001\","
                               +"\"CheckSum\": \"2000.000000\","
                               +"}"
                              +"],"
                              
                              +"\"CreditCards\": ["
                                +"{" 
                                 +"\"CreditCard\": \"1\"," 
                                 +"\"CreditCardNumber\": \"678\"," 
                                 +"\"CardValidUntil\": \"20141231\"," 
                                 +"\"CreditSum\": \"900.000000\"," 
                                 +"\"VoucherNum\": \"1234\""
                                +"},"
                              +"],"
                             +"}"
                             +"}";

                Connect conn = new Connect();
                String responce = conn.HttpPOST(url, json);

                System.Console.WriteLine("LA RESPUESTA ES :" + responce);
            }

        
        }




    }// FIN CLASE
}
