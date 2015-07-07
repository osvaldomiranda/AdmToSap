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
    public partial class frmEmpresa : Form
    {
        public frmEmpresa()
        {
            InitializeComponent();
        }

        private void empresasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.empresasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cotillonDataSet);

        }

        private void frmEmpresa_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cotillonDataSet.sucursales' Puede moverla o quitarla según sea necesario.
            this.sucursalesTableAdapter.Fill(this.cotillonDataSet.sucursales);
            // TODO: esta línea de código carga datos en la tabla 'cotillonDataSet.empresas' Puede moverla o quitarla según sea necesario.
            this.empresasTableAdapter.Fill(this.cotillonDataSet.empresas);

        }

        private void cOD_EMPRESATextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSucursal frmsucur = new frmSucursal();
            frmsucur.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmpresaDb empresadb = new EmpresaDb();
            empresadb.updateEmpresa(Convert.ToInt32(cOD_EMPRESATextBox.Text),r_SOCIALTextBox.Text,Convert.ToInt32(cOD_SUCURSALTextBox.Text),nOMBRETextBox.Text);
        }
    }
}
