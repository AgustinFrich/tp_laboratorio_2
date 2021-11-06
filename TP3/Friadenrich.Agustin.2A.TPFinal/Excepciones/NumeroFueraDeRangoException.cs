using System;

namespace Excepciones
{
    /// <summary>
    /// Este tipo de excepcion es utilizada para corroborar que un dato numérico esté dentro de un rango válido.
    /// Esta excepción está implementada en: 
    ///     (throw) El constructor de las clase Contaminantes, donde se lanza la excepción
    ///     si el atributo gasesEmitidos es menor a 0 o el atributo cantidad es menor o igual a 0.
    ///     (throw) En los constructores de las clases vehiculo y fábrica, donde se lanza la excepción
    ///     si el atributo gasesEmitidos o el atributo cantidad superan un limite máximo determinado para cada clase.
    ///     (catch) En el formAgregarUnAgente, para evitar que se creen objetos no validos.
    ///     (catch) En el proyecto Test Unitario, como excepciones esperadas en algunos métodos de los test de Fábrica y GenericList.
    /// </summary>
    public class NumeroFueraDeRangoException : Exception
    {
        public NumeroFueraDeRangoException() : base("El numero introducido está fuera de rango.")
        {
        }

        public NumeroFueraDeRangoException(string mensaje) : base(mensaje)
        {
        }

        public NumeroFueraDeRangoException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}
