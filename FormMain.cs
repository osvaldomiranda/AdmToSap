using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdmToSap
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string url = "http://192.168.100.43:8080" +
                "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?"+
                "wsaction="+
                "AddDocument";

            string json = "{"
                    +"        \"BoObjectType\":\"13\",  "
                    +"        \"Document\": { "
                    +"        \"DocumentSubType\":\"--\", "
                    + "        \"CardCode\": \"C9999999-9-001\", "
                    +"        \"DocDate\": \"20150611\", "
                    +"        \"DocDueDate\": \"20150611\", "
                    +"        \"TaxDate\": \"20150611\", "
                    +"        \"FolioNumber\": \"18\", "
                    +"        \"FolioPrefixString\": \"33\", "
                    +"        \"DiscountPercent\": \"0.000000\", "
                    +"        \"Indicator\": \"33\", "
                    +"        \"Items\": "
                    +"         [ "
                    +"            { "
                    +"                \"ItemCode\": \"15140\", "
                    +"                \"Quantity\": \"1\", "
                    +"                \"UnitPrice\": \"5.0\", "
                    +"                \"WarehouseCode\": \"B06\",  "
                    +"                \"TaxCode\": \"IVA\", "
                    +"                \"DiscountPercent\": \"0.000000\" "
                    +"            }"
                    +"        ]"
                    +"    }"
                    +"}";

            Connect conn = new Connect();
            String responce = conn.HttpPOST(url, json);

            System.Console.WriteLine("LA RESPUESTA ES :" + responce);

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void baseDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaseDato frmbd = new frmBaseDato();
            frmbd.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ConnectDb condb = new ConnectDb();
            condb.getConnect();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PartnerDb partnerdb = new PartnerDb();
            List<Partner> partners = new List<Partner>();
            List<String> responces = new List<String>();


            partners = partnerdb.getPartners();
           
            foreach(Partner p in partners)
            {
                string url = "http://192.168.100.43:8080" +
         "/B1iXcellerator/exec/ipo/vP.0010000105.in_HCSX/com.sap.b1i.vplatform.runtime/INB_HT_CALL_SYNC_XPT/INB_HT_CALL_SYNC_XPT.ipo/proc?" +
         "wsaction=" +
         "AddBPartner";
                // agrega separador
                String rut = p.LicTradNum;
                String separador = rut.Insert(8,"-");
                string json = "{"
                       + " \"BusinessPartner\": { "
                       + " \"CardCode\": \""+p.CardCode+"\", "
                       + " \"CardName\": \""+p.CardName+"\", "
                       + " \"LicTradNum\": \""+separador+"\","
                       + " \"Notes\": \""+p.Notes+"\","
                       + " \"GroupNum\": \""+p.GroupNum+"\","
                       + " \"SlpCode\": \""+p.SlpCode+"\","
                       + " \"Street\": \""+p.Street+"\","
                       + " \"Block\": \""+p.Block+"\","
                       + " \"City\": \""+p.City+"\","
                       + " \"County\": \""+p.County+"\","
                       + " \"Country\": \""+p.Country+"\","
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

        private void button3_Click(object sender, EventArgs e)
        {
            PartnerDb pdb = new PartnerDb();
            pdb.getPartners();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PaymentDb pydb = new PaymentDb();
            pydb.getPayment();
        }
    }
}
