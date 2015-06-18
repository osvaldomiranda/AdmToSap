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
    public partial class frmBodegas : Form
    {
        public frmBodegas()
        {
            InitializeComponent();
        }

        private void bodegasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bodegasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._C__admtosap_DataB_sqliteDataSet);

        }

        private void frmBodegas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla '_C__admtosap_DataB_sqliteDataSet.bodegas' Puede moverla o quitarla según sea necesario.
            this.bodegasTableAdapter.Fill(this._C__admtosap_DataB_sqliteDataSet.bodegas);

        }
    }
}
