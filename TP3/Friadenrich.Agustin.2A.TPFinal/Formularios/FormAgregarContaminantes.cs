using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Excepciones;

namespace Formularios
{

    public partial class FormAgregarContaminantes : Form
    {

        string nombre;
        EAgentes agente;

        public string NombreDelProveedor { get { return this.nombre; } }
        public EAgentes Agente { get { return this.agente; } }

        public FormAgregarContaminantes()
        {
            InitializeComponent();
        }

        private void FormAgregarContaminantes_Load(object sender, EventArgs e)
        {
            this.cmbAgente.DataSource = Enum.GetValues(typeof(EAgentes));
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.nombre = this.txtNombre.Text;
            this.agente = (EAgentes)this.cmbAgente.SelectedItem;

            try
            {
                if(String.IsNullOrWhiteSpace(nombre))
                {
                    throw new StringInvalidoException("No se ingresó un nombre para el proveedor de datos. \nSe asinga 'Sin nombre' en su lugar");
                }
            } catch (StringInvalidoException err)
            {
                MessageBox.Show(err.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.nombre = "Sin nombre";
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
