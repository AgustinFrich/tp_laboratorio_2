using System;

namespace Entidades
{
    public class Operando
    {
        double numero;

        /// <summary>
        /// Define el setter para el campo "numero", realizando una validación.
        /// </summary>
        public string Numero
        {
            set
            {
                numero = ValidarOperando(value);
            }
        }


        /// <summary>
        /// Constructor que asigna el valor del parámetro de tipo string en el campo numero.
        /// </summary>
        /// <param name="strNumero">Cadena a asignar</param>
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }

        /// <summary>
        /// Constructor que asigna el valor del parámetro de tipo double en el campo numero.
        /// </summary>
        /// <param name="numero">Numero a asignar</param>
        public Operando(double numero) : this(numero.ToString())
        {
        }

        /// <summary>
        /// Constructor vacío de la clase. Asigna el valor del campo numero en 0.
        /// </summary>
        public Operando() : this(0)
        {
        }

        /// <summary>
        /// Valida que el string pasado como parametro sea de tipo double.
        /// </summary>
        /// <param name="strNumero">Cadena a validar</param>
        /// <returns>El numero como double o 0 en caso de que la cadena no sea numerica.</returns>
        double ValidarOperando(string strNumero)
        {
            double.TryParse(strNumero, out double validacion);

            return validacion;
        }

        /// <summary>
        /// Convierte una cadena de un numero binario a un numero decimal
        /// </summary>
        /// <param name="binario">Cadena que puede o no contener un numero binario</param>
        /// <returns>Una cadena con el numero convertido a decimal. En caso de que la cadena parámetro no sea un numero binario, devuelve "Valor inválido"</returns>
        public static string BinarioDecimal(string binario)
        {
            string respuesta = "Valor inválido";
            if (EsBinario(binario))
            {
                respuesta = Convert.ToInt32(binario, 2).ToString();
            }
            return respuesta;
        }

        /// <summary>
        /// Convierte un numero decimal a un numero binario positivo.
        /// </summary>
        /// <param name="numero">Un numero decimal</param>
        /// <returns>Una cadena con el numero convertido a binario./returns>
        public static string DecimalBinario(double numero)
        {
            numero = Math.Abs(numero);

            return Convert.ToString((int)numero, 2);
        }

        /// <summary>
        /// Convierte una cadena de un numero decimal a un numero binario positivo.
        /// </summary>
        /// <param name="numero">Una cadena de un numero decimal</param>
        /// <returns>Una cadena con el numero convertido a binario./returns>
        public static string DecimalBinario(string numero)
        {
            string respuesta = "Valor inválido";

            if (double.TryParse(numero, out double r))
            {
                respuesta = DecimalBinario(r);
            }

            return respuesta;
        }

        /// <summary>
        /// Comprueba si una cadena contiene unicamente un numero binario.
        /// </summary>
        /// <param name="binario">Cadena a comprobar</param>
        /// <returns>True si la cadena es un numero binario y False en caso contrario.</returns>
        static bool EsBinario(string binario)
        {
            bool retorno = true;
            int len = binario.Length;
            for (int i = 0; i < len; i++)
            {
                if (!(binario[i] == '1' || binario[i] == '0'))
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Permite restar los valores de dos Operandos sobrecargando el operador -.
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Operando a sustraer</param>
        /// <returns>La diferencia entre los numeros de los operandos</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return (n1.numero - n2.numero);
        }

        /// <summary>
        /// Permite sumar los valores de dos Operandos sobrecargando el operador +.
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Segundo Operando</param>
        /// <returns>La suma entre los numeros de los operandos</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return (n1.numero + n2.numero);
        }

        /// <summary>
        /// Permite multiplicar los valores de dos Operandos sobrecargando el operador *.
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Segundo Operando</param>
        /// <returns>La multiplicacion entre los numeros de los operandos</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return (n1.numero * n2.numero);
        }

        /// <summary>
        /// Permite dividir los valores de dos Operandos sobrecargando el operador /.
        /// </summary>
        /// <param name="n1">Operando a dividir</param>
        /// <param name="n2">Operando por el cual se divide</param>
        /// <returns>La division entre los numeros de los operandos</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double retorno = double.MinValue;
            if (n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }
    }
}

