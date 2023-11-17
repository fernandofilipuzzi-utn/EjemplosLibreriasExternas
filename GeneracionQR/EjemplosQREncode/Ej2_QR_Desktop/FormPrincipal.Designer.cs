
namespace Ej2_QR_Desktop
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnQR = new System.Windows.Forms.Button();
            this.tbCadenaDeEntrada = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(38, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // btnQR
            // 
            this.btnQR.Location = new System.Drawing.Point(291, 78);
            this.btnQR.Margin = new System.Windows.Forms.Padding(4);
            this.btnQR.Name = "btnQR";
            this.btnQR.Size = new System.Drawing.Size(184, 61);
            this.btnQR.TabIndex = 27;
            this.btnQR.Text = "Generar QR";
            this.btnQR.UseVisualStyleBackColor = true;
            this.btnQR.Click += new System.EventHandler(this.btnQR_Click);
            // 
            // tbCadenaDeEntrada
            // 
            this.tbCadenaDeEntrada.Location = new System.Drawing.Point(38, 22);
            this.tbCadenaDeEntrada.Name = "tbCadenaDeEntrada";
            this.tbCadenaDeEntrada.Size = new System.Drawing.Size(413, 20);
            this.tbCadenaDeEntrada.TabIndex = 29;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(173, 285);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(65, 28);
            this.btnCopy.TabIndex = 30;
            this.btnCopy.Text = "copiar";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 310);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.tbCadenaDeEntrada);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnQR);
            this.Name = "FormPrincipal";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnQR;
        private System.Windows.Forms.TextBox tbCadenaDeEntrada;
        private System.Windows.Forms.Button btnCopy;
    }
}

