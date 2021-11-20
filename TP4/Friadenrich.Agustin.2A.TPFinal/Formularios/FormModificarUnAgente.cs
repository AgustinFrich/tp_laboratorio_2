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
    public partial class FormModificarUnAgente : Form
    {
        EAgentes agente;
        Contaminantes contaminante;
        string proveedor;

        public Contaminantes Contaminante { get => contaminante; }

        public FormModificarUnAgente()
        {
            InitializeComponent();
        }

        public FormModificarUnAgente(EAgentes agente, Contaminantes contaminante, string proveedor) : this()
        {
            this.proveedor = proveedor;
            this.contaminante = contaminante;
            this.agente = agente;
        }

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
                cmbTipo.DataSource = Enum.GetValues(typeof(ETipoFabrica));
                cmbTipo.SelectedItem = ((Fabrica)contaminante).TipoFabrica;
            }
            else
            {
                lblModificables.Text = "Vehiculo a modificar:";
                cmbTipo.DataSource = Enum.GetValues(typeof(ETipoVehiculo));
                cmbTipo.SelectedItem = ((Vehiculo)contaminante).TipoVehiculo;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Int32.TryParse(this.txtCantidad.Text, out int cantidad);
            Int32.TryParse(this.txtGasesEmitidos.Text, out int gasesEmitidos);

            try
            {
                if (agente == EAgentes.Fabricas)
                {
                    contaminante = new Fabrica((ETipoFabrica)this.cmbTipo.SelectedItem, this.contaminante.Provincia, this.contaminante.Nombre, cantidad, gasesEmitidos);
                    contaminante.Modificar(proveedor);
                }
                else
                {
                    contaminante = new Vehiculo((ETipoVehiculo)this.cmbTipo.SelectedItem, this.contaminante.Provincia, this.contaminante.Nombre, cantidad, gasesEmitidos);
                    contaminante.Modificar(proveedor);
                }
                if (gasesEmitidos == 0)
                {
                    MessageBox.Show("No se asignó un valor a gases emitidos. Se asignará el promedio correspondiente para ese tipo.");
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
