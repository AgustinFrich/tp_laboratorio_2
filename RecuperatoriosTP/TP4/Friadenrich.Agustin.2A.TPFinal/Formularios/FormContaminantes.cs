using Entidades;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Formularios
{
    public partial class FormContaminantes : Form
    {
        GenericList<Fabrica> listaFabrica;
        GenericList<Vehiculo> listaVehiculo;

        private EAgentes agente;

        #region Constructores

        public FormContaminantes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor que toma 2 parametros. Asigna el nobre y el agente pasados como parametros, 
        /// luego instanica las listas y les asigna asigna los titulos correspondientes.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="agente"></param>
        public FormContaminantes(string nombre, EAgentes agente) : this()
        {
            this.lblTitle.Text = "Analisis de agentes contaminantes: " + agente;
            this.agente = agente;
            listaFabrica = new GenericList<Fabrica>();
            listaVehiculo = new GenericList<Vehiculo>();
            listaFabrica.Titulo = nombre;
            listaVehiculo.Titulo = nombre;
        }

        /// <summary>
        /// Constructor que toma 4 parametros. LLama al constructor de dos parametros y luego asigna las listas pasadas como parametro.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="agente"></param>
        /// <param name="fabricas"></param>
        /// <param name="vehiculos"></param>
        public FormContaminantes(string nombre, EAgentes agente, GenericList<Fabrica> fabricas, GenericList<Vehiculo> vehiculos) : this(nombre, agente)
        {
            this.listaFabrica = fabricas;
            this.listaVehiculo = vehiculos;
        }

        #endregion

        #region Cargar y Actualizar Datos
        
        /// <summary>
        /// 1º Obtiene en segundo plano de la base de datos SQL los agentes que tengan el mismo proveedor que las listas
        /// 2º Asigna los datos para mostrar de donde vienen los datos y los enumerados para los ordenamientos.
        /// 3º Desabilita las opciones de fabircas o vehiculos si estos no fueron seleccionados al crear el formulario.
        /// 4º Asigna el titulo del formulario y calcula los gases totales de las listas para mostrarlos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormContaminantes_Load(object sender, EventArgs e)
        {
            Task task = Task.Run(() => ObtenerLista());

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
            
            if (!task.IsCompleted)
            {
                ActualizarDatos();
            }

            task.Wait();
            ActualizarDatos();
        }


        /// <summary>
        /// Actualiza todos los datos luego de realizar cualquier accion.
        /// 1º Borra los datos de los listBoxs y reasigna el titulo del formulario.
        /// 2º Vuelve a agregar los datos de las listas a los listboxs para que se muestren los cambios.
        /// 3º Vuelve a calcular los gases totales emitidos por lista.
        /// </summary>
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

        #endregion

        #region Agregar

        private void btnAgregarFabrica_Click(object sender, EventArgs e)
        {
            AgregarAgente(EAgentes.Fabricas, listaFabrica.Titulo);            
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            AgregarAgente(EAgentes.Vehiculos, listaFabrica.Titulo);

        }

        /// <summary>
        /// Agrega un agente a la lista correspondiente a traves del formulario FormAgregarUnAgente.
        /// Luego, actualiza los datos si se agrego correctamente.
        /// </summary>
        /// <param name="agente"></param>
        /// <param name="proveedor"></param>
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

        /// <summary>
        /// Permite modificar un agente de la lista asignada a traves del formulario FormModificarUnAgente.
        /// Luego, acutaliza los datos en caso de haber podido modificarlo correctamente.
        /// </summary>
        /// <param name="agente"></param>
        /// <param name="contaminante"></param>
        /// <param name="proveedor"></param>
        private void ModificarAgente(EAgentes agente, Contaminante contaminante, string proveedor)
        {
            if(!(contaminante is null))
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

        /// <summary>
        /// Elimina la fabrica seleccionada, tanto de la lista como la base de datos SQL.
        /// Luego, actualiza los datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrarFabrica_Click(object sender, EventArgs e)
        {
            listaFabrica -= (Fabrica)this.lstFabricas.SelectedItem;
            ((Fabrica)this.lstFabricas.SelectedItem).EliminarASQL(listaFabrica.Titulo);
            ActualizarDatos();

        }

        /// <summary>
        /// Elimina el vehiculo seleccionado, tanto de la lista como la base de datos SQL.
        /// Luego, actualiza los datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrarVehiculo_Click(object sender, EventArgs e)
        {
            listaVehiculo -= (Vehiculo)this.lstVehiculos.SelectedItem;
            ((Vehiculo)this.lstVehiculos.SelectedItem).EliminarASQL(listaVehiculo.Titulo);
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
        /// Guarda una lista en el archivo que se seleccione, en formato JSON.
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
                MessageBox.Show("No se pudo guardar.", "Error");
            }
        }

        #endregion

        #region Carga de datos

        /// <summary>
        /// Carga las fabricas desde un archivo seleccionado. Luego añade los resultados a la lista ya exitente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarFabricas_Click(object sender, EventArgs e)
        {
            GenericList<Fabrica> auxList = GetListaFabricas();

            FormInicial.esperarConexionDelegada += FormInicial.ConectandoConElServidorEvento;
            FormInicial.ManejadorEsperarConexion(sender, "Se agregaran las fabricas del archivo a la base de datos en segundo plano.", auxList.Elementos.Count, 5);

            foreach (Fabrica item in auxList.Elementos)
            {
                listaFabrica += item;
            }

            this.grpFabricas.Text = "Fabricas - Datos provenientes de: " + listaFabrica.Titulo;

            FormInicial.esperarConexionDelegada -= FormInicial.ConectandoConElServidorEvento;

            ActualizarDatos();
        }

        /// <summary>
        /// Carga los vehiculos desde un archivo seleccionado. Luego añade los resultados a la lista ya exitente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarVehiculos_Click(object sender, EventArgs e)
        {
            GenericList<Vehiculo> auxList = GetListaVehiculos();

            FormInicial.esperarConexionDelegada += FormInicial.ConectandoConElServidorEvento;
            FormInicial.ManejadorEsperarConexion(sender, "Se agregaran los vehiculos del archivo a la base de datos en segundo plano.", auxList.Elementos.Count, 5);

            foreach (Vehiculo item in auxList.Elementos)
            {
                listaVehiculo += item;
            }

            this.grpVehiculos.Text = "Vehiculos - Datos provenientes de: " + listaVehiculo.Titulo;

            FormInicial.esperarConexionDelegada -= FormInicial.ConectandoConElServidorEvento;

            ActualizarDatos();
        }

        /// <summary>
        /// Carga las fabricas desde un archivo seleccionado, 
        /// a la vez que agrega los datos del mismo a la base de datos SQL en segundo plano.
        /// </summary>
        /// <returns></returns>
        public static GenericList<Fabrica> GetListaFabricas()
        {
            GenericList<Fabrica> lista = new GenericList<Fabrica>()
            {
                Titulo = "Sin Nombre"
            };

            MessageBox.Show("Agrege un archivo que contenga fabricas.", "Cargando fabricas");

            string path = Cargar(EAgentes.Fabricas);

            lista = lista.LeerTodo(path);

            if(lista.Elementos.Count == 0 && !String.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("No se pudieron cargar los datos de fábricas del archivo " + path + ". Este no es un archivo válido.", "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            Task.Run(() =>
            {
                try
                {
                    foreach (Fabrica item in lista.Elementos)
                    {
                        item.AgregarASQL(lista.Titulo);
                    }
                }
                catch (InvalidOperationException) { }
            });

            return lista;
        }

        /// <summary>
        /// Carga las fabricas desde un archivo seleccionado, 
        /// a la vez que agrega los datos del mismo a la base de datos SQL en segundo plano.
        /// </summary>
        /// <returns></returns>
        public static GenericList<Vehiculo> GetListaVehiculos()
        {
            GenericList<Vehiculo> lista = new GenericList<Vehiculo>()
            {
                Titulo = "Sin Nombre"
            };

            MessageBox.Show("Agrege un archivo que contenga vehiculos.", "Cargando vehiculos");

            string path = Cargar(EAgentes.Vehiculos);

            lista = lista.LeerTodo(path);

            if (lista.Elementos.Count == 0 && !String.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("No se pudieron cargar los datos de vehículos del archivo " + path + ". Este no es un archivo válido.", "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Task.Run(() => {
                try
                {
                    foreach (Vehiculo item in lista.Elementos)
                    {
                        item.AgregarASQL(lista.Titulo);
                    }
                } catch (InvalidOperationException) { }
            });

            return lista;
        }

        /// <summary>
        /// Abre un OpenFileDialog para obtener la ruta del archivo a cargar.
        /// </summary>
        /// <param name="agente"></param>
        /// <returns></returns>
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
        /// Muestra el formulario de analisis de datos con los datos de las listas de fabricas y vehiculos.
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

        #region Obtener Listas en segundo plano

        /// <summary>
        /// Obtiene de la base de datos SQL todas las fabricas y/o vehiculos (dependeindo el tipo de agentes seleccionado)
        /// que contengan el mismo proveedor que el seleccionado (ya sea a traves de la carga de un archivo o de 
        /// istanciar el form a traves de "Agregar contaminantes") y los agrega a las listas actuales.
        /// Tambien llama al manejador de eventos del FormInical para advertir de que se estan cargando los datos en segundo plano.
        /// </summary>
        private void ObtenerLista()
        {
            int elementosObtenidos = 0;
            FormInicial.esperarConexionDelegada += FormInicial.ConectandoConElServidorEvento;

            if(this.agente != EAgentes.Vehiculos)
            {
                FormInicial.ManejadorEsperarConexion(this, "Se obtendran de la base de datos las fabricas cuyo proveedor sea: " + listaFabrica.Titulo, 0, 5);
                GenericList<Fabrica> listaFabricaAux = new GenericList<Fabrica>(listaFabrica.Titulo);

                listaFabricaAux = SQLExtension.ObtenerFabricasSQL(listaFabrica.Titulo);

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

                listaVehiculoAux = SQLExtension.ObtenerVehiculosSQL(listaVehiculo.Titulo);

                foreach (Vehiculo item in listaVehiculoAux.Elementos)
                {
                    listaVehiculo += item;
                }
                elementosObtenidos += listaVehiculoAux.Elementos.Count;
            }

            FormInicial.esperarConexionDelegada -= FormInicial.ConectandoConElServidorEvento;
            MessageBox.Show("Se ha terminado de leer la base de datos. \nSe obtuvieron: " + elementosObtenidos + " elementos.", "Lectura finalizada");
        }

        #endregion
    }
}