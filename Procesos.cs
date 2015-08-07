using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

                string url = consqlite.ip_sap + "AddBPartner";

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
                       + " \"SalesPersonCode\": \"" + p.SalesPersonCode + "\","
                       + " \"GroupCode\": \"102\"," // TODO pedir datos a adm
                    //   + " \"udf\": { \"U_SEI_*\": \"0\" }" campo opcional
                       + "}"
                       + "}";
               

                     Connect conn = new Connect();
                    String responce = conn.HttpPOST(url, json);
                    MensajeRespuesta msgResp = new MensajeRespuesta();


                    Console.WriteLine(url + json);
                    // recupero el mensaje
                    msgResp = respdb.extraeMensajeCliente(responce);
                    if (msgResp.errorMsg == "")
                    {
                        partnerdb.updateInAdm(p.codEmpresa, p.LicTradNum);
                        String evento = "ENVIO: Cliente - RUT: " + rut.Insert(8, "-") + " - NOMBRE: " + p.CardName + " - ESTADO: " + respdb.extraeMensajeCliente(responce) + "";
                        log.addLog("Respuesta Sap: " + responce.Replace("'", "") + "Rut Actualizado: " + rut.Insert(8, "-"), "OK", evento);
                        frmain.listBoxLog.Items.Insert(0, evento);

                    }
                    else
                    {
                        if (msgResp.errorMsg != "Error de conección")
                            partnerdb.updateInAdm(p.codEmpresa, p.LicTradNum);
                        String evento = "ENVIO: Cliente - RUT: " + rut.Insert(8, "-") + " - NOMBRE: " + p.CardName + " - ESTADO: Error de conección " + respdb.extraeMensajeCliente(responce) + "";
                        log.addLog("Respuesta Sap: " + responce.Replace("'", "") + "Rut Actualizado: " + rut.Insert(8, "-"), "Error", evento);
                        frmain.listBoxLog.Items.Insert(0, evento);
                    }
                    respuesta.tipodete = "0";
                    respuesta.folio = "0";
                    respuesta.tiporesp = "Nuevo Cliente: " + rut.Insert(8, "-") + "Nombre: " + p.CardName;
                    respuesta.xml = responce.Replace("'", "");
                    respuesta.json = json;
                    // agrego la respuesta
                    respdb.addRespuesta(respuesta);




                    // instanciar clase de envio adm que recibe una lista de respuestas
                    // un metodo de esta clase recorrera la lista de respuestas y las enviara a adm
                    System.Console.WriteLine("LA RESPUESTA ES :" + responce);
                }
                

        }

        public void addClientesBoleta( frmMain frmain,String rutClienteBoleta)
        {

            PartnerDb partnerdb = new PartnerDb();
            Partner clienteB = new Partner();
            Log log = new Log();
            consqlite = condbsqlite.getConectSqlite();
            clienteB =  partnerdb.getPartner(rutClienteBoleta);
                string url = consqlite.ip_sap + "AddBPartner";

                // agrega separador
                String rut = clienteB.LicTradNum;
                string json = "{"
                       + " \"BusinessPartner\": { "
                       + " \"CardCode\": \"CB-" + (rut).Substring(0, 8) + "\", " // falta el campo de adm
                       + " \"CardName\": \"" + clienteB.CardName + "\", "
                       + " \"LicTradNum\": \"" + rut.Insert(8, "-") + "\","
                       + " \"Notes\": \"" + clienteB.Notes + "\","
                       + " \"GroupNum\": \"" + clienteB.GroupNum + "\","
                       + " \"SlpCode\": \"" + clienteB.SlpCode + "\","
                       + " \"Street\": \"" + clienteB.Street + "\","
                       + " \"Block\": \"" + clienteB.Block + "\","
                       + " \"City\": \"" + clienteB.City + "\","
                       + " \"County\": \"" + clienteB.County + "\","
                       + " \"SalesPersonCode\": \"" + clienteB.SalesPersonCode + "\","
                       + " \"GroupCode\": \"102\"," // TODO pedir datos a adm
                    //   + " \"udf\": { \"U_SEI_*\": \"0\" }" campo opcional
                       + "}"
                       + "}";


                Connect conn = new Connect();
                String responce = conn.HttpPOST(url, json);
                MensajeRespuesta msgResp = new MensajeRespuesta();


                Console.WriteLine(url + json);
                // recupero el mensaje
                msgResp = respdb.extraeMensajeCliente(responce);
                if (msgResp.errorMsg == "")
                {
                    partnerdb.updateInAdm(clienteB.codEmpresa, clienteB.LicTradNum);
                    String evento = "ENVIO: Cliente - RUT: " + rut.Insert(8, "-") + " - NOMBRE: " + clienteB.CardName + " - ESTADO: " + respdb.extraeMensajeCliente(responce) + "";
                    log.addLog("Respuesta Sap: " + responce.Replace("'", "") + "Rut Actualizado: " + rut.Insert(8, "-"), "OK", evento);
                    frmain.listBoxLog.Items.Insert(0, evento);

                }
                else
                {
                    if (msgResp.errorMsg != "Error de conección")
                        partnerdb.updateInAdm(clienteB.codEmpresa, clienteB.LicTradNum);
                    String evento = "ENVIO: Cliente - RUT: " + rut.Insert(8, "-") + " - NOMBRE: " + clienteB.CardName + " - ESTADO: Error de conección " + respdb.extraeMensajeCliente(responce) + "";
                    log.addLog("Respuesta Sap: " + responce.Replace("'", "") + "Rut Actualizado: " + rut.Insert(8, "-"), "Error", evento);
                    frmain.listBoxLog.Items.Insert(0, evento);
                }
                respuesta.tipodete = "0";
                respuesta.folio = "0";
                respuesta.tiporesp = "Nuevo Cliente: " + rut.Insert(8, "-") + "Nombre: " + clienteB.CardName;
                respuesta.xml = responce.Replace("'", "");
                respuesta.json = json;
                // agrego la respuesta
                respdb.addRespuesta(respuesta);
                //
                System.Console.WriteLine("LA RESPUESTA ES :" + responce);
            

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
                string url = consqlite.ip_sap+"AddDocument";

                String carCodeCFIB = "CF-" +(p.CardCode).Substring(0, 8);


                if (p.CardCode == "000000000")
                    carCodeCFIB = docdb.getCardCode(p.Cod_Sucursal.ToString());
                if (p.CardCode != "000000000" && p.Tipo_Cargo == 7)
                {
                    addClientesBoleta(frmain, p.CardCode);
                    carCodeCFIB = "CB-" + (p.CardCode).Substring(0, 8);
                }
                String docDueDate = String.Empty;
                String discountPercent = String.Empty;
                String documentSubType = String.Empty;
                String docTotal = String.Empty;
                String indicator = String.Empty;


                if(p.Tipo_Cargo!=52){
                    docDueDate = "        \"DocDueDate\": \"" + String.Format("{0:yyyyMMdd}", p.DocDueDate) + "\", ";
                    discountPercent = "   \"DiscountPercent\": \"" + p.DiscountPercent + "\", ";
                    documentSubType = "   \"DocumentSubType\":\"" + p.DocumentSubType + "\", " ; // si es factura = --
                    docTotal= "        \"DocTotal\": \"" + p.DocTotal + "\", "  ;
                    indicator = "        \"Indicator\": \"" + p.Indicator + "\", ";
                    
                }

                String folioNumber = "        \"FolioNumber\": \"" + p.Nro_Cargo + "\", ";
                String U_SEI_INREF = String.Empty;
                String U_SEI_FOREF = String.Empty;
                String U_SEI_FEREF = String.Empty;
                String U_SEI_CREF = String.Empty;

                if(p.tipoAbono == 61)
                {
                    folioNumber = "        \"FolioNumber\": \"" + p.numAbono + "\", ";
                    U_SEI_INREF = "        ,\"U_SEI_INREF\": \"" + p.udf.U_SEI_INREF + "\", ";
                    U_SEI_FOREF = "        \"U_SEI_FOREF\": \"" + p.udf.U_SEI_FOREF + "\", ";
                    U_SEI_FEREF = "        \"U_SEI_FEREF\": \"" + p.udf.U_SEI_FEREF + "\", ";
                    U_SEI_CREF = "        \"U_SEI_CREF\": \"" + p.udf.U_SEI_CREF + "\" ";
                }
                
                string detalles = string.Empty;
                string json = string.Empty;
                string cabecerajson = "{"
                        + "        \"BoObjectType\":\""+p.BoObjectType+"\",  "
                        + "        \"Document\": { "
                        +          documentSubType
                        + "        \"CardCode\": \"" + carCodeCFIB + "\", " 
                        + "        \"DocDate\": \"" + String.Format("{0:yyyyMMdd}", p.DocDate) + "\", "
                        +           docDueDate 
                        + "        \"TaxDate\": \"" + String.Format("{0:yyyyMMdd}", p.TaxDate) + "\", "
                        + "        \"FromWarehouse\": \"" + p.FromWarehouse + "\", "
                        +           docTotal
                        + "        \"ToWarehouse\": \"" + p.ToWarehouse + "\", "
                        +          folioNumber
                        + "        \"FolioPrefixString\": \"" + p.FolioPrefixString + "\", "
                        +          discountPercent
                        + "        \"SalesPersonCode\": \"" + p.SalesPersonCode + "\","
                        +          indicator 
                        + "        \"udf\": {"
                        + "        \"U_SEI_FEBOSID\": \""+p.udf.U_SEI_FEBOSID+"\","
                        + "        \"U_SEI_CAJA\": \""+p.Caja+"\","
                        + "        \"U_SEI_CAJERO\": \"CAJA"+p.Caja+"\" "
                        +           U_SEI_INREF
                        +           U_SEI_FOREF
                        +           U_SEI_FEREF
                        +           U_SEI_CREF
                        + "         }, "
                        + "        \"Items\": "
                        + "         [ ";
                int count = 0;
                string llave = string.Empty;
                foreach(var det in p.items)
                {
                    String cOGSCostingCode = String.Empty;
                    String itemDescription = String.Empty;
                    String DiscountPercent = String.Empty;
                    String taxCode = String.Empty;
                    String warehouseCode = "                \"WarehouseCode\": \"" + det.ToWarehouse + "\",  ";

                    if (p.Tipo_Cargo != 52)
                    {
                        cOGSCostingCode = "                 \"COGSCostingCode\": \"" + convadmsap.codSucursal(p.Cod_Sucursal).ToString() + "\", ";// add transform
                        itemDescription = "                \"ItemDescription\": \"" + det.ItemDescription + "\",  ";
                        DiscountPercent = "                \"DiscountPercent\": \"" + det.DiscountPercent + "\"   ";
                        taxCode = "                       \"TaxCode\": \"IVA\", ";
                        warehouseCode = "                \"WarehouseCode\": \"" + det.WarehouseCode + "\",  ";
                    }

                    if (p.tipoAbono == 61)
                    {
                        cOGSCostingCode = "";
                        itemDescription = "                \"ItemDescription\": \"" + det.ItemDescription + "\",  ";
                        DiscountPercent = "                \"DiscountPercent\": \"" + det.DiscountPercent + "\" ";
                        warehouseCode = "                \"WarehouseCode\": \"" + det.WarehouseCode + "\",  ";
                    }


                   
                    count += 1;

                       string detallejson = "{"
                            //  + "                \"BaseEntry\" : \"0\"," // TODO 
                            //  + "                \"BaseType\" : \"0\"," // TODO 
                            //  + "                \"BaseLine\": \"0\","  // TODO
                           + "                \"ItemCode\": \"" + det.ItemCode + "\", "
                           + "                \"Quantity\": \"" + det.Quantity + "\", "
                           + "                \"UnitPrice\": \"" + det.UnitPrice + "\", "
                           +                  warehouseCode
                           +                  itemDescription
                            //+ "               \"GroupCode\": \"102\"," // TODO pedir datos a adm
                           + cOGSCostingCode
                           + taxCode
                           + DiscountPercent;
            
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
               Console.WriteLine("TIPO: {0} FOLIO: {1} RUT: {2} ", p.Tipo_Cargo + " | ", p.Nro_Cargo +" | ", p.CardCode +" | ");
             
                Connect conn = new Connect();
                String responce = conn.HttpPOST(url, json);
                //para hacer pruebas
                //String responce = "<?xml version=\"1.0\" encoding=\"utf-8\"?><?bpc.pltype.out xml?><?bpc.httpstatus.out 200?><JSONResponse>{\"Status\":{\"code\":\"success\",\"msg\":\"321\"}}</JSONResponse>";// ;

                MensajeRespuesta msg = new MensajeRespuesta();
                msg = respdb.extraeMensaje(responce.Replace("'", ""));
                
                // cargo los datos para el updateadm
                CabezalVentaAdm cvadm = new CabezalVentaAdm();
                cvadm.COD_EMPRESA = p.Cod_Empresa.ToString();
                cvadm.COD_SUCURSAL = p.Cod_Sucursal.ToString();
                cvadm.TIPO_CARGO = p.Tipo_Cargo.ToString();
                cvadm.NRO_CARGO = p.Nro_Cargo.ToString();
                cvadm.CAJA = p.Caja.ToString();
                cvadm.ID_SAP = msg.idSap;
                // Actualizo Adm si el json viene sin error
                if (msg.errorMsg == "")
                {
                    docdb.updateInAdm(cvadm);
                }
                // si el ducumento es una nota de credito
                if (p.tipoAbono.ToString() == "61" || p.tipoAbono.ToString() == "60" || p.tipoAbono.ToString() == "22")
                {
                    if (respdb.getMensajeError(responce) == -1)
                    {
                        docdb.updateCabezNCAdm(p.Cod_Empresa.ToString(), p.codSucursalAbono.ToString(), p.tipoAbono.ToString(), p.numAbono.ToString());
                    }
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

                String evento = String.Empty;

                if (respdb.getMensajeError(responce) == -1)
                {
                     evento = "ENVIO: Documento - TIPO: " + p.Indicator.ToString() + " - FOLIO: " + numcargoabono + " - ESTADO: Actualizado en ADM";
                }
                else
                {
                     evento = "ENVIO: Documento - TIPO: " + p.Indicator.ToString() + " - FOLIO: " + numcargoabono + " - ESTADO: Error de respuesta SAP " + responce;
                }
                
                log.addLog(" Respuesta Sap: " + responce.Replace("'", "") + " Tipo: " + p.Indicator.ToString() + " Folio: " + p.Nro_Cargo.ToString(), responce, evento);

                frmain.listBoxLog.Items.Insert(0, evento);

                 System.Console.WriteLine("LA RESPUESTA  DE DOCUMENTO ES :" + responce);
            }

        }

        public void addPayments(frmMain frmain)
        {
            PaymentDb paymentdb = new PaymentDb();
            List<Payment> payments = new List<Payment>();
            DocumentDb docdb = new DocumentDb();
            Log log = new Log();
            consqlite = condbsqlite.getConectSqlite();
            payments = paymentdb.getComprobantePago();
            if(payments.Count == 0)
            {
                frmain.listBoxLog.Items.Insert(0, "No se encuentran mas Pagos");
            }
            foreach (Payment p in payments)
            {
                 
                string url = consqlite.ip_sap+"AddInPayment";
                String carCodeCFIB = "CF-" + (p.CardCode).Substring(0, 8);


                if (p.CardCode == "000000000")
                {
                    carCodeCFIB = docdb.getCardCode(p.codSucursalAbono.ToString());
                }
                if (p.CardCode != "000000000" && p.tipoCargoAdm == 35)
                {
                    addClientesBoleta(frmain, p.CardCode);
                    carCodeCFIB = "CB-" + (p.CardCode).Substring(0, 8);
                }

                
                string json = string.Empty;
                string cabecera = "{"
                              + "\"Payment\": {"
                              + "\"CardCode\": \"" + carCodeCFIB + "\","
                              + "\"DocDate\": \"" + String.Format("{0:yyyyMMdd}", p.DocDate) + "\","
                              + "\"CashSum\": \"" + p.CashSum +"\","
                              + "\"CashAccount\": \"" + p.CashAccount + "\","
                              + "\"TransferAccount\": \""+p.TransferAccount+"\"," 
                              + "\"TransferSum\": \""+p.TransferSum+"\","
                              + "\"TransferDate\": \""+p.TransferDate+"\"," 
                              + "\"TransferReference\": \""+p.TransferReference+"\","
                              + "\"udf\": {"
                              + "\"U_SEI_CAJA\": \""+p.caja+"\","
                              + "\"U_SEI_CAJERO\": \" CAJA"+p.cajero+"\""
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
                               + "\"InvoiceType\" : \"" + docsap.InvoiceType + "\","
                                +"\"DocEntry\": \""+ docsap.DocEntry +"\","
                             // +"\"DocumentSubType\": \"--\","
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
                                  + "\"CheckAccount\": \"" + cheque.CheckAccount + "\","
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
                    + "\"CreditAcct\": \"" + tarjeta.CreditAcct + "\"," 
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

                    Console.WriteLine("CARDCODE: {0} DOCDATE: {1} ",p.CardCode +" | ",p.DocDate + " | ");
                
                    Connect conn = new Connect();
                    String responce = conn.HttpPOST(url, json);

                // Actualizo Recibo Adm
                if (respdb.getMensajeError(responce) == -1)
                {
                    paymentdb.updateReciboAdm(p.codEmpresa, p.codSucursalAbono, p.caja, p.tipoAbono, p.nroAbono);
                    paymentdb.updateFormaPago(p);
                }

                // cargo la respuesta
                respuesta.tipodete = p.tipoAbono.ToString();
                respuesta.folio = p.folioDte.ToString();
                respuesta.tiporesp = "Pago";
                respuesta.json = json;
                respuesta.xml = responce.Replace("'", "");
                // agrego la respuesta
                respdb.addRespuesta(respuesta);

                // Agrego log
                if (respdb.getMensajeError(responce) == -1)
                {
                    String evento = "ENVIO: Pagos - TIPO DOC: " + respuesta.tipodete + " - FOLIO PAGO: " + respuesta.folio + " - ESTADO: " + respdb.extraeMensajeCliente(responce) + " ";
                    log.addLog("Respuesta Sap: " + responce.Replace("'", ""), "OK", evento);

                    //Agrego list box
                    frmain.listBoxLog.Items.Insert(0, evento);
                }
                else
                {
                    String evento = "ENVIO: Pagos - TIPO DOC: " + respuesta.tipodete + " - FOLIO PAGO: " + respuesta.folio + " - ESTADO: " + respdb.extraeMensajeCliente(responce) + " ERROR";
                    log.addLog("Respuesta Sap: " + responce.Replace("'", ""), "ERROR", evento);

                    //Agrego list box
                    frmain.listBoxLog.Items.Insert(0, evento);
                }

                //System.Console.WriteLine("LA RESPUESTA ES :" + responce);
            }

        
        }

        public void getProductos(string fecha, string intervalo, frmMain frmain)
        {

            //TODO checkbox es nulo fecha es igual a ""
            string fechaS = fecha;
            int first = 0;
            int last = 0;
            consqlite = condbsqlite.getConectSqlite();
            string url = consqlite.ip_sap+"GetItemList";
            String jsonResponce = String.Empty;
            String j = "{\"rowCount\":\"\",\"Items\":[]}";

            while (jsonResponce !=  j)
            {
                last = last + Convert.ToInt32(intervalo);
                string json = "{ \"UpdateDate\": \"" + fechaS + "\","
                         + "\"first\": \"" + first + "\","
                        + "\"last\": \"" + last + "\""
                        + "} ";
                Connect conn = new Connect();

               // MessageBox.Show(first+" " +last);
                String responce = conn.HttpPOST(url, json);
               // MessageBox.Show(responce);
                ProductosDb productosdb = new ProductosDb();
                jsonResponce = respdb.extraeJsonProducto(responce);
                productosdb.insertProdAdm(jsonResponce, frmain);
                if (jsonResponce == "{\"rowCount\":\"\",\"Items\":[]}")
                {
                    frmain.listBoxLog.Items.Insert(0, "No se encuentran productos nuevos o modificados");
                }
                first = last;
            }
        }

        public void getInventarios(string intervalo, frmMain frmain)
        {
            String bodega = "BC15";
            int first = 0;
            int last = 0;

            consqlite = condbsqlite.getConectSqlite();
            string url = consqlite.ip_sap+"GetWhsInventory";

            String resposeJson = String.Empty;
            String j = "{\"rowCount\":\"0\",\"Items\":[]}";

            while (resposeJson != j)
            {
                last = last + Convert.ToInt32(intervalo);
                string json = "{\"WhsCode\": \"" + bodega + "\"," // TODO 
                          + "\"first\": \"" + first + "\","
                          + "\"last\": \"" + last + "\""
                          + "}";

                Connect conn = new Connect();
                String responce = conn.HttpPOST(url, json);
                System.Console.WriteLine("LA RESPUESTA ES :" + responce);
                ProductosDb productosdb = new ProductosDb();
                resposeJson = respdb.extraeJsonProducto(responce);
                if (resposeJson == "{\"rowCount\":\"0\",\"Items\":[]}")
                {
                    frmain.listBoxLog.Items.Insert(0, "No se encuentran productos");
                }
                productosdb.insertStock(resposeJson, frmain);

                first = last;
            }
            
        }

        public void getPrecios(string fecha,string intervalo, frmMain frmain)
        {
            int first = 1;
            int last = 0;
            consqlite = condbsqlite.getConectSqlite();
            string url = consqlite.ip_sap+"GetPriceList";
            string json = "{ \"UpdateDate\": \""+fecha+"\","
            + "\"first\": \""+first+"\","
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
                string url = consqlite.ip_sap +"AddJournalEntry";

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

        public void EnvioDiario(frmMain frmain)
        {
            this.addClientes(frmain);
            this.addDocuments(frmain);
            this.addPayments(frmain);
            this.addJournalEntry(frmain);

        }

  


    }// FIN CLASE
}
