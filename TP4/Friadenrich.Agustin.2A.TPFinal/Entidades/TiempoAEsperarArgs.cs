using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
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
