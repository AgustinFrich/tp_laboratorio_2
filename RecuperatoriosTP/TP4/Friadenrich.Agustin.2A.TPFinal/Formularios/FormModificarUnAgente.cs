using System;
using System.Windows.Forms;
using Entidades;
using Excepciones;

namespace Formularios
{
    public partial class FormModificarUnAgente : Form
    {
        EAgentes agente;
        Contaminante contaminante;
        string proveedor;

        public Contaminante Contaminante { get => contaminante; }

        public FormModificarUnAgente()
        {
            InitializeComponent();
        }

        public FormModificarUnAgente(EAgentes agente, Contaminante contaminante, string proveedor) : this()
        {
            this.proveedor = proveedor;
            this.contaminante = contaminante;
            this.agente = agente;
        }

        /// <summary>
        /// Carga los datos del contaminante al formulario para facilitar la modificacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormModificarUnAgente_Load(object sender, EventArgs e)
        {
            this.Text = "Modificar '" + contaminante.Nombre + "'";
            this.txtNombre.Text = contaminante.Nombre;
            this.txtProvincia.Text = contaminante.Provincia.ToString();
            this.txtCantidad.Text = contaminante.Cantidad.ToString();
            this.txtGasesEmitidos.Text = contaminante.GasesEmitidos.ToString();

            if (agente == EAgentes.Fabricas)
            {
                lblGasesEmitidos.Text = "Gases emitidos (en toneladas de CO2 por fábrica): ";
                lblModificables.Text = "Fabrica a modificar:";
                lblCantidad.Text = "Cantidad de estas fabricas en la provincia:";
                cmbTipo.DataSource = Enum.GetValues(typeof(ETipoFabrica));
                cmbTipo.SelectedItem = ((Fabrica)contaminante).TipoFabrica;
            }
            else
            {
                cmbTipo.DataSource = Enum.GetValues(typeof(ETipoVehiculo));
                cmbTipo.SelectedItem = ((Vehiculo)contaminante).TipoVehiculo;
            }
        }

        /// <summary>
        /// El contaminante se instancia dependiendo el tipo de agente. El nombre y la provincia son los pasados como parametros,
        /// el resto de los atributos son los cambiados por el usuario.
        /// También realiza la modificacion en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Int32.TryParse(this.txtCantidad.Text, out int cantidad);
            Int32.TryParse(this.txtGasesEmitidos.Text, out int gasesEmitidos);

            try
            {
                if (agente == EAgentes.Fabricas)
                {
                    contaminante = new Fabrica((ETipoFabrica)this.cmbTipo.SelectedItem, this.contaminante.Provincia, this.contaminante.Nombre, cantidad, gasesEmitidos);
                    if (contaminante.ModificarASQL(proveedor))
                        MessageBox.Show("Se actualizo la fabrica correctamente en la base de datos.", "Modificación exitosa!");
                    else
                        MessageBox.Show("No se pudo actualizar la fabrica en la base de datos.", "Error en la modificacion.");
                }
                else
                {
                    contaminante = new Vehiculo((ETipoVehiculo)this.cmbTipo.SelectedItem, this.contaminante.Provincia, this.contaminante.Nombre, cantidad, gasesEmitidos);
                    if(contaminante.ModificarASQL(proveedor))
                        MessageBox.Show("Se actualizo el vehiculo correctamente en la base de datos.", "Modificación exitosa!");
                    else
                        MessageBox.Show("No se pudo actualizar el vehiculo en la base de datos.", "Error en la modificacion.");
                }
                if (gasesEmitidos == 0)
                {
                    MessageBox.Show("No se asignó un valor a gases emitidos. Se asignará el promedio correspondiente para ese tipo.", "Los gases emitidos nulos.");
                }
            }
            catch (NumeroFueraDeRangoException err)
            {
                MessageBox.Show(err.Message);
            }
            catch (StringInvalidoException err)
            {
                MessageBox.Show(err.Message);
            }

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancela la modificacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
