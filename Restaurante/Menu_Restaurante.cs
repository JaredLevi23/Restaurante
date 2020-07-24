using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Newtonsoft.Json;
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
            OpenFileDialog buscar = new OpenFileDialog();
            if(buscar.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = buscar.FileName;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            string nombre, descrip, prec, img;
            
            nombre = textBox1.Text;
            descrip = textBox2.Text;
            prec = textBox3.Text;
            int precio = Int32.Parse(prec);
            img = textBox4.Text;

            JSON.Producto articulo = new JSON.Producto();
            JSON.Api api = new JSON.Api();
            JSON.Curl curl = new JSON.Curl("menu");

            articulo.Nombre = nombre;
            articulo.Descripcion = descrip;
            articulo.Precio = precio;
            articulo.Imagen = img;

            curl.verbo = Method.POST;
            curl.json = articulo;

            MessageBox.Show(api.apicall(curl));
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JSON.Api api = new JSON.Api();
            JSON.Curl curl = new JSON.Curl("menu");
            curl.verbo = Method.GET;
            string fileJson = api.apiDes(curl);
            
            dataGridView1.DataSource = fileJson;
            dataGridView1.Refresh();
        }
    }
}
