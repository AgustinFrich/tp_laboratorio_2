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

        /// <summary>
        /// Agrega el evento ConenctandoConElServidorEvento al evento del form inicial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FromCargarArchivo_Load(object sender, EventArgs e)
        {
            FormInicial.esperarConexionDelegada += FormInicial.ConectandoConElServidorEvento;
        }

        /// <summary>
        /// Permite la carga de un archivo para las fabricas y otro para los vehiculos.
        /// LLama al manejador de eventos que calculara el tiempo maximo que tardará el programa en subir todos los datos de los archivos al servidor.
        /// Asigna la variable nombre en funcion de los proveedores de las listas de los archivos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargarAmbos_Click(object sender, EventArgs e)
        {
            fabricas = FormContaminantes.GetListaFabricas();
            vehiculos = FormContaminantes.GetListaVehiculos();
            FormInicial.ManejadorEsperarConexion(sender, "Se agregaran las fabricas y los vehiculos a la base de datos en segundo plano.", fabricas.Elementos.Count + vehiculos.Elementos.Count, 5);
            this.nombre = fabricas.Titulo + " / " + vehiculos.Titulo;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Permite la carga de un archivo de fabricas.
        /// LLama al manejador de eventos que calculara el tiempo maximo que tardará el programa en subir todos los datos del archivo al servidor.
        /// Asigna la variable nombre en funcion del proveedor de la lista del archivo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargarFabricas_Click(object sender, EventArgs e)
        {
            this.agente = EAgentes.Fabricas;
            fabricas = FormContaminantes.GetListaFabricas();
            FormInicial.ManejadorEsperarConexion(sender, "Se agregaran las fabricas a la base de datos en segundo plano.", fabricas.Elementos.Count, 5);
            this.nombre = fabricas.Titulo;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Permite la carga de un archivo de vehiculos.
        /// LLama al manejador de eventos que calculara el tiempo maximo que tardará el programa en subir todos los datos del archivo al servidor.
        /// Asigna la variable nombre en funcion del proveedor de la lista del archivo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargarVehiculos_Click(object sender, EventArgs e)
        { 
            this.agente = EAgentes.Vehiculos;
            vehiculos = FormContaminantes.GetListaVehiculos();
            FormInicial.ManejadorEsperarConexion(sender, "Se agregaran los vehiculos a la base de datos en segundo plano.", vehiculos.Elementos.Count, 5);
            this.nombre = vehiculos.Titulo;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Desasocia el evento con el manejador de eventos cuando se cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCargarArchivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormInicial.esperarConexionDelegada -= FormInicial.ConectandoConElServidorEvento;
        }
    }
}
