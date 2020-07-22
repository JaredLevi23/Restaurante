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
    public partial class Nuevo_Socio : Form
    {
        public Nuevo_Socio()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try {
                string nombre, apellido, puesto;
                nombre = textBox1.Text;
                apellido = textBox2.Text;
                puesto = comboBox1.SelectedItem.ToString();

                JSON.Trabajador trabajador = new JSON.Trabajador();
                trabajador.PostTrabajador(nombre, apellido, puesto);
                MessageBox.Show("BIENVENIDO A BORDO ;) ");
                this.Close();
            }
            catch (Exception ex) {
                MessageBox.Show("ALGO SALIO MUY MUY MUUUY MAAAL :(");
            }
        }
    }
}
