using System;

namespace Excepciones
{
    /// <summary>
    /// Este tipo de excepcion es utilizada para corroborar que una cadena no esté vacía.
    /// Esta excepción está implementada en: 
    ///     (throw) El constructor de la clase Contaminantes, donde valida que el atributo nombre no esté vacío.
    ///     (catch) En el FormAgregarContaminantes atrapa la excepción causada por dejar vacío el textBox Para el nombre
    ///             y coloca en su lugar el texto "Sin nombre".
    ///     (catch) En el FormAgregarAgente atrapa la excepción causada por dejar vacío el textBox Para el nombre
    ///             y evita que se cree un agente con el nombre vacío.
    ///     (catch) En el proyecto Test, en el program, donde se crea a propósito un vehiculo sin nombre 
    ///             para mostrar el manejo de excepciones
    /// </summary>
    public class StringInvalidoException : Exception
    {
        public StringInvalidoException() : base("El nombre no puede ser asignado")
        {
        }

        public StringInvalidoException(string mensaje) : base(mensaje)
        {
        }

        public StringInvalidoException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}
