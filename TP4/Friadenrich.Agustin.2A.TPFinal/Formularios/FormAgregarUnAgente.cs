using System;
using System.Windows.Forms;
using Entidades;
using Excepciones;

namespace Formularios
{
    public partial class FormAgregarUnAgente : Form
    {
        public EAgentes agente;
        Contaminante contaminante;
        string proveedor;

        public Contaminante Contaminantes { get { return this.contaminante; } }

        public FormAgregarUnAgente()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Constructor de dos parametros, asigna el agente y el proveedor de datos.
        /// </summary>
        /// <param name="agente"></param>
        /// <param name="proveedor"></param>
        public FormAgregarUnAgente(EAgentes agente, string proveedor) : this()
        {
            this.agente = agente;
            this.proveedor = proveedor;
        }
        
        /// <summary>
        /// Al cargar, cambia los valores dependiendo si el agente es fabrica o vehiculo.
        /// Primero agrega al comboBox de provincias los valores del enumerado
        /// Si el agente es vehiculo, los valores por defecto de los textos ya están asignados
        /// para agregar un vehiculo, por lo que solo agrega los datos del enumerado de ETipoVehiculo.
        /// Si el agente es fabrica, cambia los valores de los textos para adecuarlos a este tipo
        /// y luego carga los valores del enumerado de ETipoFabrica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AgregarUnAgente_Load(object sender, EventArgs e)
        {
            cmbProvincia.DataSource = Enum.GetValues(typeof(EProvincias));
            
            if (agente == EAgentes.Fabricas)
            {
                this.Text = "Agregar Fábrica";
                lblGasesEmitidos.Text = "Gases emitidos (en toneladas de CO2 por fábrica): ";
                lblNombre.Text = "Nombre de la fábrica: ";
                cmbTipo.DataSource = Enum.GetValues(typeof(ETipoFabrica));
            } else 
            {
                cmbTipo.DataSource = Enum.GetValues(typeof(ETipoVehiculo));
            }
        }

        /// <summary>
        /// Agrega los datos de los textBoxs y los comboBoxs al objeto de tipo contaminante,
        /// instanciandolo en Fabrica o Vehiculo dependiendo el agente. Además de asinarlo para agregarlo
        /// a alguna de las listas del formContaminantes, tambien lo carga a la base de datos SQL.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            EProvincias provincia = (EProvincias)this.cmbProvincia.SelectedItem;
            Int32.TryParse(this.txtCantidad.Text, out int cantidad);
            Int32.TryParse(this.txGasesEmitidos.Text, out int gasesEmitidos);

            try
            {
                if (agente == EAgentes.Fabricas)
                {
                    contaminante = new Fabrica((ETipoFabrica)this.cmbTipo.SelectedItem, provincia, this.txtNombre.Text, cantidad, gasesEmitidos);
                    if (contaminante.AgregarASQL(proveedor))
                        MessageBox.Show("Se agregó correctamente la fabrica a la base de datos.");
                    else
                        MessageBox.Show("No se pudo agregar el agente a la base de datos.");

                } else 
                {
                    contaminante = new Vehiculo((ETipoVehiculo)this.cmbTipo.SelectedItem, provincia, this.txtNombre.Text, cantidad, gasesEmitidos);
                    if (contaminante.AgregarASQL(proveedor))
                        MessageBox.Show("Se agregó correctamente la fabrica a la base de datos.");
                    else
                        MessageBox.Show("No se pudo agregar el agente a la base de datos.");
                
                }
                if(gasesEmitidos == 0)
                {
                    MessageBox.Show("No se asignó un valor a gases emitidos. Se asignará el promedio correspondiente para ese tipo.");
                }
            } catch (NumeroFueraDeRangoException err)
            {
                MessageBox.Show(err.Message);
            } catch (StringInvalidoException err)
            {
                MessageBox.Show(err.Message);
            }

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancela la carga y cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

