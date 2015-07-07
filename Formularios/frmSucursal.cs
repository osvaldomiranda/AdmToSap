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
    public partial class frmSucursal : Form
    {
        public frmSucursal()
        {
            InitializeComponent();
        }

        private void empresasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.empresasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._C__admtosap_DataB_sqliteDataSet);

        }

        private void empresasBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.empresasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._C__admtosap_DataB_sqliteDataSet);

        }

        private void frmSucursal_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla '_C__admtosap_DataB_sqliteDataSet.empresas' Puede moverla o quitarla según sea necesario.
            this.empresasTableAdapter.Fill(this._C__admtosap_DataB_sqliteDataSet.empresas);

        }
    }
}
