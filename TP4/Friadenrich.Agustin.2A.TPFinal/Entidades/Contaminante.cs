using System;
using System.Text;
using Excepciones;

namespace Entidades
{
    public abstract class Contaminante
    {
        protected EProvincias provincia;
        protected string nombre;
        protected int gasesEmitidos;
        protected int cantidad;

        #region Constructores

        /// <summary>
        /// Constructor publico sin parámetros utilizado para la deserialización JSON
        /// </summary>
        public Contaminante()
        {
        }

        /// <summary>
        /// Constructor de cuatro parámetros que lanza excepciones de tipo StringInvalidoException si el nombre está vacío o 
        /// NumeroFueraDeRangoException si los parámetros numéricos son menores o iguales a cero.
        /// </summary>
        /// <param name="provincia"></param>
        /// <param name="nombre"></param>
        /// <param name="cantidad"></param>
        /// <param name="gasesEmitidos"></param>
        public Contaminante(EProvincias provincia, string nombre, int cantidad, int gasesEmitidos)
        {
            if(!String.IsNullOrWhiteSpace(nombre))
            {
                this.nombre = nombre;
            } else
            {
                throw new StringInvalidoException();
            }

            if (gasesEmitidos >= 0)
            {
                this.gasesEmitidos = gasesEmitidos;
            } else
            {
                throw new NumeroFueraDeRangoException("Los gases emitidos no pueden ser negativos. No se puede crear el agente.");
            }

            if (cantidad > 0)
            {
                this.cantidad = cantidad;
            } else
            {
                throw new NumeroFueraDeRangoException("La cantidad no puede ser 0 o negativo. No se puede crear el agente.");
            }

            this.provincia = provincia;
        }

        #endregion

        #region Propiedades

        public string Nombre 
        {
            get => this.nombre;
            set => this.nombre = value;
        }

        public EProvincias Provincia
        {
            get => this.provincia;
            set => this.provincia = value;
        }

        public int GasesEmitidos
        {
            get => this.gasesEmitidos; 
            set => this.gasesEmitidos = value;
        }

        public int Cantidad 
        {
            get => this.cantidad;
            set => this.cantidad = value;
        }

        #endregion

        #region Mostrar

        /// <summary>
        /// Devuelve una cadena con todos los datos del contaminante: nombre, ubicación, cantidad y gases emitidos.
        /// </summary>
        /// <returns>
        /// string Cadena con los datos del contaminante.
        /// </returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nombre: {0}, \n", this.nombre);
            sb.AppendFormat("Ubicación: {0}, \n", this.provincia);
            sb.AppendFormat("Cantidad: {0}, \n", this.cantidad);
            sb.AppendFormat("Gases emitidos: {0}", this.gasesEmitidos);
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve un string con todos los datos del contaminante utilizando el metodo mostrar.
        /// </summary>
        /// <returns>
        /// string Cadena con los datos del contaminante.
        /// </returns>
        public override string ToString()
        {
            return Mostrar();
        }

        #endregion

        #region Obtener Datos

        /// <summary>
        /// Metodo abstracto definido para calcular los gases totales del contaminante en toneladas.
        /// </summary>
        public abstract float ObtenerGasesEnToneladas();

        /// <summary>
        /// Devuelve los gases totales emitidos, en toneladas, si el tipo pasado como parametro es igual al tipo del contaminante.
        /// ES un metodo abstracto ya que el atributo tipo pertenece unicamente a las clases hijas de Contaminates.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>float 0 si el tipo no concuerda, los gases totales emitidos en toneladas si el tipo concuerda</returns>
        public abstract float ObtenerGasesEnElTipo(int tipo);

        #endregion

        #region Comprobaciones

        /// <summary>
        /// Devuelve verdadero si la cantidad, los gases emitidos o el nombre son válidos.
        /// Lanza una excepcion si el contaminante es nulo.
        /// Esto es utilizado para comprobar que la deserialización JSON haya sido correcta.
        /// </summary>
        /// <returns>bool true si los datos del contaminante son válidos. false si algun dato no lo es.</returns>
        public virtual bool ComprobarContaminante()
        {
            bool resultado = false;

            try
            {
                if (this is null)
                    throw new ContaminanteNuloException();
                else
                    resultado = this.cantidad > 0 && this.gasesEmitidos > 0 && !String.IsNullOrWhiteSpace(this.nombre);
            }
            catch (ContaminanteNuloException) { }

            return resultado;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Verifica la igualdad entre dos contaminantes. Solo devolverá true si el nombre y la provincia son iguales
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>
        /// bool True si los nombres y las provincias son iguales
        /// </returns>
        public static bool operator ==(Contaminante a, Contaminante b)
        {
            bool resultado = false;

            try {
                if (a is null || b is null)
                    throw new ContaminanteNuloException();
                else
                    resultado = a.nombre == b.nombre && a.provincia == b.provincia;
            } catch (ContaminanteNuloException) { }
            
            return resultado;
        }

        /// <summary>
        /// Verifica la desigualdad entre dos contaminantes. Solo devolverá true si alguno de los nombres,
        /// o provinicas son diferentes.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>
        /// bool True si el nombre o la provincia son distintos.
        /// </returns>
        public static bool operator !=(Contaminante a, Contaminante b)
        {
            return !(a == b);
        }

        #endregion
    }
}
