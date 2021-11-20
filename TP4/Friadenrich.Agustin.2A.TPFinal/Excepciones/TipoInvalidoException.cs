using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    /// <summary>
    /// Se lanza si el tipo asignado a un contaminante no coincide con ninguno de los valores del enumerado para su tipo correspondiente
    /// Esta excepción está implementada en: 
    /// (throw) En los constructores de las clases Vehiculo y Fabrica, luego de comprobar si el tipo ingresado pertenece al enumerado
    /// (catch) Se implementa en algunos Tests Unitarios, tanto en FabricaTest como en GenericListTest, al forzar el ingreso de un tipo no valido.
    ///         Esto no sucede en el proyecto de formularios ya que siempre se asignan los tipos mediante los enumerados.
    /// </summary>
    public class TipoInvalidoException : Exception
    {
        public TipoInvalidoException() : base("El tipo introducido no es valido.")
        {
        }

        public TipoInvalidoException(string mensaje) : base(mensaje)
        {
        }

        public TipoInvalidoException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}
