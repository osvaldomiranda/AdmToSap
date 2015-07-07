namespace AdmToSap
{
    partial class frmEmpresa
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
            System.Windows.Forms.Label cOD_EMPRESALabel;
            System.Windows.Forms.Label r_SOCIALLabel;
            System.Windows.Forms.Label cOD_EMPRESALabel1;
            System.Windows.Forms.Label cOD_SUCURSALLabel;
            System.Windows.Forms.Label dIRECCIONLabel;
            System.Windows.Forms.Label nOMBRELabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpresa));
            this.cotillonDataSet = new AdmToSap.cotillonDataSet();
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empresasTableAdapter = new AdmToSap.cotillonDataSetTableAdapters.empresasTableAdapter();
            this.tableAdapterManager = new AdmToSap.cotillonDataSetTableAdapters.TableAdapterManager();
            this.empresasBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cOD_EMPRESATextBox = new System.Windows.Forms.TextBox();
            this.sucursalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sucursalesTableAdapter = new AdmToSap.cotillonDataSetTableAdapters.sucursalesTableAdapter();
            this.r_SOCIALTextBox = new System.Windows.Forms.TextBox();
            this.cOD_EMPRESATextBox1 = new System.Windows.Forms.TextBox();
            this.cOD_SUCURSALTextBox = new System.Windows.Forms.TextBox();
            this.dIRECCIONTextBox = new System.Windows.Forms.TextBox();
            this.nOMBRETextBox = new System.Windows.Forms.TextBox();
            this.SucursalbindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            cOD_EMPRESALabel = new System.Windows.Forms.Label();
            r_SOCIALLabel = new System.Windows.Forms.Label();
            cOD_EMPRESALabel1 = new System.Windows.Forms.Label();
            cOD_SUCURSALLabel = new System.Windows.Forms.Label();
            dIRECCIONLabel = new System.Windows.Forms.Label();
            nOMBRELabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cotillonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingNavigator)).BeginInit();
            this.empresasBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SucursalbindingNavigator1)).BeginInit();
            this.SucursalbindingNavigator1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cOD_EMPRESALabel
            // 
            cOD_EMPRESALabel.AutoSize = true;
            cOD_EMPRESALabel.Location = new System.Drawing.Point(12, 44);
            cOD_EMPRESALabel.Name = "cOD_EMPRESALabel";
            cOD_EMPRESALabel.Size = new System.Drawing.Size(88, 13);
            cOD_EMPRESALabel.TabIndex = 1;
            cOD_EMPRESALabel.Text = "COD EMPRESA:";
            // 
            // r_SOCIALLabel
            // 
            r_SOCIALLabel.AutoSize = true;
            r_SOCIALLabel.Location = new System.Drawing.Point(188, 44);
            r_SOCIALLabel.Name = "r_SOCIALLabel";
            r_SOCIALLabel.Size = new System.Drawing.Size(59, 13);
            r_SOCIALLabel.TabIndex = 3;
            r_SOCIALLabel.Text = "R SOCIAL:";
            // 
            // cOD_EMPRESALabel1
            // 
            cOD_EMPRESALabel1.AutoSize = true;
            cOD_EMPRESALabel1.Location = new System.Drawing.Point(16, 56);
            cOD_EMPRESALabel1.Name = "cOD_EMPRESALabel1";
            cOD_EMPRESALabel1.Size = new System.Drawing.Size(88, 13);
            cOD_EMPRESALabel1.TabIndex = 9;
            cOD_EMPRESALabel1.Text = "COD EMPRESA:";
            // 
            // cOD_SUCURSALLabel
            // 
            cOD_SUCURSALLabel.AutoSize = true;
            cOD_SUCURSALLabel.Location = new System.Drawing.Point(16, 84);
            cOD_SUCURSALLabel.Name = "cOD_SUCURSALLabel";
            cOD_SUCURSALLabel.Size = new System.Drawing.Size(94, 13);
            cOD_SUCURSALLabel.TabIndex = 13;
            cOD_SUCURSALLabel.Text = "COD SUCURSAL:";
            // 
            // dIRECCIONLabel
            // 
            dIRECCIONLabel.AutoSize = true;
            dIRECCIONLabel.Location = new System.Drawing.Point(16, 136);
            dIRECCIONLabel.Name = "dIRECCIONLabel";
            dIRECCIONLabel.Size = new System.Drawing.Size(69, 13);
            dIRECCIONLabel.TabIndex = 17;
            dIRECCIONLabel.Text = "DIRECCION:";
            // 
            // nOMBRELabel
            // 
            nOMBRELabel.AutoSize = true;
            nOMBRELabel.Location = new System.Drawing.Point(16, 162);
            nOMBRELabel.Name = "nOMBRELabel";
            nOMBRELabel.Size = new System.Drawing.Size(57, 13);
            nOMBRELabel.TabIndex = 19;
            nOMBRELabel.Text = "NOMBRE:";
            // 
            // cotillonDataSet
            // 
            this.cotillonDataSet.DataSetName = "cotillonDataSet";
            this.cotillonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // empresasBindingSource
            // 
            this.empresasBindingSource.DataMember = "empresas";
            this.empresasBindingSource.DataSource = this.cotillonDataSet;
            // 
            // empresasTableAdapter
            // 
            this.empresasTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.empresasTableAdapter = this.empresasTableAdapter;
            this.tableAdapterManager.sucursalesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AdmToSap.cotillonDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // empresasBindingNavigator
            // 
            this.empresasBindingNavigator.AddNewItem = null;
            this.empresasBindingNavigator.BindingSource = this.empresasBindingSource;
            this.empresasBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.empresasBindingNavigator.DeleteItem = null;
            this.empresasBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.empresasBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.empresasBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.empresasBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.empresasBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.empresasBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.empresasBindingNavigator.Name = "empresasBindingNavigator";
            this.empresasBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.empresasBindingNavigator.Size = new System.Drawing.Size(643, 25);
            this.empresasBindingNavigator.TabIndex = 0;
            this.empresasBindingNavigator.Text = "bindingNavigator1";
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
            // cOD_EMPRESATextBox
            // 
            this.cOD_EMPRESATextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empresasBindingSource, "COD_EMPRESA", true));
            this.cOD_EMPRESATextBox.Location = new System.Drawing.Point(106, 41);
            this.cOD_EMPRESATextBox.Name = "cOD_EMPRESATextBox";
            this.cOD_EMPRESATextBox.Size = new System.Drawing.Size(50, 20);
            this.cOD_EMPRESATextBox.TabIndex = 2;
            this.cOD_EMPRESATextBox.TextChanged += new System.EventHandler(this.cOD_EMPRESATextBox_TextChanged);
            // 
            // sucursalesBindingSource
            // 
            this.sucursalesBindingSource.DataMember = "empresas_sucursales";
            this.sucursalesBindingSource.DataSource = this.empresasBindingSource;
            // 
            // sucursalesTableAdapter
            // 
            this.sucursalesTableAdapter.ClearBeforeFill = true;
            // 
            // r_SOCIALTextBox
            // 
            this.r_SOCIALTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.empresasBindingSource, "R_SOCIAL", true));
            this.r_SOCIALTextBox.Location = new System.Drawing.Point(253, 41);
            this.r_SOCIALTextBox.Name = "r_SOCIALTextBox";
            this.r_SOCIALTextBox.Size = new System.Drawing.Size(330, 20);
            this.r_SOCIALTextBox.TabIndex = 4;
            // 
            // cOD_EMPRESATextBox1
            // 
            this.cOD_EMPRESATextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sucursalesBindingSource, "COD_EMPRESA", true));
            this.cOD_EMPRESATextBox1.Location = new System.Drawing.Point(132, 53);
            this.cOD_EMPRESATextBox1.Name = "cOD_EMPRESATextBox1";
            this.cOD_EMPRESATextBox1.Size = new System.Drawing.Size(46, 20);
            this.cOD_EMPRESATextBox1.TabIndex = 10;
            // 
            // cOD_SUCURSALTextBox
            // 
            this.cOD_SUCURSALTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sucursalesBindingSource, "COD_SUCURSAL", true));
            this.cOD_SUCURSALTextBox.Location = new System.Drawing.Point(132, 81);
            this.cOD_SUCURSALTextBox.Name = "cOD_SUCURSALTextBox";
            this.cOD_SUCURSALTextBox.Size = new System.Drawing.Size(81, 20);
            this.cOD_SUCURSALTextBox.TabIndex = 14;
            // 
            // dIRECCIONTextBox
            // 
            this.dIRECCIONTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sucursalesBindingSource, "DIRECCION", true));
            this.dIRECCIONTextBox.Location = new System.Drawing.Point(132, 133);
            this.dIRECCIONTextBox.Name = "dIRECCIONTextBox";
            this.dIRECCIONTextBox.Size = new System.Drawing.Size(402, 20);
            this.dIRECCIONTextBox.TabIndex = 18;
            // 
            // nOMBRETextBox
            // 
            this.nOMBRETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sucursalesBindingSource, "NOMBRE", true));
            this.nOMBRETextBox.Location = new System.Drawing.Point(132, 159);
            this.nOMBRETextBox.Name = "nOMBRETextBox";
            this.nOMBRETextBox.Size = new System.Drawing.Size(402, 20);
            this.nOMBRETextBox.TabIndex = 20;
            // 
            // SucursalbindingNavigator1
            // 
            this.SucursalbindingNavigator1.AddNewItem = null;
            this.SucursalbindingNavigator1.BindingSource = this.sucursalesBindingSource;
            this.SucursalbindingNavigator1.CountItem = this.bindingNavigatorCountItem1;
            this.SucursalbindingNavigator1.DeleteItem = null;
            this.SucursalbindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5});
            this.SucursalbindingNavigator1.Location = new System.Drawing.Point(3, 16);
            this.SucursalbindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.SucursalbindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.SucursalbindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.SucursalbindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.SucursalbindingNavigator1.Name = "SucursalbindingNavigator1";
            this.SucursalbindingNavigator1.PositionItem = this.bindingNavigatorPositionItem1;
            this.SucursalbindingNavigator1.Size = new System.Drawing.Size(594, 25);
            this.SucursalbindingNavigator1.TabIndex = 21;
            this.SucursalbindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem1.Text = "de {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem1.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem1.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem1.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem1.Text = "Mover último";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SucursalbindingNavigator1);
            this.groupBox1.Controls.Add(cOD_EMPRESALabel1);
            this.groupBox1.Controls.Add(this.cOD_EMPRESATextBox1);
            this.groupBox1.Controls.Add(this.nOMBRETextBox);
            this.groupBox1.Controls.Add(cOD_SUCURSALLabel);
            this.groupBox1.Controls.Add(nOMBRELabel);
            this.groupBox1.Controls.Add(this.cOD_SUCURSALTextBox);
            this.groupBox1.Controls.Add(this.dIRECCIONTextBox);
            this.groupBox1.Controls.Add(dIRECCIONLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 205);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sucursales";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(537, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 26);
            this.button2.TabIndex = 24;
            this.button2.Text = "Ver Empresa configurada";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 397);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(r_SOCIALLabel);
            this.Controls.Add(this.r_SOCIALTextBox);
            this.Controls.Add(cOD_EMPRESALabel);
            this.Controls.Add(this.cOD_EMPRESATextBox);
            this.Controls.Add(this.empresasBindingNavigator);
            this.Name = "frmEmpresa";
            this.Text = "frmEmpresa";
            this.Load += new System.EventHandler(this.frmEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cotillonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingNavigator)).EndInit();
            this.empresasBindingNavigator.ResumeLayout(false);
            this.empresasBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SucursalbindingNavigator1)).EndInit();
            this.SucursalbindingNavigator1.ResumeLayout(false);
            this.SucursalbindingNavigator1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private cotillonDataSet cotillonDataSet;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private cotillonDataSetTableAdapters.empresasTableAdapter empresasTableAdapter;
        private cotillonDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator empresasBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox cOD_EMPRESATextBox;
        private System.Windows.Forms.BindingSource sucursalesBindingSource;
        private cotillonDataSetTableAdapters.sucursalesTableAdapter sucursalesTableAdapter;
        private System.Windows.Forms.TextBox r_SOCIALTextBox;
        private System.Windows.Forms.TextBox cOD_EMPRESATextBox1;
        private System.Windows.Forms.TextBox cOD_SUCURSALTextBox;
        private System.Windows.Forms.TextBox dIRECCIONTextBox;
        private System.Windows.Forms.TextBox nOMBRETextBox;
        private System.Windows.Forms.BindingNavigator SucursalbindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}