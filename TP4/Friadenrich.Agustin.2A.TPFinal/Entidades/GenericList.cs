using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Excepciones;

namespace Entidades
{
    public class GenericList<T> : IArchivos<GenericList<T>> where T : Contaminantes
    {
        string titulo;
        List<T> elementos;

        #region Constructores
        /// <summary>
        /// Constructor de la clase que instancia la lista del tipo genérico.s
        /// </summary>
        public GenericList()

        {
            this.elementos = new List<T>();
        }

        /// <summary>
        /// Constructor de la clase que permite asignar el titulo al crearla.
        /// </summary>
        /// <param name="titulo"></param>
        public GenericList(string titulo) : this()
        {
            this.titulo = titulo;
        }

        #endregion

        #region Propiedades y Metodos de calculos totales.

        public string Titulo
        {
            get => this.titulo; 
            set => this.titulo = value;
        }

        public List<T> Elementos 
        { 
            get => this.elementos; 
            set => this.elementos = value; 
        }
        
        /// <summary>
        /// Poropiedad que devuelve la suma total de todos los gases contaminantes 
        /// emitidos por los objetos contenidos en la lista.
        /// </summary>
        public float GasesTotales
        {
            get
            {
                float resultado = 0;

                foreach (T item in this.elementos)
                {
                    resultado += item.ObtenerGasesEnToneladas();

                }

                return resultado;
            }
        }

        /// <summary>
        /// Propiedad que devuelve la suma de las cantidades de todos los objetos que pertenecen a la lista.
        /// </summary>
        public int CantidadTotal
        {
            get
            {
                int resultado = 0;

                foreach(T item in this.Elementos)
                {
                    resultado += item.Cantidad;
                }

                return resultado;
            }
        }

        /// <summary>
        /// Calcula la suma total de los gases de efecto invernadero emitidos por todos los objetos 
        /// que tengan como provinica la provincia pasada como parametro.
        /// </summary>
        /// <param name="provincia"></param>
        /// <returns>float los gases de efecto invernadero emitidos por la provinica pasada como parametro</returns>
        public float ContaminacionEnLaProvincia(EProvincias provincia)
        {
            float resultado = 0;

            foreach (T item in this.elementos)
            {
                if(item.Provincia == provincia)
                {
                    resultado += item.ObtenerGasesEnToneladas();
                }
            }

            return resultado;
        }

        /// <summary>
        /// Calcula la suma total de los gases de efecto invernadero emitidos por los objetos
        /// que tengan como tipo el tipo pasado como parámetro.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>float los gases totales emitidos por el tipo seleccionado</returns>
        public float ContaminacionPorTipo(int tipo)
        {
            float resultado = 0;

            foreach (T item in this.elementos)
            {
                    resultado += item.ObtenerGasesEnElTipo(tipo);
            }

            return resultado;
        }

        #endregion

        #region listar

        /// <summary>
        /// Crea una cadena con todos los items contenidos en la lista.
        /// </summary>
        /// <returns>string Cadena con datos de la lista.</returns>
        public string Listar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Se muestra la lista generica: ");
            sb.AppendLine("\n========================================================================");
            
            foreach(T item in Elementos)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("-------------------------------------------------------------------------");

            sb.AppendLine("\nGases Totales de la lista: " + GasesTotales);
            sb.AppendLine("Cantidad Total de la lista: " + CantidadTotal);

            sb.AppendLine("========================================================================");

            return sb.ToString();
        }

        #endregion

        #region IArchivos
        /// <summary>
        /// Crea una cadena con todos los objetos de la lista como objetos JSON.
        /// </summary>
        /// <returns>string Cadena con todos los objetos como JSON de la lista</returns>
        public string TransformarTodoAJSON()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Guarda la cadena JSON en la dirección pasada como parametro.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="json"></param>
        public void GuardarTodo(string path)
        {
            StreamWriter sw = new StreamWriter(path);

            sw.Write(TransformarTodoAJSON());

            sw.Close();
        }

        /// <summary>
        /// Lee un objeto JSON y lo deserializa a un objeto del tipo genérico. 
        /// Lanza una excepción si la cadena es vacía o nula.
        /// </summary>
        /// <param name="json"></param>
        /// <returns>T objeto deserializado</returns>
        public GenericList<T> LeerJSON(string json)
        {
            GenericList<T> resultado = new GenericList<T>("Sin nombre");
            if (!String.IsNullOrWhiteSpace(json))
            {
                try
                {
                    resultado = JsonConvert.DeserializeObject<GenericList<T>>(json);
                } catch (JsonSerializationException) { }
            }
            else
            {
                throw new ContaminanteNuloException("No se ha podido leer el archivo correctamente.");
            }
            return resultado;
        }

        /// <summary>
        /// Deserializa toda una lista genérica a partir de un archivo. 
        /// Obtiene también la cadena que esá en el primer renglón del archivo.
        /// Controla la excepcion ContaminanteNUloExcepcion que puede ser lanzada pro el metodo LeerTodo
        /// </summary>
        /// <param name="path"></param>
        /// <param name="nombre"></param>
        /// <returns>GenericList T la lista con los objetos del tipo genérico deserializada.</returns>
        public GenericList<T> LeerTodo(string path)
        {
            GenericList<T> lista = new GenericList<T>
            {
                titulo = "Sin nombre"
            };

            try
            {
                if (!String.IsNullOrWhiteSpace(path))
                {
                    StreamReader sr = new StreamReader(path);
                    lista = LeerJSON(sr.ReadToEnd());
                    sr.Close();
                }
            }
            catch (ContaminanteNuloException) { }

            if (!(bool)lista)
            {
                lista.Borrar();
            }

            return lista;
        }
        #endregion

        #region Ordenamientos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordenamiento"></param>
        public void OrdenarLista(Ordenamientos ordenamiento)
        {
            switch (ordenamiento)
            {
                case Ordenamientos.Nombre:
                    this.elementos.Sort(OrdenarPorNombre);
                    break;
                case Ordenamientos.Provincia:
                    this.elementos.Sort(OrdenarPorProvincia);
                    break;
                case Ordenamientos.Cantidad:
                    this.elementos.Sort(OrdenarPorCantidad);
                    break;
                case Ordenamientos.Gases_Emitidos:
                    this.elementos.Sort(OrdenarPorGasesEmitidos);
                    break;
                case Ordenamientos.Tipo:
                    this.elementos.Sort(OrdenarPorTipo);
                    break;
                default:
                    break;
            }
        }

        private static int OrdenarPorNombre(T a, T b)
        {
            return string.Compare(a.Nombre, b.Nombre);
        }

        private static int OrdenarPorProvincia(T a, T b)
        {
            int retorno = 0;

            if (a.Provincia > b.Provincia)
            {
                retorno = 1;
            }
            else if (a.Provincia < b.Provincia)
            {
                retorno = -1;
            }

            return retorno;
        }


        private static int OrdenarPorCantidad(T a, T b)
        {
            int retorno = 0;

            if (a.Cantidad > b.Cantidad)
            {
                retorno = 1;
            }
            else if (a.Cantidad < b.Cantidad)
            {
                retorno = -1;
            }

            return retorno;
        }


        private static int OrdenarPorGasesEmitidos(T a, T b)
        {
            int retorno = 0;

            if (a.GasesEmitidos > b.GasesEmitidos)
            {
                retorno = 1;
            }
            else if (a.GasesEmitidos < b.GasesEmitidos)
            {
                retorno = -1;
            }

            return retorno;
        }

        public static int OrdenarPorTipo(T a, T b)
        {
            int resultado = 0;
            if(a is Fabrica fA && b is Fabrica fB)
            {
                resultado = Fabrica.OrdenarPorTipo(fA, fB);
            } else if (a is Vehiculo vA && b is Vehiculo vB)
            {
                resultado = Vehiculo.OrdenarPorTipo(vA, vB);
            }
            return resultado;
        }

        #endregion

        #region Operadores
        /// <summary>
        /// Elimina todos los datos de la lista genérica.
        /// </summary>
        public void Borrar()
        {
            this.elementos.Clear();
        }

        /// <summary>
        /// Agrega a la lista genérica un elemento del tipo genérico, antes, comprobando que no esté contenido en la lista
        /// y que el elemento sea válido.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="elemento"></param>
        /// <returns>GenericList T  La lista actualizada habiendo agregado el elemento o no./returns>
        public static GenericList<T> operator +(GenericList<T> lista, T elemento)
        {
            bool existe = false;

            try
            {
                if (elemento is null)
                    throw new ContaminanteNuloException();

                foreach (T item in lista.elementos)
                {
                    if (item == elemento)
                    {
                        existe = true;
                    }
                }
                if (!existe && elemento.ComprobarContaminante())
                {
                    lista.elementos.Add(elemento);
                }

            }
            catch (ContaminanteNuloException) { }

            return lista;
        }

        /// <summary>
        /// Quita el elemento pasado como parámetro de la lista si éste está contenido en ella. 
        /// De lo contrario, no realiza ninguna acción
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="elemento"></param>
        /// <returns>GenericList T La lista actualizada habiendo eliminado el elemento.</returns>
        public static GenericList<T> operator -(GenericList<T> lista, T elemento)
        {
            foreach (T item in lista.elementos)
            {
                if (item == elemento)
                {
                    lista.elementos.Remove(item);
                    break;
                }
            }

            return lista;
        }

        /// <summary>
        /// Sobrecarga del operador bool. Comprueba que todos los elementos de la lista sean del tipo
        /// corrpesontdiente. Devuelve false si alguno es distinto.
        /// </summary>
        /// <param name="a"></param>
        public static explicit operator bool(GenericList<T> a)
        {
            bool resultado = true;

            foreach (T item in a.Elementos)
            {
                if (!item.ComprobarContaminante())
                {
                    resultado = false;
                    break;
                }
            }

            return resultado;
        }

        #endregion
    }
}
