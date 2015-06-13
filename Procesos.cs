using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdmToSap
{
    class Procesos
    {
        public void addClientes()
        {
            PartnerDb partnerdb = new PartnerDb();
            List<Partner> partners = new List<Partner>();
            List<String> responces = new List<String>();


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

                responces.Add(responce);
                // instanciar clase de envio adm que recibe una lista de respuestas
                // un metodo de esta clase recorrera la lista de respuestas y las enviara a adm
                System.Console.WriteLine("LA RESPUESTA ES :" + responce);
            }


            

        }
    }
}
