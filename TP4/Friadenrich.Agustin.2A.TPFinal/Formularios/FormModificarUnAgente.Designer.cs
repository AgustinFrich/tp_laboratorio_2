
namespace Formularios
{
    partial class FormModificarUnAgente
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
            this.lblTipoConNombre = new System.Windows.Forms.Label();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblModificables = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtGasesEmitidos = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblGasesEmitidos = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTipoConNombre
            // 
            this.lblTipoConNombre.AutoSize = true;
            this.lblTipoConNombre.Location = new System.Drawing.Point(20, 16);
            this.lblTipoConNombre.Name = "lblTipoConNombre";
            this.lblTipoConNombre.Size = new System.Drawing.Size(152, 15);
            this.lblTipoConNombre.TabIndex = 0;
            this.lblTipoConNombre.Text = "Contaminante a modificar: ";
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(20, 68);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(90, 15);
            this.lblProvincia.TabIndex = 1;
            this.lblProvincia.Text = "En la provincia: ";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(20, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(277, 23);
            this.txtNombre.TabIndex = 2;
            // 
            // txtProvincia
            // 
            this.txtProvincia.Enabled = false;
            this.txtProvincia.Location = new System.Drawing.Point(20, 89);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(277, 23);
            this.txtProvincia.TabIndex = 3;
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(20, 170);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(277, 23);
            this.cmbTipo.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tipo: ";
            // 
            // lblModificables
            // 
            this.lblModificables.AutoSize = true;
            this.lblModificables.Location = new System.Drawing.Point(63, 130);
            this.lblModificables.Name = "lblModificables";
            this.lblModificables.Size = new System.Drawing.Size(192, 15);
            this.lblModificables.TabIndex = 9;
            this.lblModificables.Text = "--- Componentes modificables: ---";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(201, 318);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(20, 318);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(175, 23);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtGasesEmitidos
            // 
            this.txtGasesEmitidos.Location = new System.Drawing.Point(20, 275);
            this.txtGasesEmitidos.Name = "txtGasesEmitidos";
            this.txtGasesEmitidos.Size = new System.Drawing.Size(277, 23);
            this.txtGasesEmitidos.TabIndex = 15;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(20, 220);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(277, 23);
            this.txtCantidad.TabIndex = 14;
            // 
            // lblGasesEmitidos
            // 
            this.lblGasesEmitidos.AutoSize = true;
            this.lblGasesEmitidos.Location = new System.Drawing.Point(20, 257);
            this.lblGasesEmitidos.Name = "lblGasesEmitidos";
            this.lblGasesEmitidos.Size = new System.Drawing.Size(226, 15);
            this.lblGasesEmitidos.TabIndex = 13;
            this.lblGasesEmitidos.Text = "Gases emitidos (en kilogramos por auto): ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cantidad: ";
            // 
            // FormModificarUnAgente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 361);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtGasesEmitidos);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblGasesEmitidos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblModificables);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProvincia);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblProvincia);
            this.Controls.Add(this.lblTipoConNombre);
            this.Name = "FormModificarUnAgente";
            this.Text = "Modificar Agente";
            this.Load += new System.EventHandler(this.FormModificarUnAgente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTipoConNombre;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblModificables;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtGasesEmitidos;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblGasesEmitidos;
        private System.Windows.Forms.Label label4;
    }
}