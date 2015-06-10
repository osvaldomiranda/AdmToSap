﻿using System;
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
            BancoDb bd = new BancoDb();
            bd.getBancos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PartnerDb pdb = new PartnerDb();
            pdb.getPartner();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PaymentDb pydb = new PaymentDb();
            pydb.getPayment();
        }
    }
}
