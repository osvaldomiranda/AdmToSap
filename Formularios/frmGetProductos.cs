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
    public partial class frmGetProductos : Form
    {
        public frmGetProductos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Procesos pro = new Procesos();
            DateTime datetime = dateTimePicker1.Value;
            pro.getProductos(String.Format("{0:yyyyMMdd}",datetime),textBox1.Text);

        }

        private void frmGetProductos_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
        }
    }
}
