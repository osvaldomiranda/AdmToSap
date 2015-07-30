namespace AdmToSap
{
    partial class frmRespuestas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label tipodteLabel;
            System.Windows.Forms.Label folioLabel;
            System.Windows.Forms.Label mensajeLabel;
            System.Windows.Forms.Label tiporespLabel;
            System.Windows.Forms.Label xmlLabel;
            System.Windows.Forms.Label jsonLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRespuestas));
            this._C__admtosap_DataB_sqliteDataSet = new AdmToSap._C__admtosap_DataB_sqliteDataSet();
            this.respuestasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.respuestasTableAdapter = new AdmToSap._C__admtosap_DataB_sqliteDataSetTableAdapters.respuestasTableAdapter();
            this.tableAdapterManager = new AdmToSap._C__admtosap_DataB_sqliteDataSetTableAdapters.TableAdapterManager();
            this.respuestasBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fechaTextBox = new System.Windows.Forms.TextBox();
            this.tipodteTextBox = new System.Windows.Forms.TextBox();
            this.folioTextBox = new System.Windows.Forms.TextBox();
            this.mensajeTextBox = new System.Windows.Forms.TextBox();
            this.tiporespTextBox = new System.Windows.Forms.TextBox();
            this.xmlLabel1 = new System.Windows.Forms.Label();
            this.jsonRichTextBox = new System.Windows.Forms.RichTextBox();
            fechaLabel = new System.Windows.Forms.Label();
            tipodteLabel = new System.Windows.Forms.Label();
            folioLabel = new System.Windows.Forms.Label();
            mensajeLabel = new System.Windows.Forms.Label();
            tiporespLabel = new System.Windows.Forms.Label();
            xmlLabel = new System.Windows.Forms.Label();
            jsonLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._C__admtosap_DataB_sqliteDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.respuestasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.respuestasBindingNavigator)).BeginInit();
            this.respuestasBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(22, 56);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(37, 13);
            fechaLabel.TabIndex = 1;
            fechaLabel.Text = "fecha:";
            // 
            // tipodteLabel
            // 
            tipodteLabel.AutoSize = true;
            tipodteLabel.Location = new System.Drawing.Point(22, 82);
            tipodteLabel.Name = "tipodteLabel";
            tipodteLabel.Size = new System.Drawing.Size(31, 13);
            tipodteLabel.TabIndex = 3;
            tipodteLabel.Text = "Tipo:";
            // 
            // folioLabel
            // 
            folioLabel.AutoSize = true;
            folioLabel.Enabled = false;
            folioLabel.Location = new System.Drawing.Point(22, 108);
            folioLabel.Name = "folioLabel";
            folioLabel.Size = new System.Drawing.Size(47, 13);
            folioLabel.TabIndex = 5;
            folioLabel.Text = "Numero:";
            // 
            // mensajeLabel
            // 
            mensajeLabel.AutoSize = true;
            mensajeLabel.Location = new System.Drawing.Point(22, 134);
            mensajeLabel.Name = "mensajeLabel";
            mensajeLabel.Size = new System.Drawing.Size(49, 13);
            mensajeLabel.TabIndex = 7;
            mensajeLabel.Text = "mensaje:";
            // 
            // tiporespLabel
            // 
            tiporespLabel.AutoSize = true;
            tiporespLabel.Location = new System.Drawing.Point(22, 160);
            tiporespLabel.Name = "tiporespLabel";
            tiporespLabel.Size = new System.Drawing.Size(47, 13);
            tiporespLabel.TabIndex = 9;
            tiporespLabel.Text = "tiporesp:";
            // 
            // xmlLabel
            // 
            xmlLabel.AutoSize = true;
            xmlLabel.Location = new System.Drawing.Point(22, 191);
            xmlLabel.Name = "xmlLabel";
            xmlLabel.Size = new System.Drawing.Size(25, 13);
            xmlLabel.TabIndex = 11;
            xmlLabel.Text = "xml:";
            // 
            // jsonLabel
            // 
            jsonLabel.AutoSize = true;
            jsonLabel.Location = new System.Drawing.Point(22, 260);
            jsonLabel.Name = "jsonLabel";
            jsonLabel.Size = new System.Drawing.Size(29, 13);
            jsonLabel.TabIndex = 13;
            jsonLabel.Text = "json:";
            // 
            // _C__admtosap_DataB_sqliteDataSet
            // 
            this._C__admtosap_DataB_sqliteDataSet.DataSetName = "_C__admtosap_DataB_sqliteDataSet";
            this._C__admtosap_DataB_sqliteDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // respuestasBindingSource
            // 
            this.respuestasBindingSource.DataMember = "respuestas";
            this.respuestasBindingSource.DataSource = this._C__admtosap_DataB_sqliteDataSet;
            // 
            // respuestasTableAdapter
            // 
            this.respuestasTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.bancosTableAdapter = null;
            this.tableAdapterManager.bodegasTableAdapter = null;
            this.tableAdapterManager.connectdbTableAdapter = null;
            this.tableAdapterManager.documentoTableAdapter = null;
            this.tableAdapterManager.empresasTableAdapter = null;
            this.tableAdapterManager.logTableAdapter = null;
            this.tableAdapterManager.respuestasTableAdapter = this.respuestasTableAdapter;
            this.tableAdapterManager.sqlite_sequenceTableAdapter = null;
            this.tableAdapterManager.sucursalesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AdmToSap._C__admtosap_DataB_sqliteDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // respuestasBindingNavigator
            // 
            this.respuestasBindingNavigator.AddNewItem = null;
            this.respuestasBindingNavigator.BindingSource = this.respuestasBindingSource;
            this.respuestasBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.respuestasBindingNavigator.DeleteItem = null;
            this.respuestasBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.respuestasBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.respuestasBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.respuestasBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.respuestasBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.respuestasBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.respuestasBindingNavigator.Name = "respuestasBindingNavigator";
            this.respuestasBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.respuestasBindingNavigator.Size = new System.Drawing.Size(776, 25);
            this.respuestasBindingNavigator.TabIndex = 0;
            this.respuestasBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // fechaTextBox
            // 
            this.fechaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.respuestasBindingSource, "fecha", true));
            this.fechaTextBox.Location = new System.Drawing.Point(77, 53);
            this.fechaTextBox.Name = "fechaTextBox";
            this.fechaTextBox.Size = new System.Drawing.Size(182, 20);
            this.fechaTextBox.TabIndex = 2;
            // 
            // tipodteTextBox
            // 
            this.tipodteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.respuestasBindingSource, "tipodte", true));
            this.tipodteTextBox.Location = new System.Drawing.Point(77, 79);
            this.tipodteTextBox.Name = "tipodteTextBox";
            this.tipodteTextBox.Size = new System.Drawing.Size(66, 20);
            this.tipodteTextBox.TabIndex = 4;
            // 
            // folioTextBox
            // 
            this.folioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.respuestasBindingSource, "folio", true));
            this.folioTextBox.Location = new System.Drawing.Point(77, 105);
            this.folioTextBox.Name = "folioTextBox";
            this.folioTextBox.Size = new System.Drawing.Size(66, 20);
            this.folioTextBox.TabIndex = 6;
            // 
            // mensajeTextBox
            // 
            this.mensajeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.respuestasBindingSource, "mensaje", true));
            this.mensajeTextBox.Location = new System.Drawing.Point(77, 131);
            this.mensajeTextBox.Name = "mensajeTextBox";
            this.mensajeTextBox.Size = new System.Drawing.Size(112, 20);
            this.mensajeTextBox.TabIndex = 8;
            // 
            // tiporespTextBox
            // 
            this.tiporespTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.respuestasBindingSource, "tiporesp", true));
            this.tiporespTextBox.Location = new System.Drawing.Point(77, 157);
            this.tiporespTextBox.Name = "tiporespTextBox";
            this.tiporespTextBox.Size = new System.Drawing.Size(239, 20);
            this.tiporespTextBox.TabIndex = 10;
            // 
            // xmlLabel1
            // 
            this.xmlLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.respuestasBindingSource, "xml", true));
            this.xmlLabel1.Location = new System.Drawing.Point(74, 191);
            this.xmlLabel1.Name = "xmlLabel1";
            this.xmlLabel1.Size = new System.Drawing.Size(681, 53);
            this.xmlLabel1.TabIndex = 12;
            this.xmlLabel1.Text = "label1";
            // 
            // jsonRichTextBox
            // 
            this.jsonRichTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.respuestasBindingSource, "json", true));
            this.jsonRichTextBox.Location = new System.Drawing.Point(77, 260);
            this.jsonRichTextBox.Name = "jsonRichTextBox";
            this.jsonRichTextBox.Size = new System.Drawing.Size(678, 96);
            this.jsonRichTextBox.TabIndex = 14;
            this.jsonRichTextBox.Text = "";
            // 
            // frmRespuestas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 425);
            this.Controls.Add(jsonLabel);
            this.Controls.Add(this.jsonRichTextBox);
            this.Controls.Add(xmlLabel);
            this.Controls.Add(this.xmlLabel1);
            this.Controls.Add(fechaLabel);
            this.Controls.Add(this.fechaTextBox);
            this.Controls.Add(tipodteLabel);
            this.Controls.Add(this.tipodteTextBox);
            this.Controls.Add(folioLabel);
            this.Controls.Add(this.folioTextBox);
            this.Controls.Add(mensajeLabel);
            this.Controls.Add(this.mensajeTextBox);
            this.Controls.Add(tiporespLabel);
            this.Controls.Add(this.tiporespTextBox);
            this.Controls.Add(this.respuestasBindingNavigator);
            this.Name = "frmRespuestas";
            this.Text = "frmRespuestas";
            this.Load += new System.EventHandler(this.frmRespuestas_Load);
            ((System.ComponentModel.ISupportInitialize)(this._C__admtosap_DataB_sqliteDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.respuestasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.respuestasBindingNavigator)).EndInit();
            this.respuestasBindingNavigator.ResumeLayout(false);
            this.respuestasBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private _C__admtosap_DataB_sqliteDataSet _C__admtosap_DataB_sqliteDataSet;
        private System.Windows.Forms.BindingSource respuestasBindingSource;
        private _C__admtosap_DataB_sqliteDataSetTableAdapters.respuestasTableAdapter respuestasTableAdapter;
        private _C__admtosap_DataB_sqliteDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator respuestasBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox fechaTextBox;
        private System.Windows.Forms.TextBox tipodteTextBox;
        private System.Windows.Forms.TextBox folioTextBox;
        private System.Windows.Forms.TextBox mensajeTextBox;
        private System.Windows.Forms.TextBox tiporespTextBox;
        private System.Windows.Forms.Label xmlLabel1;
        private System.Windows.Forms.RichTextBox jsonRichTextBox;

    }
}