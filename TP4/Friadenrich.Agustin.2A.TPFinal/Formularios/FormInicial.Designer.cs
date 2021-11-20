
namespace Formularios
{
    partial class FormInicial
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AgregarStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AgentesContaminantesStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CargarDatosStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SalirStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgregarStripMenuItem,
            this.CargarDatosStripMenuItem,
            this.SalirStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1234, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AgregarStripMenuItem
            // 
            this.AgregarStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgentesContaminantesStripMenuItem1});
            this.AgregarStripMenuItem.Name = "AgregarStripMenuItem";
            this.AgregarStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.AgregarStripMenuItem.Text = "Agregar";
            // 
            // AgentesContaminantesStripMenuItem1
            // 
            this.AgentesContaminantesStripMenuItem1.Name = "AgentesContaminantesStripMenuItem1";
            this.AgentesContaminantesStripMenuItem1.Size = new System.Drawing.Size(199, 22);
            this.AgentesContaminantesStripMenuItem1.Text = "Agentes contaminantes";
            this.AgentesContaminantesStripMenuItem1.Click += new System.EventHandler(this.AgentesContaminantesStripMenuItem1_Click);
            // 
            // CargarDatosStripMenuItem
            // 
            this.CargarDatosStripMenuItem.Name = "CargarDatosStripMenuItem";
            this.CargarDatosStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.CargarDatosStripMenuItem.Text = "Cargar datos";
            this.CargarDatosStripMenuItem.Click += new System.EventHandler(this.CargarDatosStripMenuItem_Click);
            // 
            // SalirStripMenuItem
            // 
            this.SalirStripMenuItem.Name = "SalirStripMenuItem";
            this.SalirStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.SalirStripMenuItem.Text = "Salir";
            this.SalirStripMenuItem.Click += new System.EventHandler(this.SalirStripMenuItem_Click);
            // 
            // FormInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 712);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Friadenrich Agustin - TP Final";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInicial_Closing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AgregarStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CargarDatosStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SalirStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AgentesContaminantesStripMenuItem1;
    }
}

