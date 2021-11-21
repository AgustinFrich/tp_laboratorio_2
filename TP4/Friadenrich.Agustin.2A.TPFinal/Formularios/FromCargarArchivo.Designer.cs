
namespace Formularios
{
    partial class FromCargarArchivo
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
            this.CargarAmbos = new System.Windows.Forms.Button();
            this.CargarFabricas = new System.Windows.Forms.Button();
            this.CargarVehiculos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CargarAmbos
            // 
            this.CargarAmbos.Location = new System.Drawing.Point(12, 160);
            this.CargarAmbos.Name = "CargarAmbos";
            this.CargarAmbos.Size = new System.Drawing.Size(237, 48);
            this.CargarAmbos.TabIndex = 0;
            this.CargarAmbos.Text = "Cargar Ambos archivos";
            this.CargarAmbos.UseVisualStyleBackColor = true;
            this.CargarAmbos.Click += new System.EventHandler(this.CargarAmbos_Click);
            // 
            // CargarFabricas
            // 
            this.CargarFabricas.Location = new System.Drawing.Point(13, 15);
            this.CargarFabricas.Name = "CargarFabricas";
            this.CargarFabricas.Size = new System.Drawing.Size(237, 48);
            this.CargarFabricas.TabIndex = 1;
            this.CargarFabricas.Text = "Cargar Archivo con Fabricas";
            this.CargarFabricas.UseVisualStyleBackColor = true;
            this.CargarFabricas.Click += new System.EventHandler(this.CargarFabricas_Click);
            // 
            // CargarVehiculos
            // 
            this.CargarVehiculos.Location = new System.Drawing.Point(13, 69);
            this.CargarVehiculos.Name = "CargarVehiculos";
            this.CargarVehiculos.Size = new System.Drawing.Size(237, 49);
            this.CargarVehiculos.TabIndex = 2;
            this.CargarVehiculos.Text = "Cargar Archivo con Vehiculos";
            this.CargarVehiculos.UseVisualStyleBackColor = true;
            this.CargarVehiculos.Click += new System.EventHandler(this.CargarVehiculos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "-----------  o  -----------";
            // 
            // FromCargarArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 220);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CargarVehiculos);
            this.Controls.Add(this.CargarFabricas);
            this.Controls.Add(this.CargarAmbos);
            this.Name = "FromCargarArchivo";
            this.Text = "CargarArchivo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCargarArchivo_FormClosing);
            this.Load += new System.EventHandler(this.FromCargarArchivo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CargarAmbos;
        private System.Windows.Forms.Button CargarFabricas;
        private System.Windows.Forms.Button CargarVehiculos;
        private System.Windows.Forms.Label label2;
    }
}