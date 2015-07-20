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
    public partial class frmLog : Form
    {
        public frmLog()
        {
            InitializeComponent();
        }

        private void logBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.logBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._C__admtosap_DataB_sqliteDataSet);

        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla '_C__admtosap_DataB_sqliteDataSet.log' Puede moverla o quitarla según sea necesario.
            this.logTableAdapter.Fill(this._C__admtosap_DataB_sqliteDataSet.log);

        }

        private void eventoLabel_Click(object sender, EventArgs e)
        {

        }

        private void eventoLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
