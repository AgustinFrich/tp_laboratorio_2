using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Entidades;

namespace Formularios
{
    public partial class FromCargarArchivo : Form
    {
        EAgentes agente;
        GenericList<Fabrica> fabricas = new GenericList<Fabrica>();
        GenericList<Vehiculo> vehiculos = new GenericList<Vehiculo>();
        string nombre;

        public EAgentes Agente { get { return this.agente; } }
        public GenericList<Fabrica> Fabricas { get { return this.fabricas; } }
        public GenericList<Vehiculo> Vehiculos { get { return this.vehiculos; } }
        public string Nombre { get { return this.nombre; } }

        public FromCargarArchivo()
        {
            InitializeComponent();
        }

        private void CargarAmbos_Click(object sender, EventArgs e)
        {
            fabricas = FormContaminantes.GetListaFabricas();
            vehiculos = FormContaminantes.GetListaVehiculos();
            this.nombre = fabricas.Titulo + " / " + vehiculos.Titulo;
            this.DialogResult = DialogResult.OK;
        }

        private void CargarFabricas_Click(object sender, EventArgs e)
        {
            this.agente = EAgentes.Fabricas;
            fabricas = FormContaminantes.GetListaFabricas();
            this.nombre = Fabricas.Titulo;
            this.DialogResult = DialogResult.OK;
        }

        private void CargarVehiculos_Click(object sender, EventArgs e)
        { 
            this.agente = EAgentes.Vehiculos;
            vehiculos = FormContaminantes.GetListaVehiculos();
            this.nombre = vehiculos.Titulo;
            this.DialogResult = DialogResult.OK;
        }
    }
}
