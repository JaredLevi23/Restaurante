using RestSharp;
using System;
using System.Windows.Forms;
using Restaurante.JSON;
//using System.Text.Json;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using System.Linq;

namespace Restaurante
{
    public partial class Menu_Restaurante : Form
    {
        public Menu_Restaurante()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();
            if(buscar.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = buscar.FileName;
                pictureBox1.Image = Image.FromFile(buscar.FileName);
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
            JSON.Apip apip = new JSON.Apip();
            JSON.PCurl pcurl = new JSON.PCurl();

            articulo.Nombre = nombre;
            articulo.Descripcion = descrip;
            articulo.Precio = precio;
            articulo.Imagen = img;
            
            pcurl.verbo = Method.POST;
            pcurl.json = articulo;

            MessageBox.Show(apip.apicallp(pcurl));
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                JSON.Producto articulo = new JSON.Producto();
                articulo.idProducto = 10;
                JSON.Apip api = new JSON.Apip();
                JSON.PCurl pcurl = new PCurl();


                pcurl.url = "http://192.168.0.7:8084/esp32-api/public/api/menutodo";
                pcurl.verbo = Method.POST;
                pcurl.json = articulo;

                string fileJson = api.apicallp(pcurl);
                //Console.WriteLine(fileJson);

                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(fileJson);
                int array = productos.Count;
                int x = 10, y= 63;
                for (int i = 0;i<array;i++)
                {
                    string nom, des, pre, img;

                    int id = Int32.Parse(productos[i].idProducto.ToString()); ;
                    nom = productos[i].Nombre.ToString();
                    des = productos[i].Descripcion.ToString();
                    pre = productos[i].Precio.ToString();
                    img = productos[i].Imagen.ToString();
                    
                    Contenedor contenedor = new Contenedor(nom, des, pre, img, id);
                    contenedor.Location = new Point(x, y);
                    
                    if (i % 4 == 0)
                    {
                        if (i != 0 && i!=1) {
                            x = 10;
                            y = y + 220;
                        }
                    }
                    else {
                        x = x + 195;
                    }
                    panel2.Controls.Add(contenedor);
                }


                //Producto producto = JsonSerializer.Deserialize<Producto>(fileJson);
                //Console.WriteLine(producto.Nombre);

                /*string nom, des, pre, img;
                
                int id = Int32.Parse(producto.idProducto.ToString()); ;
                nom = producto.Nombre.ToString();
                des = producto.Descripcion.ToString();
                pre = producto.Precio.ToString();
                img = producto.Imagen.ToString();

                Contenedor contenedor = new Contenedor(nom,des,pre,img,id);
                contenedor.Location = new Point(10,63);
                panel2.Controls.Add(contenedor);
                */


            }
            catch (Exception ex) {
                MessageBox.Show("ALGO SALIO MAAAAL :( : "+ex);
            }
        }

        private void Menu_Restaurante_Load(object sender, EventArgs e)
        {

        }
    }
}
