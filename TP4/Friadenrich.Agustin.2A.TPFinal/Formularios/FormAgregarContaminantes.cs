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

        /// <summary>
        /// Carga el comboBox que permite seleccionar el o los tipos de agentes que se analizaran
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAgregarContaminantes_Load(object sender, EventArgs e)
        {
            this.txtNombre.Text = "Fabricas por todos lados";
            this.cmbAgente.DataSource = Enum.GetValues(typeof(EAgentes));
        }

        /// <summary>
        /// Asigna los valores de nombre y agente en funcion de los ingresados por el usuario.
        /// Si el nombre está vacio, se ingresa 'Sin nombre' en su lugar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Cancela la ejecucion del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
