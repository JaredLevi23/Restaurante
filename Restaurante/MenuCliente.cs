using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class MenuCliente : Form
    {
        private Form currentChildForm;
        private Panel leftBorderBtn;

        public MenuCliente()
        {
            InitializeComponent();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void OpenChildForm(Form nuevo)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = nuevo;
            nuevo.TopLevel = false;
            nuevo.FormBorderStyle = FormBorderStyle.None;
            nuevo.Dock = DockStyle.Fill;
            panel2.Controls.Add(nuevo);
            panel2.Tag = nuevo;
            nuevo.BringToFront();
            nuevo.Show();
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Ordenes());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Reservaciones());
        }
    }
}
