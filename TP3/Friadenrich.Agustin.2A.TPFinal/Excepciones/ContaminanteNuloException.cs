using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    /// <summary>
    /// Este tipo de excepcion es utilizada para corroborar que los Contaminantes no sean iguales a null.
    /// Esta excepción está implementada en: 
    ///     (throw) Los constructores de las clases Contaminantes, Fabrica y Vehiculo.
    ///     (throw y catch) El método ComprobarContaminante() de las clases ya mencionadas
    ///     (throw y catch) Sobrecarga de operadores de igualdad de las clases ya mencionadas y la sobrecarga del
    ///                     operador + en la clase GenericList
    ///     (throw y catch) En la clase GenericList, al intentar leer un archivo que no tiene contenido.
    /// </summary>
    public class ContaminanteNuloException : Exception
    {
        public ContaminanteNuloException() : base("El contaminante no está instanciado.")
        {
        }

        public ContaminanteNuloException(string mensaje) : base(mensaje)
        {
        }

        public ContaminanteNuloException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}
