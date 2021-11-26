using System;
using System.Text;
using Excepciones;

namespace Entidades
{
    public class Fabrica : Contaminante
    {
        ETipoFabrica tipo;

        #region Constructores

        /// <summary>
        /// Constructor publico sin parámetros utilizado para la deserialización JSON
        /// </summary>
        public Fabrica()
        {
        }

        /// <summary>
        /// Constructor de 5 parámetros, lanza una excepción si el tipo no es válido o la cantidad / gases emitidos no están en su rango correspondiente
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="provincia"></param>
        /// <param name="nombre"></param>
        /// <param name="cantidad"></param>
        /// <param name="gasesEmitidos"></param>
        public Fabrica(ETipoFabrica tipo, EProvincias provincia, string nombre, int cantidad, int gasesEmitidos) : base(provincia, nombre, cantidad, gasesEmitidos)
        {
            if (ComprobarTipo(tipo))
                this.tipo = tipo;
            else
                throw new TipoInvalidoException("Error. El tipo asignado no es un tipo de fabrica valido");

            if (cantidad > 100)
                throw new NumeroFueraDeRangoException("Error. La cantidad de fabricas no puede ser mayor a 100");

            if (gasesEmitidos > 10000000)
                throw new NumeroFueraDeRangoException("Error. La cantidad de gases emitidos no puede ser mayor a 10.000.000 toneladas de CO2 anuales");

            if (gasesEmitidos == 0)
            {
                this.gasesEmitidos = (int)tipo;
            }
        }

        /// <summary>
        /// Constructor de 4 parámetros, lanza una excepción si el tipo no es válido o la cantidad / gases emitidos no están en su rango correspondiente
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="provincia"></param>
        /// <param name="nombre"></param>
        /// <param name="cantidad"></param>
        public Fabrica(ETipoFabrica tipo, EProvincias provincia, string nombre, int cantidad) : this(tipo, provincia, nombre, cantidad, (int)tipo)
        {
        }

        /// <summary>
        /// Constructor de 3 parámetros, lanza una excepción si el tipo no es válido o la cantidad / gases emitidos no están en su rango correspondiente
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="provincia"></param>
        /// <param name="nombre"></param>
        public Fabrica(ETipoFabrica tipo, EProvincias provincia, string nombre) : this(tipo, provincia, nombre, 1, (int)tipo)
        {
        }

        #endregion
        
        #region Propiedades

        public ETipoFabrica TipoFabrica
        {
            get => this.tipo;
            set => this.tipo = value;
        }

        #endregion

        #region Mostrar

        /// <summary>
        /// Muestra todos los datos de la fábrica, haciendo un override al mostrar de la clase Contaminantes,
        /// agregando el tipo de la fábrica.
        /// </summary>
        /// <returns>string Cadena con los datos de la fábria.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.AppendLine(" toneladas de CO2 anuales, \nTipo: " + this.tipo);

            return sb.ToString();
        }

        /// <summary>
        /// Override del método ToString. Devuleve todos los datos de la fábrica.
        /// </summary>
        /// <returns>string Cadena con los datos de la fábria.</returns>
        public override string ToString()
        {
            return Mostrar();
        }

        #endregion

        #region ObtenerDatos

        /// <summary>
        /// Multiplica los gases emitidos por la cantidad de fabricas.
        /// </summary>
        /// <returns>float los gases emitidos multiplicados por la cantidad, en Toneladas</returns>      
        public override float ObtenerGasesEnToneladas()
        {
            return this.GasesEmitidos * this.cantidad;
        }

        /// <summary>
        /// Obtiene los gases totales emitidos por la fabrica, solo si su tipo coincide con el tipo pasado como parámetro.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>float 0 si el tipo no coincide, float la cantidad de gases emitidos si el tipo coincide</returns>
        public override float ObtenerGasesEnElTipo(int tipo, out int coincide)
        {
            float resultado = 0;
            coincide = 0;
            if(tipo == (int)this.tipo)
            {
                coincide += this.Cantidad;
                resultado = this.ObtenerGasesEnToneladas();
            }

            return resultado;
        }


        #endregion

        #region Comprobaciones

        /// <summary>
        /// Devuelve true si el tipo de la fábrica está contenido en el enumerado de tipos de fábricas (ETipoFabrica)
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>bool True si el tipo es correcto.</returns>
        public static bool ComprobarTipo(ETipoFabrica tipo)
        {
            return Enum.IsDefined(typeof(ETipoFabrica), tipo);
        }

        /// <summary>
        /// Devuelve true si es un contaminante valido, el tipo de la fabrica está contenido 
        /// en el enumerado de tipos de fabricas (ETipoFabrica), la cantidad de fabricas y de gases emitidos no supere el limite.
        /// Es utilizado al momento de comprobar los datos de la deserialización JSON.
        /// </summary>
        /// <returns>true si todos los datos son correctos, false si alguno no lo es</returns>
        public override bool ComprobarContaminante()
        {
            bool resultado = false;

            try
            {
                if (this is null)
                    throw new ContaminanteNuloException();
                else
                    resultado = base.ComprobarContaminante() && ComprobarTipo(this.tipo) && cantidad <= 100 && gasesEmitidos <= 10000000;
            }
            catch (ContaminanteNuloException) { }

            return resultado;
        }

        #endregion

        #region Ordenamientos

        /// <summary>
        /// Metodo utilizado para ordenar una lista de fábricas. Implementado en la clase genericList en el método con el mismo nombre.
        /// Ordena de forma ascendente.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>1 si la primer fabrica va primero, 0 si los tipos son iguals, -1 si la segunda fabrica va primero.</returns>
        public static int OrdenarPorTipo(Fabrica a, Fabrica b)
        {
            int resultado = 0;

            if (a.tipo > b.tipo)
            {
                resultado = 1;
            } 
            else if (a.tipo < b.tipo)
            {
                resultado = -1;
            }

            return resultado;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Comprueba que el nombre y la provincia de dos fabricas sean iguales
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>bool True si los nombres y las provincias son iguales.</returns>
        public static bool operator ==(Fabrica a, Fabrica b)
        {
            bool resultado = false;

            try
            {
                if (a is null || b is null)
                    throw new ContaminanteNuloException();
                else
                    resultado = (Contaminante)a == b;
            }
            catch (ContaminanteNuloException) { }

            return resultado;
        }

        /// <summary>
        /// Comprueba que el nombre o la provincia de dos fabricas sean distintos.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>bool Truesi el nombre o la provincia son distintos.</returns>
        public static bool operator !=(Fabrica a, Fabrica b)
        {
            return !(a == b);
        }

        #endregion
    }
}