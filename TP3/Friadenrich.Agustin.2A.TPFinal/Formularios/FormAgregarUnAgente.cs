using System;
using System.Windows.Forms;
using Entidades;
using Excepciones;

namespace Formularios
{
    public partial class FormAgregarUnAgente : Form
    {
        public EAgentes agente;
        Contaminantes contaminante;

        public Contaminantes Contaminantes { get { return this.contaminante; } }

        public FormAgregarUnAgente()
        {
            InitializeComponent();
        }
        
        public FormAgregarUnAgente(EAgentes agente) : this()
        {
            this.agente = agente;
        }

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
                } else 
                {
                    contaminante = new Vehiculo((ETipoVehiculo)this.cmbTipo.SelectedItem, provincia, this.txtNombre.Text, cantidad, gasesEmitidos);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

