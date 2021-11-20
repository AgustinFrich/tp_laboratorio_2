using System;
using System.Windows.Forms;
using Entidades;

namespace Formularios
{
    public partial class FormAnalisisDeDatos : Form
    {
        private EAgentes agente;
        private GenericList<Vehiculo> vehiculos = new GenericList<Vehiculo>();
        private GenericList<Fabrica> fabricas = new GenericList<Fabrica>();

        public FormAnalisisDeDatos()
        {
            InitializeComponent();
        }

        public FormAnalisisDeDatos(EAgentes agente, string titulo, GenericList<Vehiculo> vehiculos, GenericList<Fabrica> fabricas) : this()
        {
            this.Text = titulo;
            this.agente = agente;
            this.vehiculos = vehiculos;
            this.fabricas = fabricas;
        }

        private void AnalisisDeDatos_Load(object sender, EventArgs e)
        {
            if(agente == EAgentes.Fabricas)
            {
                grpVehiculos.Enabled = false;
            }
            if(agente == EAgentes.Vehiculos)
            {
                grpFabricas.Enabled = false;
            }

            //Combo Box de provincias:
            //Asignaría a una variable de tipo Array el resultado del Enum.GetValues, pero eso haría que ambas listas estuvieran linkeadas,
            //Y mi porpósito es que se puedan comparar los datos entre distintas provincias.
            cmbProvinciaFabrica.DataSource = Enum.GetValues(typeof(EProvincias)); ;
            cmbProvinciaVehiculo.DataSource = Enum.GetValues(typeof(EProvincias)); ;

            //Combo box de tipos:
            cmbTipoFabrica.DataSource = Enum.GetValues(typeof(ETipoFabrica));
            cmbTipoVehiculo.DataSource = Enum.GetValues(typeof(ETipoVehiculo));

            //Text box de Gases emitidos totales:
            txtGasesTotalesFabricas.Text = fabricas.GasesTotales.ToString("N");
            txtGasesTotalesVehiculos.Text = vehiculos.GasesTotales.ToString("N");

            //Text box de Cantidades totales:
            txtCantidadTotalFabricas.Text = fabricas.CantidadTotal.ToString("N");
            txtCantidadTotalVehiculos.Text = vehiculos.CantidadTotal.ToString("N");
            
            //Text box de Gases emitidos totales en provincia seleccionada:
            txtGasesEnProvinciaFabrica.Text = fabricas.ContaminacionEnLaProvincia((EProvincias)cmbProvinciaFabrica.SelectedItem).ToString("N");
            txtGasesEnProvinciaVehiculo.Text = vehiculos.ContaminacionEnLaProvincia((EProvincias)cmbProvinciaVehiculo.SelectedItem).ToString("N");
            
            //Text box de Gases emitidos totales en tipo seleccionado:
            txtToneladasPorTipoFabrica.Text = fabricas.ContaminacionPorTipo((int)(ETipoFabrica)cmbTipoFabrica.SelectedItem).ToString("N");
            txtToneladasPorTipoVehiculo.Text = vehiculos.ContaminacionPorTipo((int)(ETipoVehiculo)cmbTipoVehiculo.SelectedItem).ToString("N");
        }

        private void cmbProvinciaFabrica_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGasesEnProvinciaFabrica.Text = fabricas.ContaminacionEnLaProvincia((EProvincias)cmbProvinciaFabrica.SelectedItem).ToString("N");
        }

        private void cmbProvinciaVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGasesEnProvinciaVehiculo.Text = vehiculos.ContaminacionEnLaProvincia((EProvincias)cmbProvinciaVehiculo.SelectedItem).ToString("N");
        }

        private void cmbTipoFabrica_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtToneladasPorTipoFabrica.Text = fabricas.ContaminacionPorTipo((int)(ETipoFabrica)cmbTipoFabrica.SelectedItem).ToString("N");
        }

        private void cmbTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtToneladasPorTipoVehiculo.Text = vehiculos.ContaminacionPorTipo((int)(ETipoVehiculo)cmbTipoVehiculo.SelectedItem).ToString("N");
        }
    }
}
