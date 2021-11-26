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

        float auxFabricasGasesTotales;
        float auxVehiculosGasesTotales;

        int auxFabricasCantidadTotal;
        int auxVehiculosCantidadTotal;

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

            //Text box de Gases emitidos totales:
            auxFabricasGasesTotales = fabricas.GasesTotales;
            auxVehiculosGasesTotales = vehiculos.GasesTotales;
            txtGasesTotalesFabricas.Text = auxFabricasGasesTotales.ToString("N");
            txtGasesTotalesVehiculos.Text = auxVehiculosGasesTotales.ToString("N");

            //Text box de Cantidades totales:
            auxFabricasCantidadTotal = fabricas.CantidadTotal;
            auxVehiculosCantidadTotal = vehiculos.CantidadTotal;
            txtCantidadTotalFabricas.Text = auxFabricasCantidadTotal.ToString("N");
            txtCantidadTotalVehiculos.Text = auxVehiculosCantidadTotal.ToString("N");

            //Combo Box de provincias:
            //Asignaría a una variable de tipo Array el resultado del Enum.GetValues, pero eso haría que ambas listas estuvieran linkeadas,
            //Y mi porpósito es que se puedan comparar los datos entre distintas provincias también.
            cmbProvinciaFabrica.DataSource = Enum.GetValues(typeof(EProvincias)); 
            cmbProvinciaVehiculo.DataSource = Enum.GetValues(typeof(EProvincias));

            //Combo box de tipos:
            cmbTipoFabrica.DataSource = Enum.GetValues(typeof(ETipoFabrica));
            cmbTipoVehiculo.DataSource = Enum.GetValues(typeof(ETipoVehiculo));
        }

        private void cmbProvinciaFabrica_SelectedIndexChanged(object sender, EventArgs e)
        {
            float auxFabricasProvincias = fabricas.ContaminacionEnLaProvincia((EProvincias)cmbProvinciaFabrica.SelectedItem, out int coincidencias);
            txtGasesEnProvinciaFabrica.Text = auxFabricasProvincias.ToString("N");

            float auxPorcentajeGases = auxFabricasProvincias / auxFabricasGasesTotales * 100;

            lblPorcentajeFabricaProvincia.Text = "Esto representa a " + coincidencias.ToString() + " de " + auxFabricasCantidadTotal.ToString() + "\nfabricas, y al " + auxPorcentajeGases.ToString("N") + "% \nde los gases totales \nde las mismas.";
        }

        private void cmbProvinciaVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            float auxVehiculosProvincias = vehiculos.ContaminacionEnLaProvincia((EProvincias)cmbProvinciaVehiculo.SelectedItem, out int coincidencias);
            txtGasesEnProvinciaVehiculo.Text = auxVehiculosProvincias.ToString("N");

            float auxPorcentajeGases = auxVehiculosProvincias / auxVehiculosGasesTotales * 100;

            lblPorcentajeVehiculoProvincia.Text = "Esto representa a " + coincidencias.ToString() + " de " + auxVehiculosCantidadTotal.ToString() + "\nvehiculos y al " + auxPorcentajeGases.ToString("N") + "% \nde los gases totales \nde las mismas.";
        }
        
        private void cmbTipoFabrica_SelectedIndexChanged(object sender, EventArgs e)
        {
            float auxFabricasTipo = fabricas.ContaminacionPorTipo((int)(ETipoFabrica)cmbTipoFabrica.SelectedItem, out int coincidencias);
            txtToneladasPorTipoFabrica.Text = auxFabricasTipo.ToString("N");

            float auxPorcentajeGases = auxFabricasTipo / auxFabricasGasesTotales * 100;

            lblPorcentajeFabricaTipo.Text = "Esto representa a " + coincidencias.ToString() + " de " + auxFabricasCantidadTotal.ToString() + "\nfabricas, y al " + auxPorcentajeGases.ToString("N") + "% \nde los gases totales de las mismas.";
        }

        private void cmbTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            float auxVehiculosTipo = vehiculos.ContaminacionPorTipo((int)(ETipoVehiculo)cmbTipoVehiculo.SelectedItem, out int coincidencias);
            txtToneladasPorTipoVehiculo.Text = auxVehiculosTipo.ToString("N");

            float auxPorcentajeGases = auxVehiculosTipo / auxVehiculosGasesTotales * 100;

            lblPorcentajeVehiculoTipo.Text = "Esto representa a " + coincidencias.ToString() + " de " + auxVehiculosCantidadTotal.ToString() + "\nvehiculos, y al " + auxPorcentajeGases.ToString("N") + "% \nde los gases totales de las mismas.";
        }
    }
}
