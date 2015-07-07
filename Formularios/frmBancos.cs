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
    public partial class frmBancos : Form
    {
        public frmBancos()
        {
            InitializeComponent();
        }

        private void bancosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bancosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._C__admtosap_DataB_sqliteDataSet);

        }

        private void frmBancos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla '_C__admtosap_DataB_sqliteDataSet.bancos' Puede moverla o quitarla según sea necesario.
            this.bancosTableAdapter.Fill(this._C__admtosap_DataB_sqliteDataSet.bancos);

        }
    }
}
