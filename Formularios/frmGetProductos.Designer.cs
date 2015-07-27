namespace AdmToSap
{
    partial class frmGetProductos
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
            this.buttonCargaProd = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonCargaInv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCargaProd
            // 
            this.buttonCargaProd.Location = new System.Drawing.Point(158, 238);
            this.buttonCargaProd.Name = "buttonCargaProd";
            this.buttonCargaProd.Size = new System.Drawing.Size(122, 23);
            this.buttonCargaProd.TabIndex = 0;
            this.buttonCargaProd.Text = "Cargar Productos";
            this.buttonCargaProd.UseVisualStyleBackColor = true;
            this.buttonCargaProd.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(53, 110);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Intervalo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(153, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "0";
            // 
            // buttonCargaInv
            // 
            this.buttonCargaInv.Location = new System.Drawing.Point(158, 209);
            this.buttonCargaInv.Name = "buttonCargaInv";
            this.buttonCargaInv.Size = new System.Drawing.Size(122, 23);
            this.buttonCargaInv.TabIndex = 4;
            this.buttonCargaInv.Text = "Cargar Inventarios";
            this.buttonCargaInv.UseVisualStyleBackColor = true;
            this.buttonCargaInv.Click += new System.EventHandler(this.buttonCargaPecios_Click);
            // 
            // frmGetProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.buttonCargaInv);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.buttonCargaProd);
            this.Name = "frmGetProductos";
            this.Text = "frmGetProductos";
            this.Load += new System.EventHandler(this.frmGetProductos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCargaProd;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonCargaInv;
    }
}