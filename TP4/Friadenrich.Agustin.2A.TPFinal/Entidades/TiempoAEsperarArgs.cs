using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase que deriva de EventArgs, utilizada en el evento del FormInicial para calcular 
    /// el tiempo estimado en el que se acutalizaran los datos del servidor SQL.
    /// </summary>
    public class TiempoAEsperarArgs : EventArgs
    {
        public int tiempoTotal;
        public string mensaje;

        public TiempoAEsperarArgs(string mensaje, int cantidadDeElementos, int tiempoPorElemento)
        {
            this.mensaje = mensaje;
            this.tiempoTotal = cantidadDeElementos * tiempoPorElemento;
        }
    }
}
