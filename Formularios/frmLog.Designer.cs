namespace AdmToSap
{
    partial class frmLog
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
            System.Windows.Forms.Label fchLabel;
            System.Windows.Forms.Label sucesoLabel;
            System.Windows.Forms.Label estadoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLog));
            this._C__admtosap_DataB_sqliteDataSet = new AdmToSap._C__admtosap_DataB_sqliteDataSet();
            this.logBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.logTableAdapter = new AdmToSap._C__admtosap_DataB_sqliteDataSetTableAdapters.logTableAdapter();
            this.tableAdapterManager = new AdmToSap._C__admtosap_DataB_sqliteDataSetTableAdapters.TableAdapterManager();
            this.logBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fchLabel1 = new System.Windows.Forms.Label();
            this.sucesoLabel1 = new System.Windows.Forms.Label();
            this.estadoLabel1 = new System.Windows.Forms.Label();
            fchLabel = new System.Windows.Forms.Label();
            sucesoLabel = new System.Windows.Forms.Label();
            estadoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._C__admtosap_DataB_sqliteDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logBindingNavigator)).BeginInit();
            this.logBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // fchLabel
            // 
            fchLabel.AutoSize = true;
            fchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fchLabel.Location = new System.Drawing.Point(12, 31);
            fchLabel.Name = "fchLabel";
            fchLabel.Size = new System.Drawing.Size(46, 13);
            fchLabel.TabIndex = 1;
            fchLabel.Text = "Fecha:";
            // 
            // sucesoLabel
            // 
            sucesoLabel.AutoSize = true;
            sucesoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sucesoLabel.Location = new System.Drawing.Point(10, 79);
            sucesoLabel.Name = "sucesoLabel";
            sucesoLabel.Size = new System.Drawing.Size(53, 13);
            sucesoLabel.TabIndex = 3;
            sucesoLabel.Text = "Suceso:";
            // 
            // estadoLabel
            // 
            estadoLabel.AutoSize = true;
            estadoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            estadoLabel.Location = new System.Drawing.Point(10, 175);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new System.Drawing.Size(50, 13);
            estadoLabel.TabIndex = 5;
            estadoLabel.Text = "Estado:";
            // 
            // _C__admtosap_DataB_sqliteDataSet
            // 
            this._C__admtosap_DataB_sqliteDataSet.DataSetName = "_C__admtosap_DataB_sqliteDataSet";
            this._C__admtosap_DataB_sqliteDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // logBindingSource
            // 
            this.logBindingSource.DataMember = "log";
            this.logBindingSource.DataSource = this._C__admtosap_DataB_sqliteDataSet;
            // 
            // logTableAdapter
            // 
            this.logTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.bodegasTableAdapter = null;
            this.tableAdapterManager.connectdbTableAdapter = null;
            this.tableAdapterManager.documentoTableAdapter = null;
            this.tableAdapterManager.logTableAdapter = this.logTableAdapter;
            this.tableAdapterManager.sqlite_sequenceTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AdmToSap._C__admtosap_DataB_sqliteDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // logBindingNavigator
            // 
            this.logBindingNavigator.AddNewItem = null;
            this.logBindingNavigator.BindingSource = this.logBindingSource;
            this.logBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.logBindingNavigator.DeleteItem = null;
            this.logBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.logBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.logBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.logBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.logBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.logBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.logBindingNavigator.Name = "logBindingNavigator";
            this.logBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.logBindingNavigator.Size = new System.Drawing.Size(779, 25);
            this.logBindingNavigator.TabIndex = 0;
            this.logBindingNavigator.Text = "bindingNavigator1";
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
            // fchLabel1
            // 
            this.fchLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logBindingSource, "fch", true));
            this.fchLabel1.Location = new System.Drawing.Point(69, 31);
            this.fchLabel1.Name = "fchLabel1";
            this.fchLabel1.Size = new System.Drawing.Size(104, 23);
            this.fchLabel1.TabIndex = 2;
            this.fchLabel1.Text = "label1";
            // 
            // sucesoLabel1
            // 
            this.sucesoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logBindingSource, "suceso", true));
            this.sucesoLabel1.Location = new System.Drawing.Point(69, 78);
            this.sucesoLabel1.Name = "sucesoLabel1";
            this.sucesoLabel1.Size = new System.Drawing.Size(635, 65);
            this.sucesoLabel1.TabIndex = 4;
            this.sucesoLabel1.Text = "label1";
            // 
            // estadoLabel1
            // 
            this.estadoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logBindingSource, "estado", true));
            this.estadoLabel1.Location = new System.Drawing.Point(66, 175);
            this.estadoLabel1.Name = "estadoLabel1";
            this.estadoLabel1.Size = new System.Drawing.Size(100, 23);
            this.estadoLabel1.TabIndex = 6;
            this.estadoLabel1.Text = "label1";
            // 
            // frmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 229);
            this.Controls.Add(estadoLabel);
            this.Controls.Add(this.estadoLabel1);
            this.Controls.Add(sucesoLabel);
            this.Controls.Add(this.sucesoLabel1);
            this.Controls.Add(fchLabel);
            this.Controls.Add(this.fchLabel1);
            this.Controls.Add(this.logBindingNavigator);
            this.Name = "frmLog";
            this.Text = "frmLog";
            this.Load += new System.EventHandler(this.frmLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this._C__admtosap_DataB_sqliteDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logBindingNavigator)).EndInit();
            this.logBindingNavigator.ResumeLayout(false);
            this.logBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private _C__admtosap_DataB_sqliteDataSet _C__admtosap_DataB_sqliteDataSet;
        private System.Windows.Forms.BindingSource logBindingSource;
        private _C__admtosap_DataB_sqliteDataSetTableAdapters.logTableAdapter logTableAdapter;
        private _C__admtosap_DataB_sqliteDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator logBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Label fchLabel1;
        private System.Windows.Forms.Label sucesoLabel1;
        private System.Windows.Forms.Label estadoLabel1;
    }
}