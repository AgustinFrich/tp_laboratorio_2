
namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida que el parámetro sea uno de los operadores aritméticos.
        /// </summary>
        /// <param name="operador">Caracter a validar.</param>
        /// <returns>El caracter si es un operador aritmético válido. Caso contrario, retorna '+'.</returns>
        private static char ValidarOperador(char operador)
        {
            char retorno = '+';

            if (operador == '-' || operador == '/' || operador == '*')
            {
                retorno = operador;
            }

            return retorno;
        }

        /// <summary>
        /// Realiza el calculo entre los dos operandos y el operador aritmético correspondiente.
        /// </summary>
        /// <param name="num1">Primer numero de la operación.</param>
        /// <param name="num2">Segundo numero de la operación.</param>
        /// <param name="operador">Operador aritmético</param>
        /// <returns>El resultado de la operación. En caso de dividir por cero retorna el valor mínimo.</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double retorno;

            char operadorValidado = ValidarOperador(operador);

            switch (operadorValidado)
            {
                // No hay case para '+' porque repetiría código del default.
                case '-':
                    retorno = num1 - num2;
                    break;
                case '/':
                    retorno = num1 / num2;
                    break;
                case '*':
                    retorno = num1 * num2;
                    break;
                default:
                    retorno = num1 + num2;
                    break;
            }

            return retorno;
        }
    }
}
