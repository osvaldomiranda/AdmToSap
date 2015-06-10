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
                    +"        \"CardCode\": \"CB-00000000\", "
                    +"        \"DocDate\": \"20150519\", "
                    +"        \"DocDueDate\": \"20150519\", "
                    +"        \"TaxDate\": \"20150519\", "
                    +"        \"FolioNumber\": \"17\", "
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
    }
}
