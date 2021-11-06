using System;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Inicializa los componentes del formulario y añade a los items del combo box los operadores aritméticos de la calculadora.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            cmbOperador.Items.Add('+');
            cmbOperador.Items.Add('-');
            cmbOperador.Items.Add('*');
            cmbOperador.Items.Add('/');
        }

        /// <summary>
        /// Limpia los datos del formulario al cargarlo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Muestra un mensaje preguntando si desea salir o no de la aplicación al cerrarla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No);
        }


        /// <summary>
        /// Obtiene los datos del formulario y realiza la operación indicada. Escribe el resultado en un label y guarda la operacion en una lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();

            sb.Append(txtNumero1.Text + " ");

            if (cmbOperador.Text != "")
            {
                sb.Append(cmbOperador.Text + " ");
            }
            else
            {
                sb.Append("+ ");
            }

            sb.Append(txtNumero2.Text + " = " + lblResultado.Text);

            lstOperaciones.Items.Add(sb);
        }

        /// <summary>
        /// Ejecuta la funcion Limpiar() para dejar en blanco todos los campos del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Ejecuta la funcion FormClosing, la cual pregunta si desea salir o no del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Convierte el resultado de la ultima operación de un numero decimal a un numero binario en caso de ser posible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConbertirABinario_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(lblResultado.Text + " a binario: ");

            if (double.TryParse(lblResultado.Text, out double numero))
            {
                lblResultado.Text = Operando.DecimalBinario(numero);
            }

            sb.Append(lblResultado.Text);

            lstOperaciones.Items.Add(sb);
        }

        /// <summary>
        /// Convierte el resultado de la ultima operación de un numero binario a un numero decimal en caso de ser posible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(lblResultado.Text + " a decimal: ");

            lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);

            sb.Append(lblResultado.Text);
            lstOperaciones.Items.Add(sb);

        }

        /// <summary>
        /// Limpia todos los datos del formulario
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = " ";
            lblResultado.Text = "0";
            lstOperaciones.Items.Clear();
        }

        /// <summary>
        /// Recibe los datos del formulario para realizar la operación indicada.
        /// </summary>
        /// <param name="numero1">Primer numero</param>
        /// <param name="numero2">Segundo numero</param>
        /// <param name="operador">Operador aritmético</param>
        /// <returns>El resultado de la operación.</returns>
        static double Operar(string numero1, string numero2, string operador)
        {
            double retorno;
            char.TryParse(operador, out char operadorChar);
            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);

            retorno = Calculadora.Operar(operando1, operando2, operadorChar);

            return retorno;
        }

    }
}
