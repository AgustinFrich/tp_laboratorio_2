
namespace Formularios
{
    partial class FormContaminantes
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
            this.lstFabricas = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpFabricas = new System.Windows.Forms.GroupBox();
            this.btnCargarFabricas = new System.Windows.Forms.Button();
            this.lblGasesTotalesFabricas = new System.Windows.Forms.Label();
            this.cmbOrdenarFabricas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpVehiculos = new System.Windows.Forms.GroupBox();
            this.btnCargarVehiculos = new System.Windows.Forms.Button();
            this.cmbOrdenarVehiculos = new System.Windows.Forms.ComboBox();
            this.btnGuardarVehiculos = new System.Windows.Forms.Button();
            this.lblGasesTotalesVehiculos = new System.Windows.Forms.Label();
            this.btnBorrarVehiculo = new System.Windows.Forms.Button();
            this.lstVehiculos = new System.Windows.Forms.ListBox();
            this.btnAgregarVehiculo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregarFabrica = new System.Windows.Forms.Button();
            this.btnBorrarFabrica = new System.Windows.Forms.Button();
            this.btnGuardarFábricas = new System.Windows.Forms.Button();
            this.btnMostrarDatos = new System.Windows.Forms.Button();
            this.btnGuardarAmbos = new System.Windows.Forms.Button();
            this.grpFabricas.SuspendLayout();
            this.grpVehiculos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstFabricas
            // 
            this.lstFabricas.FormattingEnabled = true;
            this.lstFabricas.HorizontalScrollbar = true;
            this.lstFabricas.ItemHeight = 15;
            this.lstFabricas.Location = new System.Drawing.Point(6, 22);
            this.lstFabricas.Name = "lstFabricas";
            this.lstFabricas.Size = new System.Drawing.Size(762, 184);
            this.lstFabricas.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1040, 37);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Análisis de agentes contaminantes";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpFabricas
            // 
            this.grpFabricas.Controls.Add(this.btnCargarFabricas);
            this.grpFabricas.Controls.Add(this.lblGasesTotalesFabricas);
            this.grpFabricas.Controls.Add(this.cmbOrdenarFabricas);
            this.grpFabricas.Controls.Add(this.label1);
            this.grpFabricas.Controls.Add(this.lstFabricas);
            this.grpFabricas.Location = new System.Drawing.Point(12, 41);
            this.grpFabricas.Name = "grpFabricas";
            this.grpFabricas.Size = new System.Drawing.Size(997, 246);
            this.grpFabricas.TabIndex = 3;
            this.grpFabricas.TabStop = false;
            this.grpFabricas.Text = "Fabricas";
            // 
            // btnCargarFabricas
            // 
            this.btnCargarFabricas.Location = new System.Drawing.Point(805, 160);
            this.btnCargarFabricas.Name = "btnCargarFabricas";
            this.btnCargarFabricas.Size = new System.Drawing.Size(175, 40);
            this.btnCargarFabricas.TabIndex = 12;
            this.btnCargarFabricas.Text = "Cargar Fábricas";
            this.btnCargarFabricas.UseVisualStyleBackColor = true;
            this.btnCargarFabricas.Click += new System.EventHandler(this.btnCargarFabricas_Click);
            // 
            // lblGasesTotalesFabricas
            // 
            this.lblGasesTotalesFabricas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGasesTotalesFabricas.Location = new System.Drawing.Point(202, 215);
            this.lblGasesTotalesFabricas.Name = "lblGasesTotalesFabricas";
            this.lblGasesTotalesFabricas.Size = new System.Drawing.Size(334, 23);
            this.lblGasesTotalesFabricas.TabIndex = 2;
            // 
            // cmbOrdenarFabricas
            // 
            this.cmbOrdenarFabricas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdenarFabricas.FormattingEnabled = true;
            this.cmbOrdenarFabricas.Location = new System.Drawing.Point(805, 213);
            this.cmbOrdenarFabricas.Name = "cmbOrdenarFabricas";
            this.cmbOrdenarFabricas.Size = new System.Drawing.Size(175, 23);
            this.cmbOrdenarFabricas.TabIndex = 12;
            this.cmbOrdenarFabricas.SelectedIndexChanged += new System.EventHandler(this.cmbOrdenarFabricas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gases Totales Emitidos: ";
            // 
            // grpVehiculos
            // 
            this.grpVehiculos.Controls.Add(this.btnCargarVehiculos);
            this.grpVehiculos.Controls.Add(this.cmbOrdenarVehiculos);
            this.grpVehiculos.Controls.Add(this.btnGuardarVehiculos);
            this.grpVehiculos.Controls.Add(this.lblGasesTotalesVehiculos);
            this.grpVehiculos.Controls.Add(this.btnBorrarVehiculo);
            this.grpVehiculos.Controls.Add(this.lstVehiculos);
            this.grpVehiculos.Controls.Add(this.btnAgregarVehiculo);
            this.grpVehiculos.Controls.Add(this.label3);
            this.grpVehiculos.Location = new System.Drawing.Point(12, 304);
            this.grpVehiculos.Name = "grpVehiculos";
            this.grpVehiculos.Size = new System.Drawing.Size(997, 251);
            this.grpVehiculos.TabIndex = 4;
            this.grpVehiculos.TabStop = false;
            this.grpVehiculos.Text = "Vehiculos";
            // 
            // btnCargarVehiculos
            // 
            this.btnCargarVehiculos.Location = new System.Drawing.Point(805, 160);
            this.btnCargarVehiculos.Name = "btnCargarVehiculos";
            this.btnCargarVehiculos.Size = new System.Drawing.Size(175, 40);
            this.btnCargarVehiculos.TabIndex = 13;
            this.btnCargarVehiculos.Text = "Cargar Vehículos";
            this.btnCargarVehiculos.UseVisualStyleBackColor = true;
            this.btnCargarVehiculos.Click += new System.EventHandler(this.btnCargarVehiculos_Click);
            // 
            // cmbOrdenarVehiculos
            // 
            this.cmbOrdenarVehiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdenarVehiculos.FormattingEnabled = true;
            this.cmbOrdenarVehiculos.Location = new System.Drawing.Point(805, 217);
            this.cmbOrdenarVehiculos.Name = "cmbOrdenarVehiculos";
            this.cmbOrdenarVehiculos.Size = new System.Drawing.Size(175, 23);
            this.cmbOrdenarVehiculos.TabIndex = 13;
            this.cmbOrdenarVehiculos.SelectedIndexChanged += new System.EventHandler(this.cmbOrdenarVehiculos_SelectedIndexChanged);
            // 
            // btnGuardarVehiculos
            // 
            this.btnGuardarVehiculos.Location = new System.Drawing.Point(805, 114);
            this.btnGuardarVehiculos.Name = "btnGuardarVehiculos";
            this.btnGuardarVehiculos.Size = new System.Drawing.Size(175, 40);
            this.btnGuardarVehiculos.TabIndex = 10;
            this.btnGuardarVehiculos.Text = "Guardar Vehículos";
            this.btnGuardarVehiculos.UseVisualStyleBackColor = true;
            this.btnGuardarVehiculos.Click += new System.EventHandler(this.btnGuardarVehiculos_Click);
            // 
            // lblGasesTotalesVehiculos
            // 
            this.lblGasesTotalesVehiculos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGasesTotalesVehiculos.Location = new System.Drawing.Point(202, 215);
            this.lblGasesTotalesVehiculos.Name = "lblGasesTotalesVehiculos";
            this.lblGasesTotalesVehiculos.Size = new System.Drawing.Size(334, 23);
            this.lblGasesTotalesVehiculos.TabIndex = 4;
            // 
            // btnBorrarVehiculo
            // 
            this.btnBorrarVehiculo.Location = new System.Drawing.Point(805, 68);
            this.btnBorrarVehiculo.Name = "btnBorrarVehiculo";
            this.btnBorrarVehiculo.Size = new System.Drawing.Size(175, 40);
            this.btnBorrarVehiculo.TabIndex = 9;
            this.btnBorrarVehiculo.Text = "Borrar Vehículo";
            this.btnBorrarVehiculo.UseVisualStyleBackColor = true;
            this.btnBorrarVehiculo.Click += new System.EventHandler(this.btnBorrarVehiculo_Click);
            // 
            // lstVehiculos
            // 
            this.lstVehiculos.FormattingEnabled = true;
            this.lstVehiculos.ItemHeight = 15;
            this.lstVehiculos.Location = new System.Drawing.Point(6, 22);
            this.lstVehiculos.Name = "lstVehiculos";
            this.lstVehiculos.Size = new System.Drawing.Size(762, 184);
            this.lstVehiculos.TabIndex = 0;
            // 
            // btnAgregarVehiculo
            // 
            this.btnAgregarVehiculo.Location = new System.Drawing.Point(805, 22);
            this.btnAgregarVehiculo.Name = "btnAgregarVehiculo";
            this.btnAgregarVehiculo.Size = new System.Drawing.Size(175, 40);
            this.btnAgregarVehiculo.TabIndex = 8;
            this.btnAgregarVehiculo.Text = "Agregar Vehículo";
            this.btnAgregarVehiculo.UseVisualStyleBackColor = true;
            this.btnAgregarVehiculo.Click += new System.EventHandler(this.btnAgregarVehiculo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(21, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Gases Totales Emitidos: ";
            // 
            // btnAgregarFabrica
            // 
            this.btnAgregarFabrica.Location = new System.Drawing.Point(817, 63);
            this.btnAgregarFabrica.Name = "btnAgregarFabrica";
            this.btnAgregarFabrica.Size = new System.Drawing.Size(175, 40);
            this.btnAgregarFabrica.TabIndex = 5;
            this.btnAgregarFabrica.Text = "Agregar Fábrica";
            this.btnAgregarFabrica.UseVisualStyleBackColor = true;
            this.btnAgregarFabrica.Click += new System.EventHandler(this.btnAgregarFabrica_Click);
            // 
            // btnBorrarFabrica
            // 
            this.btnBorrarFabrica.Location = new System.Drawing.Point(817, 109);
            this.btnBorrarFabrica.Name = "btnBorrarFabrica";
            this.btnBorrarFabrica.Size = new System.Drawing.Size(175, 40);
            this.btnBorrarFabrica.TabIndex = 6;
            this.btnBorrarFabrica.Text = "Borrar Fábrica";
            this.btnBorrarFabrica.UseVisualStyleBackColor = true;
            this.btnBorrarFabrica.Click += new System.EventHandler(this.btnBorrarFabrica_Click);
            // 
            // btnGuardarFábricas
            // 
            this.btnGuardarFábricas.Location = new System.Drawing.Point(817, 155);
            this.btnGuardarFábricas.Name = "btnGuardarFábricas";
            this.btnGuardarFábricas.Size = new System.Drawing.Size(175, 40);
            this.btnGuardarFábricas.TabIndex = 7;
            this.btnGuardarFábricas.Text = "Guardar Fábricas";
            this.btnGuardarFábricas.UseVisualStyleBackColor = true;
            this.btnGuardarFábricas.Click += new System.EventHandler(this.btnGuardarFábricas_Click);
            // 
            // btnMostrarDatos
            // 
            this.btnMostrarDatos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMostrarDatos.Location = new System.Drawing.Point(420, 573);
            this.btnMostrarDatos.Name = "btnMostrarDatos";
            this.btnMostrarDatos.Size = new System.Drawing.Size(200, 45);
            this.btnMostrarDatos.TabIndex = 8;
            this.btnMostrarDatos.Text = "Mostrar Análisis de datos";
            this.btnMostrarDatos.UseVisualStyleBackColor = true;
            this.btnMostrarDatos.Click += new System.EventHandler(this.btnMostrarDatos_Click);
            // 
            // btnGuardarAmbos
            // 
            this.btnGuardarAmbos.Location = new System.Drawing.Point(817, 573);
            this.btnGuardarAmbos.Name = "btnGuardarAmbos";
            this.btnGuardarAmbos.Size = new System.Drawing.Size(175, 45);
            this.btnGuardarAmbos.TabIndex = 14;
            this.btnGuardarAmbos.Text = "Guardar Ambos";
            this.btnGuardarAmbos.UseVisualStyleBackColor = true;
            this.btnGuardarAmbos.Click += new System.EventHandler(this.btnGuardarAmbos_Click);
            // 
            // FormContaminantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 637);
            this.Controls.Add(this.btnGuardarAmbos);
            this.Controls.Add(this.btnMostrarDatos);
            this.Controls.Add(this.btnGuardarFábricas);
            this.Controls.Add(this.btnBorrarFabrica);
            this.Controls.Add(this.btnAgregarFabrica);
            this.Controls.Add(this.grpVehiculos);
            this.Controls.Add(this.grpFabricas);
            this.Controls.Add(this.lblTitle);
            this.Name = "FormContaminantes";
            this.Text = "FormContaminantes";
            this.Load += new System.EventHandler(this.FormContaminantes_Load);
            this.grpFabricas.ResumeLayout(false);
            this.grpFabricas.PerformLayout();
            this.grpVehiculos.ResumeLayout(false);
            this.grpVehiculos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstFabricas;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpFabricas;
        private System.Windows.Forms.GroupBox grpVehiculos;
        private System.Windows.Forms.ListBox lstVehiculos;
        private System.Windows.Forms.Button btnAgregarFabrica;
        private System.Windows.Forms.Button btnBorrarFabrica;
        private System.Windows.Forms.Button btnGuardarFábricas;
        private System.Windows.Forms.Button btnGuardarVehiculos;
        private System.Windows.Forms.Button btnBorrarVehiculo;
        private System.Windows.Forms.Button btnAgregarVehiculo;
        private System.Windows.Forms.ComboBox cmbOrdenarFabricas;
        private System.Windows.Forms.ComboBox cmbOrdenarVehiculos;
        private System.Windows.Forms.Label lblGasesTotalesFabricas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGasesTotalesVehiculos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCargarFabricas;
        private System.Windows.Forms.Button btnCargarVehiculos;
        private System.Windows.Forms.Button btnMostrarDatos;
        private System.Windows.Forms.Button btnGuardarAmbos;
    }
}