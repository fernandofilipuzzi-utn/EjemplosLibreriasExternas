
namespace Ej4
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
            this.btnRecibosImagen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRecibosImagen
            // 
            this.btnRecibosImagen.Location = new System.Drawing.Point(100, 52);
            this.btnRecibosImagen.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnRecibosImagen.Name = "btnRecibosImagen";
            this.btnRecibosImagen.Size = new System.Drawing.Size(228, 122);
            this.btnRecibosImagen.TabIndex = 27;
            this.btnRecibosImagen.Text = "Generar pdf de recibos con imagen";
            this.btnRecibosImagen.UseVisualStyleBackColor = true;
            this.btnRecibosImagen.Click += new System.EventHandler(this.btnRecibosImagen_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 229);
            this.Controls.Add(this.btnRecibosImagen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormPrincipal";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRecibosImagen;
    }
}

