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
                "GetPriceList";

            string json = "hola";

            Connect conn = new Connect();
            String responce = conn.HttpPOST(url, json);

            System.Console.WriteLine("LA RESPUESTA ES :" + responce);

        }
    }
}
