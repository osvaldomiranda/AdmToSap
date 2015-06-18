namespace AdmToSap
{
    partial class frmBodegas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBodegas));
            this.bodegasBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bodegasBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.bodegasDataGridView = new System.Windows.Forms.DataGridView();
            this.bodegasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._C__admtosap_DataB_sqliteDataSet = new AdmToSap._C__admtosap_DataB_sqliteDataSet();
            this.bodegasTableAdapter = new AdmToSap._C__admtosap_DataB_sqliteDataSetTableAdapters.bodegasTableAdapter();
            this.tableAdapterManager = new AdmToSap._C__admtosap_DataB_sqliteDataSetTableAdapters.TableAdapterManager();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bodegasBindingNavigator)).BeginInit();
            this.bodegasBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bodegasDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodegasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._C__admtosap_DataB_sqliteDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // bodegasBindingNavigator
            // 
            this.bodegasBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bodegasBindingNavigator.BindingSource = this.bodegasBindingSource;
            this.bodegasBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bodegasBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bodegasBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.bodegasBindingNavigatorSaveItem});
            this.bodegasBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.bodegasBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bodegasBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bodegasBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bodegasBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bodegasBindingNavigator.Name = "bodegasBindingNavigator";
            this.bodegasBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bodegasBindingNavigator.Size = new System.Drawing.Size(617, 25);
            this.bodegasBindingNavigator.TabIndex = 0;
            this.bodegasBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
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
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Agregar nuevo";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Eliminar";
            // 
            // bodegasBindingNavigatorSaveItem
            // 
            this.bodegasBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bodegasBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("bodegasBindingNavigatorSaveItem.Image")));
            this.bodegasBindingNavigatorSaveItem.Name = "bodegasBindingNavigatorSaveItem";
            this.bodegasBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.bodegasBindingNavigatorSaveItem.Text = "Guardar datos";
            this.bodegasBindingNavigatorSaveItem.Click += new System.EventHandler(this.bodegasBindingNavigatorSaveItem_Click);
            // 
            // bodegasDataGridView
            // 
            this.bodegasDataGridView.AutoGenerateColumns = false;
            this.bodegasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bodegasDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.bodegasDataGridView.DataSource = this.bodegasBindingSource;
            this.bodegasDataGridView.Location = new System.Drawing.Point(21, 33);
            this.bodegasDataGridView.Name = "bodegasDataGridView";
            this.bodegasDataGridView.Size = new System.Drawing.Size(567, 220);
            this.bodegasDataGridView.TabIndex = 1;
            // 
            // bodegasBindingSource
            // 
            this.bodegasBindingSource.DataMember = "bodegas";
            this.bodegasBindingSource.DataSource = this._C__admtosap_DataB_sqliteDataSet;
            // 
            // _C__admtosap_DataB_sqliteDataSet
            // 
            this._C__admtosap_DataB_sqliteDataSet.DataSetName = "_C__admtosap_DataB_sqliteDataSet";
            this._C__admtosap_DataB_sqliteDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bodegasTableAdapter
            // 
            this.bodegasTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.bodegasTableAdapter = this.bodegasTableAdapter;
            this.tableAdapterManager.connectdbTableAdapter = null;
            this.tableAdapterManager.documentoTableAdapter = null;
            this.tableAdapterManager.logTableAdapter = null;
            this.tableAdapterManager.sqlite_sequenceTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AdmToSap._C__admtosap_DataB_sqliteDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codbodegaadm";
            this.dataGridViewTextBoxColumn1.HeaderText = "codbodegaadm";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "codbodegasap";
            this.dataGridViewTextBoxColumn2.HeaderText = "codbodegasap";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "nombrebodega";
            this.dataGridViewTextBoxColumn3.HeaderText = "nombrebodega";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // frmBodegas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 315);
            this.Controls.Add(this.bodegasDataGridView);
            this.Controls.Add(this.bodegasBindingNavigator);
            this.Name = "frmBodegas";
            this.Text = "frmBodegas";
            this.Load += new System.EventHandler(this.frmBodegas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bodegasBindingNavigator)).EndInit();
            this.bodegasBindingNavigator.ResumeLayout(false);
            this.bodegasBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bodegasDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodegasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._C__admtosap_DataB_sqliteDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private _C__admtosap_DataB_sqliteDataSet _C__admtosap_DataB_sqliteDataSet;
        private System.Windows.Forms.BindingSource bodegasBindingSource;
        private _C__admtosap_DataB_sqliteDataSetTableAdapters.bodegasTableAdapter bodegasTableAdapter;
        private _C__admtosap_DataB_sqliteDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator bodegasBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bodegasBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView bodegasDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}