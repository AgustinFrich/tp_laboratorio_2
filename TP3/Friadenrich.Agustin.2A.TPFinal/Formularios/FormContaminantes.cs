using Entidades;
using System;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;

namespace Formularios
{
    public partial class FormContaminantes : Form
    {
        GenericList<Fabrica> listaFabrica = new GenericList<Fabrica>();
        GenericList<Vehiculo> listaVehiculo = new GenericList<Vehiculo>();

        private EAgentes agente;
        public FormContaminantes()
        {
            InitializeComponent();
        }

        public FormContaminantes(string nombre, EAgentes agente) : this()
        {
            this.lblTitle.Text = "Analisis de agentes contaminantes: " + agente;
            this.agente = agente;
            listaFabrica.Titulo = nombre;
            listaVehiculo.Titulo = nombre;
        }

        public FormContaminantes(string nombre, EAgentes agente, GenericList<Fabrica> fabricas, GenericList<Vehiculo> vehiculos) : this(nombre, agente)
        {
            this.listaFabrica = fabricas;
            this.listaVehiculo = vehiculos;
        }

        private void FormContaminantes_Load(object sender, EventArgs e)
        {
            this.grpFabricas.Text = "Fabricas - Datos provenientes de: " + listaFabrica.Titulo;
            this.grpVehiculos.Text = "Vehiculos - Datos provenientes de: " + listaVehiculo.Titulo;
            this.cmbOrdenarFabricas.DataSource = Enum.GetValues(typeof(Ordenamientos));
            this.cmbOrdenarVehiculos.DataSource = Enum.GetValues(typeof(Ordenamientos));

            if (agente == EAgentes.Fabricas)
            {
                this.grpVehiculos.Enabled = false;
                this.lstVehiculos.Visible = false;
                this.btnAgregarVehiculo.Enabled = false;
                this.btnBorrarVehiculo.Enabled = false;
                this.btnGuardarVehiculos.Enabled = false;
                this.cmbOrdenarVehiculos.Enabled = false;
            }
            else if (agente == EAgentes.Vehiculos)
            {
                this.grpFabricas.Enabled = false;
                this.lstFabricas.Visible = false;
                this.btnAgregarFabrica.Enabled = false;
                this.btnBorrarFabrica.Enabled = false;
                this.btnGuardarFábricas.Enabled = false;
                this.cmbOrdenarFabricas.Enabled = false;
            }

            ActualizarDatos();
        }

        private void ActualizarDatos()
        {
            this.Text = listaFabrica.Titulo + " / " + listaVehiculo.Titulo;
            this.lstVehiculos.Items.Clear();
            this.lstFabricas.Items.Clear();

            foreach (Vehiculo item in listaVehiculo.Elementos)
            {
                lstVehiculos.Items.Add(item);
            }

            foreach (Fabrica item in listaFabrica.Elementos)
            {
                lstFabricas.Items.Add(item);
            }

            lblGasesTotalesFabricas.Text = listaFabrica.GasesTotales + " toneladas de CO2";
            lblGasesTotalesVehiculos.Text = listaVehiculo.GasesTotales + " toneladas de CO2";
        }

        #region Agregar
        private void btnAgregarFabrica_Click(object sender, EventArgs e)
        {
            AgregarAgente(EAgentes.Fabricas);
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            AgregarAgente(EAgentes.Vehiculos);

        }
        private void AgregarAgente(EAgentes agente)
        {
            FormAgregarUnAgente form = new FormAgregarUnAgente(agente)
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (agente == EAgentes.Vehiculos)
                {
                    listaVehiculo += (Vehiculo)form.Contaminantes;

                } else if (agente == EAgentes.Fabricas)
                {
                    listaFabrica += (Fabrica)form.Contaminantes;
                }

                ActualizarDatos();
            }
        }
        #endregion

        #region Borrar

        private void btnBorrarFabrica_Click(object sender, EventArgs e)
        {
            listaFabrica -= (Fabrica)this.lstFabricas.SelectedItem;
            ActualizarDatos();

        }
        private void btnBorrarVehiculo_Click(object sender, EventArgs e)
        {
            listaVehiculo -= (Vehiculo)this.lstVehiculos.SelectedItem;
            ActualizarDatos();
        }
        #endregion

        #region Cargar y Guardar arcghivos

        /// <summary>
        /// Función encargada de abrir un cuadro de dialogo para obtener el path de un archivo.
        /// Recibe un objeto de tipo FileDialog como parámetro. Esto determinará si se abre el gestor
        /// de archivos para abrir o para guardar.
        /// </summary>
        /// <param name="dialog"></param>
        /// <returns>string el path del archivo seleccionado</returns>
        public static string GetPath(FileDialog dialog)
        {
            string path = "";
            dialog.InitialDirectory = Environment.CurrentDirectory;
            dialog.Filter = "JSON files | *.json";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.FileName;
            }

            return path;
        }

        #region Guardados

        private void btnGuardarFábricas_Click(object sender, EventArgs e)
        {
            Guardar(EAgentes.Fabricas);
        }

        private void btnGuardarVehiculos_Click(object sender, EventArgs e)
        {
            Guardar(EAgentes.Vehiculos);
        }

        private void btnGuardarAmbos_Click(object sender, EventArgs e)
        {
            Guardar(EAgentes.Fabricas);
            Guardar(EAgentes.Vehiculos);
        }

        /// <summary>
        /// Guarda una lista 
        /// </summary>
        /// <param name="agente"></param>
        private void Guardar(EAgentes agente)
        {
            string path;

            path = GetPath(new SaveFileDialog()
            {
                Title = "Guardar archivo de: " + agente
            });
            
            if(!String.IsNullOrWhiteSpace(path))
            {
                if (agente == EAgentes.Fabricas)
                    listaFabrica.GuardarTodo(path);
                else if (agente == EAgentes.Vehiculos)
                    listaVehiculo.GuardarTodo(path);
            } else
            {
                MessageBox.Show("No se pudo guardar.");
            }
        }
        #endregion

        #region Carga de datos

        private void btnCargarFabricas_Click(object sender, EventArgs e)
        {
            listaFabrica = GetListaFabricas();
            this.grpFabricas.Text = "Fabricas - Datos provenientes de: " + listaFabrica.Titulo;
            ActualizarDatos();
        }
        private void btnCargarVehiculos_Click(object sender, EventArgs e)
        {
            listaVehiculo = GetListaVehiculos();
            this.grpVehiculos.Text = "Vehiculos - Datos provenientes de: " + listaVehiculo.Titulo;
            ActualizarDatos();
        }

        public static GenericList<Fabrica> GetListaFabricas()
        {
            GenericList<Fabrica> lista = new GenericList<Fabrica>()
            {
                Titulo = "Sin Nombre"
            };
            MessageBox.Show("Agrege un archivo que contenga fabricas.");
            string path = Cargar(EAgentes.Fabricas);
            lista = lista.LeerTodo(path);
            if(lista.Elementos.Count == 0 && !String.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("No se pudieron cargar los datos de fábricas del archivo " + path + ". Este no es un archivo válido.", "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return lista ;
        }

        public static GenericList<Vehiculo> GetListaVehiculos()
        {
            MessageBox.Show("Agrege un archivo que contenga vehiculos.");
            GenericList<Vehiculo> lista = new GenericList<Vehiculo>();
            string path = Cargar(EAgentes.Vehiculos);
            lista = lista.LeerTodo(path);
            if (lista.Elementos.Count == 0 && !String.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("No se pudieron cargar los datos de vehículos del archivo " + path + ". Este no es un archivo válido.", "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return lista;
        }

        public static string Cargar(EAgentes agente)
        {
            string path = GetPath(new OpenFileDialog()
            {
                Title = "Cargar archivo de: " + agente,
                Multiselect = false
            });

            return path;
        }

        #endregion

        #endregion

        #region Analisis De Datos

        /// <summary>
        /// Muestra el formulario de analisis de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            FormAnalisisDeDatos form = new FormAnalisisDeDatos(agente, this.Text, listaVehiculo, listaFabrica)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            form.ShowDialog();
        }

        #endregion

        #region Ordenamientos

        private void cmbOrdenarFabricas_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaFabrica.OrdenarLista((Ordenamientos)cmbOrdenarFabricas.SelectedItem);
            ActualizarDatos();
        }

        private void cmbOrdenarVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaVehiculo.OrdenarLista((Ordenamientos)cmbOrdenarVehiculos.SelectedItem);
            ActualizarDatos();
        }

        #endregion
    }
}