using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formularios
{
    public partial class FormInicial : Form
    {
        public FormInicial()
        {
            InitializeComponent();
        }

        private void FormInicial_Load(object sender, EventArgs e)
        {

        }

        private void AgentesContaminantesStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAgregarContaminantes form = new FormAgregarContaminantes();

            if(form.ShowDialog() == DialogResult.OK)
            {
                string nombre = form.NombreDelProveedor;
                EAgentes agente = form.Agente;
                FormContaminantes formCont = new FormContaminantes(nombre, agente)
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                formCont.Show();
            }
        }

        private void SalirStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInicial_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void CargarDatosStripMenuItem_Click(object sender, EventArgs e)
        {
            FromCargarArchivo formCargarArchivo = new FromCargarArchivo()
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if(formCargarArchivo.ShowDialog() == DialogResult.OK)
            {
                string nombre = formCargarArchivo. Nombre;
                EAgentes agente = formCargarArchivo.Agente;
                GenericList<Vehiculo> listV = formCargarArchivo.Vehiculos;
                GenericList<Fabrica> listF = formCargarArchivo.Fabricas;

                FormContaminantes formCont = new FormContaminantes(nombre, agente, listF, listV)
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    MdiParent = this
                };

                formCont.Show();
            }
        }
    }
}
