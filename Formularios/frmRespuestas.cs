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
    public partial class frmRespuestas : Form
    {
        public frmRespuestas()
        {
            InitializeComponent();
        }

        private void respuestasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.respuestasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._C__admtosap_DataB_sqliteDataSet);

        }

        private void respuestasBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.respuestasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._C__admtosap_DataB_sqliteDataSet);

        }

        private void frmRespuestas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla '_C__admtosap_DataB_sqliteDataSet.respuestas' Puede moverla o quitarla según sea necesario.
            this.respuestasTableAdapter.Fill(this._C__admtosap_DataB_sqliteDataSet.respuestas);

        }
    }
}
