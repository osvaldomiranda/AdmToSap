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
    public partial class frmDocumento : Form
    {
        public frmDocumento()
        {
            InitializeComponent();
        }

        private void documentoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.documentoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._C__admtosap_DataB_sqliteDataSet);

        }

        private void frmDocumento_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla '_C__admtosap_DataB_sqliteDataSet.documento' Puede moverla o quitarla según sea necesario.
            this.documentoTableAdapter.Fill(this._C__admtosap_DataB_sqliteDataSet.documento);

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }
    }
}
