
namespace Ej1_NPOI_Desktop
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnNPOI = new System.Windows.Forms.Button();
            this.btnEPPlus = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 180);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(69, 16);
            this.linkLabel1.TabIndex = 24;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnNPOI
            // 
            this.btnNPOI.Enabled = false;
            this.btnNPOI.Location = new System.Drawing.Point(235, 13);
            this.btnNPOI.Margin = new System.Windows.Forms.Padding(4);
            this.btnNPOI.Name = "btnNPOI";
            this.btnNPOI.Size = new System.Drawing.Size(184, 61);
            this.btnNPOI.TabIndex = 25;
            this.btnNPOI.Text = "Generar NPOI ";
            this.btnNPOI.UseVisualStyleBackColor = true;
            this.btnNPOI.Click += new System.EventHandler(this.btnNPOI_Click);
            // 
            // btnEPPlus
            // 
            this.btnEPPlus.Enabled = false;
            this.btnEPPlus.Location = new System.Drawing.Point(235, 82);
            this.btnEPPlus.Margin = new System.Windows.Forms.Padding(4);
            this.btnEPPlus.Name = "btnEPPlus";
            this.btnEPPlus.Size = new System.Drawing.Size(184, 61);
            this.btnEPPlus.TabIndex = 26;
            this.btnEPPlus.Text = "Generar con EPPlu";
            this.btnEPPlus.UseVisualStyleBackColor = true;
            this.btnEPPlus.Click += new System.EventHandler(this.btnEPPlus_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "XLS",
            "XLSX"});
            this.comboBox1.Location = new System.Drawing.Point(16, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 24);
            this.comboBox1.TabIndex = 27;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Formato";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 211);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnEPPlus);
            this.Controls.Add(this.btnNPOI);
            this.Controls.Add(this.linkLabel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ejemplos";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnNPOI;
        private System.Windows.Forms.Button btnEPPlus;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}

