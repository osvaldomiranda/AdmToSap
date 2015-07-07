namespace AdmToSap
{
    partial class frmSucursal
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
            System.Windows.Forms.Label cod_empresaLabel;
            System.Windows.Forms.Label nom_empresaLabel;
            System.Windows.Forms.Label cod_sucursalLabel;
            System.Windows.Forms.Label nom_sucursalLabel;
            this._C__admtosap_DataB_sqliteDataSet = new AdmToSap._C__admtosap_DataB_sqliteDataSet();
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empresasTableAdapter = new AdmToSap._C__admtosap_DataB_sqliteDataSetTableAdapters.empresasTableAdapter();
            this.tableAdapterManager = new AdmToSap._C__admtosap_DataB_sqliteDataSetTableAdapters.TableAdapterManager();
            this.cod_empresaLabel1 = new System.Windows.Forms.Label();
            this.nom_empresaLabel1 = new System.Windows.Forms.Label();
            this.cod_sucursalLabel1 = new System.Windows.Forms.Label();
            this.nom_sucursalLabel1 = new System.Windows.Forms.Label();
            cod_empresaLabel = new System.Windows.Forms.Label();
            nom_empresaLabel = new System.Windows.Forms.Label();
            cod_sucursalLabel = new System.Windows.Forms.Label();
            nom_sucursalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._C__admtosap_DataB_sqliteDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _C__admtosap_DataB_sqliteDataSet
            // 
            this._C__admtosap_DataB_sqliteDataSet.DataSetName = "_C__admtosap_DataB_sqliteDataSet";
            this._C__admtosap_DataB_sqliteDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // empresasBindingSource
            // 
            this.empresasBindingSource.DataMember = "empresas";
            this.empresasBindingSource.DataSource = this._C__admtosap_DataB_sqliteDataSet;
            // 
            // empresasTableAdapter
            // 
            this.empresasTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.bodegasTableAdapter = null;
            this.tableAdapterManager.connectdbTableAdapter = null;
            this.tableAdapterManager.documentoTableAdapter = null;
            this.tableAdapterManager.empresasTableAdapter = this.empresasTableAdapter;
            this.tableAdapterManager.logTableAdapter = null;
            this.tableAdapterManager.sqlite_sequenceTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AdmToSap._C__admtosap_DataB_sqliteDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cod_empresaLabel
            // 
            cod_empresaLabel.AutoSize = true;
            cod_empresaLabel.Location = new System.Drawing.Point(19, 29);
            cod_empresaLabel.Name = "cod_empresaLabel";
            cod_empresaLabel.Size = new System.Drawing.Size(71, 13);
            cod_empresaLabel.TabIndex = 1;
            cod_empresaLabel.Text = "cod empresa:";
            // 
            // cod_empresaLabel1
            // 
            this.cod_empresaLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empresasBindingSource, "cod_empresa", true));
            this.cod_empresaLabel1.Location = new System.Drawing.Point(109, 30);
            this.cod_empresaLabel1.Name = "cod_empresaLabel1";
            this.cod_empresaLabel1.Size = new System.Drawing.Size(399, 23);
            this.cod_empresaLabel1.TabIndex = 2;
            this.cod_empresaLabel1.Text = "label1";
            // 
            // nom_empresaLabel
            // 
            nom_empresaLabel.AutoSize = true;
            nom_empresaLabel.Location = new System.Drawing.Point(20, 72);
            nom_empresaLabel.Name = "nom_empresaLabel";
            nom_empresaLabel.Size = new System.Drawing.Size(73, 13);
            nom_empresaLabel.TabIndex = 3;
            nom_empresaLabel.Text = "nom empresa:";
            // 
            // nom_empresaLabel1
            // 
            this.nom_empresaLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empresasBindingSource, "nom_empresa", true));
            this.nom_empresaLabel1.Location = new System.Drawing.Point(104, 72);
            this.nom_empresaLabel1.Name = "nom_empresaLabel1";
            this.nom_empresaLabel1.Size = new System.Drawing.Size(422, 23);
            this.nom_empresaLabel1.TabIndex = 4;
            this.nom_empresaLabel1.Text = "label1";
            // 
            // cod_sucursalLabel
            // 
            cod_sucursalLabel.AutoSize = true;
            cod_sucursalLabel.Location = new System.Drawing.Point(20, 124);
            cod_sucursalLabel.Name = "cod_sucursalLabel";
            cod_sucursalLabel.Size = new System.Drawing.Size(70, 13);
            cod_sucursalLabel.TabIndex = 5;
            cod_sucursalLabel.Text = "cod sucursal:";
            // 
            // cod_sucursalLabel1
            // 
            this.cod_sucursalLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empresasBindingSource, "cod_sucursal", true));
            this.cod_sucursalLabel1.Location = new System.Drawing.Point(96, 124);
            this.cod_sucursalLabel1.Name = "cod_sucursalLabel1";
            this.cod_sucursalLabel1.Size = new System.Drawing.Size(430, 23);
            this.cod_sucursalLabel1.TabIndex = 6;
            this.cod_sucursalLabel1.Text = "label1";
            // 
            // nom_sucursalLabel
            // 
            nom_sucursalLabel.AutoSize = true;
            nom_sucursalLabel.Location = new System.Drawing.Point(15, 181);
            nom_sucursalLabel.Name = "nom_sucursalLabel";
            nom_sucursalLabel.Size = new System.Drawing.Size(72, 13);
            nom_sucursalLabel.TabIndex = 7;
            nom_sucursalLabel.Text = "nom sucursal:";
            // 
            // nom_sucursalLabel1
            // 
            this.nom_sucursalLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empresasBindingSource, "nom_sucursal", true));
            this.nom_sucursalLabel1.Location = new System.Drawing.Point(93, 181);
            this.nom_sucursalLabel1.Name = "nom_sucursalLabel1";
            this.nom_sucursalLabel1.Size = new System.Drawing.Size(433, 23);
            this.nom_sucursalLabel1.TabIndex = 8;
            this.nom_sucursalLabel1.Text = "label1";
            // 
            // frmSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 273);
            this.Controls.Add(nom_sucursalLabel);
            this.Controls.Add(this.nom_sucursalLabel1);
            this.Controls.Add(cod_sucursalLabel);
            this.Controls.Add(this.cod_sucursalLabel1);
            this.Controls.Add(nom_empresaLabel);
            this.Controls.Add(this.nom_empresaLabel1);
            this.Controls.Add(cod_empresaLabel);
            this.Controls.Add(this.cod_empresaLabel1);
            this.Name = "frmSucursal";
            this.Text = "frmSucursal";
            this.Load += new System.EventHandler(this.frmSucursal_Load);
            ((System.ComponentModel.ISupportInitialize)(this._C__admtosap_DataB_sqliteDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private _C__admtosap_DataB_sqliteDataSet _C__admtosap_DataB_sqliteDataSet;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private _C__admtosap_DataB_sqliteDataSetTableAdapters.empresasTableAdapter empresasTableAdapter;
        private _C__admtosap_DataB_sqliteDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label cod_empresaLabel1;
        private System.Windows.Forms.Label nom_empresaLabel1;
        private System.Windows.Forms.Label cod_sucursalLabel1;
        private System.Windows.Forms.Label nom_sucursalLabel1;

    }
}