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
            Procesos pro = new Procesos();
            pro.addDocuments();


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
            LocalDataBase ldb = new LocalDataBase();
            Temporizadores temp = new Temporizadores();

            ldb.creaDB();
            condb.getConnect();
            temp.startProcessClientes();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Procesos pro = new Procesos();
            pro.addClientes();
 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PartnerDb pdb = new PartnerDb();
            pdb.getPartners();
        }



        private void verLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLog frmlog = new frmLog();
            frmlog.Show();
        }

        private void documentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocumento formdoc = new frmDocumento();
            formdoc.Show();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Procesos poc = new Procesos();
            poc.AddPayments();
        }

        private void bodegasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBodegas frmbodegas = new frmBodegas();
            frmbodegas.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
