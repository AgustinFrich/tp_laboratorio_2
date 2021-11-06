using System;
using System.Text;
using Excepciones;

namespace Entidades
{
    public class Vehiculo : Contaminantes
    {
        ETipoVehiculo tipo;

        #region Constructores

        /// <summary>
        /// Constructor publico sin parámetros utilizado para la deserialización JSON
        /// </summary>
        private Vehiculo()
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
        public Vehiculo(ETipoVehiculo tipo, EProvincias provincia, string nombre, int cantidad, int gasesEmitidos) :base(provincia, nombre, cantidad, gasesEmitidos)
        {
            if (ComprobarTipo(tipo))
                this.tipo = tipo;
            else
                throw new TipoInvalidoException("Error. El tipo asignado no es un tipo de vehiculo valido");

            if (cantidad > 100000)
                throw new NumeroFueraDeRangoException("Error. La cantidad de vehiculos no puede ser mayor a 100.000");

            if (gasesEmitidos > 5000)
                throw new NumeroFueraDeRangoException("Error. La cantidad de gases emitidos en por vehiculo no puede ser mayor a 5.000 kg de CO2 anuales");

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
        public Vehiculo(ETipoVehiculo tipo, EProvincias provincia, string nombre, int cantidad) : this(tipo, provincia, nombre, cantidad, (int)tipo)
        {
        }

        /// <summary>
        /// Constructor de 3 parámetros, lanza una excepción si el tipo no es válido o la cantidad / gases emitidos no están en su rango correspondiente
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="provincia"></param>
        /// <param name="nombre"></param>
        public Vehiculo(ETipoVehiculo tipo, EProvincias provincia, string nombre) : this(tipo, provincia, nombre, 1)
        {
        }

        #endregion

        #region Propiedades

        public ETipoVehiculo TipoVehiculo
        {
            get => this.tipo;
            set => this.tipo = value;
        }

        #endregion

        #region Mostrar

        /// <summary>
        /// Muestra todos los datos del vehiculo, haciendo un override al mostrar de la clase Contaminantes,
        /// agregando el tipo del vehiculo.
        /// </summary>
        /// <returns>cadena con los datos del vehiculo</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.AppendLine(" kilogramos de CO2 anuales, \nTipo: " + this.tipo);

            return sb.ToString();
        }

        /// <summary>
        /// Override del método ToString. Devuleve todos los datos del vehiculo.
        /// </summary>
        /// <returns>cadena con los datos del vehiculo</returns>
        public override string ToString()
        {
            return Mostrar();
        }

        #endregion

        #region ObtenerDatos

        /// <summary>
        /// Multiplica los gases emitidos por la cantidad de fabricas, pero antes divide los gases emitidos por 1000 para
        /// transformarlos de kilogramos a toneladas de CO2.
        /// </summary>
        /// <returns>float los gases emitidos multiplicados por la cantidad, en Toneladas</returns>      
        public override float ObtenerGasesEnToneladas()
        {
            return ((float)this.GasesEmitidos / 1000) * this.cantidad;
        }

        /// <summary>
        /// Obtiene los gases totales emitidos por el vehiculo, solo si su tipo coincide con el tipo pasado como parámetro.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>float 0 si el tipo no coincide, float la cantidad de gases emitidos en toneladas si el tipo coincide</returns>
        public override float ObtenerGasesEnElTipo(int tipo)
        {
            float resultado = 0;

            if (tipo == (int)this.tipo)
            {
                resultado = this.ObtenerGasesEnToneladas();
            }

            return resultado;
        }

        #endregion

        #region Comprobaciones

        /// <summary>
        /// Devuelve true si el tipo del vehiculo está contenido en el enumerado de tipos de vehiculos (ETipoVehiculo)
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>true si el tipo es correcto</returns>
        public static bool ComprobarTipo(ETipoVehiculo tipo)
        {
            return Enum.IsDefined(typeof(ETipoVehiculo), tipo);
        }

        /// <summary>
        /// Devuelve true si es un contaminante valido y el tipo del vehiculo está contenido 
        /// en el enumerado de tipos de vehiculos (ETipoVehiculo).
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
                    resultado = base.ComprobarContaminante() && ComprobarTipo(this.tipo) && cantidad <= 100000 && gasesEmitidos <= 5000;
            }
            catch (ContaminanteNuloException) { }

            return resultado;
        }

        #endregion

        #region Ordenamientos

        /// <summary>
        /// Metodo utilizado para ordenar una lista de vehiculos. Implementado en la clase genericList en el método con el mismo nombre.
        /// Ordena de forma ascendente.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>1 si el primer vehiculo va primero, 0 si los tipos son iguales, -1 si el segundo vehiculo va primero.</returns>
        public static int OrdenarPorTipo(Vehiculo a, Vehiculo b)
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
        /// Comprueba que el tipo de dos vehiculos sean iguales, a la vez que los atributos 
        /// de su clase padre, Contaminates, sean iguales también
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true si todos los atrivutos son iguales</returns>
        public static bool operator ==(Vehiculo a, Vehiculo b)
        {
            bool resultado = false;

            try
            {
                if (a is null || b is null)
                    throw new ContaminanteNuloException();
                else
                    resultado = (Contaminantes)a == b && a.tipo == b.tipo;
            }
            catch (ContaminanteNuloException) { }

            return resultado;
        }

        /// <summary>
        /// Comprueba que todos los datos de dos vehiculos sean distintos.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true si algun atributo es distinto</returns>
        public static bool operator !=(Vehiculo a, Vehiculo b)
        {
            return !(a == b);
        }

        #endregion
    }
}