using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formularios
{
    public partial class FormInicial : Form
    {
        /// <summary>
        /// Delegado de un evento que se llama desde el manejador de eventos "FormInicial.ManejadorEsperarConexion" -> Linea 89
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public delegate void EsperarConexion(object sender, TiempoAEsperarArgs args);
        
        public static EsperarConexion esperarConexionDelegada;

        public FormInicial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Instancia un formulario de tipo FormAgregarContaminantes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AgentesContaminantesStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAgregarContaminantes form = new FormAgregarContaminantes();

            if(form.ShowDialog() == DialogResult.OK)
            {
                string nombre = form.NombreDelProveedor;
                EAgentes agente = form.Agente;
                FormContaminantes formCont = new FormContaminantes(nombre, agente)
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                formCont.Show();
            }
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalirStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Si se esta cerrando el fomulario, pregunta si se desea salir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormInicial_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }
        
        /// <summary>
        /// Permite cargar los datos de los contaminantes a partir de archivos, 
        /// a traves del formulario FormCargarArchivo. Luego, con el archivo cargado,
        /// instancia un formulario de tipo FormContaminantes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargarDatosStripMenuItem_Click(object sender, EventArgs e)
        {
            FromCargarArchivo formCargarArchivo = new FromCargarArchivo()
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if(formCargarArchivo.ShowDialog() == DialogResult.OK)
            {
                string nombre = formCargarArchivo. Nombre;
                EAgentes agente = formCargarArchivo.Agente;
                GenericList<Vehiculo> listV = formCargarArchivo.Vehiculos;
                GenericList<Fabrica> listF = formCargarArchivo.Fabricas;

                FormContaminantes formCont = new FormContaminantes(nombre, agente, listF, listV)
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                formCont.Show();
            }
        }

        /// <summary>
        /// Evento creado para notificar al usuario de las actividades de las conexiones al servidor SQL.
        /// Si se carga un archivo, se lanza el evento para calcular el tiempo maximo para que se inserten
        /// en la tabla los elementos del archivo.
        /// Si se habre un FormContaminantes, el evento muestra que el tiempo esperado es indeterminado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void ConectandoConElServidorEvento(object sender, TiempoAEsperarArgs args) {
            if (args.tiempoTotal != 0)
                MessageBox.Show(args.mensaje + " \nTiempo maximo estimado: " + args.tiempoTotal + " segundos.", "Conectando con el servidor...");
            else
                MessageBox.Show(args.mensaje + "\nTiempo maximo estimado: indeterminado. ", "Obteniendo datos del servidor...");
        }

        /// <summary>
        /// Manejador de eventos para el delegado de tipo EsperarConexion.
        /// Instancia un objeto de tipo TiempoAEsperarArgs, que deriva de RventArgs, el cual es utilizado
        /// para llamar al evento asociado a la variable esperarConexionDelegada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mensaje"></param>
        /// <param name="cantidadDeElementos"></param>
        /// <param name="tiempoPorElemento"></param>
        public static void ManejadorEsperarConexion(object sender, string mensaje, int cantidadDeElementos, int tiempoPorElemento)
        {
            TiempoAEsperarArgs tiempo = new TiempoAEsperarArgs(mensaje, cantidadDeElementos, tiempoPorElemento);

            if(esperarConexionDelegada != null)
            {
                esperarConexionDelegada.Invoke(sender, tiempo);
            }
        }
    }
}
