using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class Menu_Restaurante : Form
    {
        public Menu_Restaurante()
        {
            InitializeComponent();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (panel1.Visible==true)
            {
                panel1.Visible = false;
                iconButton3.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleLeft;
            }
            else {
                panel1.Visible = true;
                this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleRight;
            }
                
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivo de Imagen |*.jpg| Archivo PNG|*.png|Todos los archivos|*.*";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK) {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            string nombre, descrip, precio, img;
            //MemoryStream ms = new MemoryStream();
            //pictureBox1.Image.Save(ms, ImageFormat.Jpeg);

            //byte[] vs = ms.ToArray();
            nombre = textBox1.Text;
            descrip = textBox2.Text;
            precio = textBox3.Text;

            JSON.Menu menu = new JSON.Menu();
            menu.PostProducto(nombre,descrip,precio);
        }
    }
}
