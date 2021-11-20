using Entidades;
using System;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            Task.Run(() => ObtenerLista());

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

            this.Text = listaFabrica.Titulo + " / " + listaVehiculo.Titulo;
            
            lblGasesTotalesFabricas.Text = listaFabrica.GasesTotales + " toneladas de CO2";
            lblGasesTotalesVehiculos.Text = listaVehiculo.GasesTotales + " toneladas de CO2";
            
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
            AgregarAgente(EAgentes.Fabricas, listaFabrica.Titulo);            
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            AgregarAgente(EAgentes.Vehiculos, listaFabrica.Titulo);

        }
        private void AgregarAgente(EAgentes agente, string proveedor)
        {
            FormAgregarUnAgente form = new FormAgregarUnAgente(agente, proveedor)
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

        #region Modificar
        private void btnModificarFabrica_Click(object sender, EventArgs e)
        {
            ModificarAgente(EAgentes.Fabricas, (Fabrica)lstFabricas.SelectedItem, listaFabrica.Titulo);
        }

        private void btnModificarVehiculo_Click(object sender, EventArgs e)
        {
            ModificarAgente(EAgentes.Vehiculos, (Vehiculo)lstVehiculos.SelectedItem, listaVehiculo.Titulo);
        }

        private void ModificarAgente(EAgentes agente, Contaminantes contaminante, string proveedor)
        {
            if(contaminante != null)
            {
                FormModificarUnAgente form = new FormModificarUnAgente(agente, contaminante, proveedor)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (agente == EAgentes.Vehiculos)
                    {
                        listaVehiculo -= (Vehiculo)contaminante;
                        listaVehiculo += (Vehiculo)form.Contaminante;
                    }
                    else if (agente == EAgentes.Fabricas)
                    {
                        listaFabrica -= (Fabrica)contaminante;
                        listaFabrica += (Fabrica)form.Contaminante;
                    }

                    ActualizarDatos();
                }
            }
        }
        #endregion

        #region Borrar

        private void btnBorrarFabrica_Click(object sender, EventArgs e)
        {
            listaFabrica -= (Fabrica)this.lstFabricas.SelectedItem;
            ((Fabrica)this.lstFabricas.SelectedItem).Eliminar(listaFabrica.Titulo);
            ActualizarDatos();

        }
        private void btnBorrarVehiculo_Click(object sender, EventArgs e)
        {
            listaVehiculo -= (Vehiculo)this.lstVehiculos.SelectedItem;
            ((Vehiculo)this.lstVehiculos.SelectedItem).Eliminar(listaVehiculo.Titulo);
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
        #endregion

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
            GenericList<Fabrica> auxList = GetListaFabricas();

            foreach (Fabrica item in auxList.Elementos)
            {
                listaFabrica += item;
            }

            this.grpFabricas.Text = "Fabricas - Datos provenientes de: " + listaFabrica.Titulo;
            ActualizarDatos();
        }
        private void btnCargarVehiculos_Click(object sender, EventArgs e)
        {
            GenericList<Vehiculo> auxList = GetListaVehiculos();

            foreach (Vehiculo item in auxList.Elementos)
            {
                listaVehiculo += item;
            }

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
            
            Task task = new Task(() =>
            {
                foreach (Fabrica item in lista.Elementos)
                {
                    item.Agregar(lista.Titulo);
                }
            });

            return lista;
        }

        public static GenericList<Vehiculo> GetListaVehiculos()
        {
            GenericList<Vehiculo> lista = new GenericList<Vehiculo>()
            {
                Titulo = "Sin Nombre"
            };

            MessageBox.Show("Agrege un archivo que contenga vehiculos.");

            string path = Cargar(EAgentes.Vehiculos);

            lista = lista.LeerTodo(path);

            if (lista.Elementos.Count == 0 && !String.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("No se pudieron cargar los datos de vehículos del archivo " + path + ". Este no es un archivo válido.", "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Task task = new Task(() => { 
                foreach (Vehiculo item in lista.Elementos)
                {
                    item.Agregar(lista.Titulo);
                }
            });


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

        private void ObtenerLista()
        {
            int elementosObtenidos = 0;
            FormInicial.esperarConexionDelegada += FormInicial.ConectandoConElServidorEvento;

            if(this.agente != EAgentes.Vehiculos)
            {
                FormInicial.ManejadorEsperarConexion(this, "Se obtendran de la base de datos las fabricas cuyo proveedor sea: " + listaFabrica.Titulo, 0, 5);
                GenericList<Fabrica> listaFabricaAux = new GenericList<Fabrica>(listaFabrica.Titulo);

                listaFabricaAux = SQLExtension.ObtenerFabricas(listaFabrica.Titulo);

                foreach (Fabrica item in listaFabricaAux.Elementos)
                {
                    listaFabrica += item;
                }
                elementosObtenidos += listaFabricaAux.Elementos.Count;
            } 

            if (this.agente != EAgentes.Fabricas)
            {
                FormInicial.ManejadorEsperarConexion(this, "Se obtendran de la base de datos los vehiculos cuyo proveedor sea: " + listaVehiculo.Titulo, 0, 5);
                GenericList<Vehiculo> listaVehiculoAux = new GenericList<Vehiculo>(listaVehiculo.Titulo);

                listaVehiculoAux = SQLExtension.ObtenerVehiculos(listaVehiculo.Titulo);

                foreach (Vehiculo item in listaVehiculoAux.Elementos)
                {
                    listaVehiculo += item;
                }
                elementosObtenidos += listaVehiculoAux.Elementos.Count;
            }

            FormInicial.esperarConexionDelegada -= FormInicial.ConectandoConElServidorEvento;
            MessageBox.Show("Se ha terminado de leer la base de datos. \nSe obtuvieron: " + elementosObtenidos + " elementos.");
        }
    }
}