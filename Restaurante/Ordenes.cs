using Newtonsoft.Json;
using Restaurante.JSON;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class Ordenes : Form
    {        
        public Ordenes()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void verPedidos()
        {

            try
            {
                JSON.Pedidos pedidos = new JSON.Pedidos();
                JSON.Apip api = new JSON.Apip();
                JSON.PCurl pcurl = new PCurl();


                pcurl.url = "http://192.168.0.7:8084/esp32-api/public/api/pedidoss";
                pcurl.verbo = Method.POST;
                pcurl.json = pedidos;

                string fileJson = api.apicallp(pcurl);
                //Console.WriteLine(fileJson);

                List<Pedidos> pedidosc = JsonConvert.DeserializeObject<List<Pedidos>>(fileJson);
                int array = pedidosc.Count;
                int x = 10, y = 47;
                for (int i = 0; i < array; i++)
                {
                    int idpe, idc, idpro, cant, pre;
                    string nomC, nomP, des, img;

                    idpe = Int32.Parse(pedidosc[i].idPedido.ToString());
                    idc = Int32.Parse(pedidosc[i].idCliente.ToString());
                    idpro = Int32.Parse(pedidosc[i].idProducto.ToString());
                    nomC = pedidosc[i].NomCliente.ToString();
                    nomP = pedidosc[i].Nombre.ToString();
                    des = pedidosc[i].Descripcion.ToString();
                    pre = Int32.Parse(pedidosc[i].Precio.ToString());
                    cant = Int32.Parse(pedidosc[i].Cantidad.ToString()); ;
                    img = pedidosc[i].Imagen.ToString();

                    Contenedor_Orden contenedor = new Contenedor_Orden(idpe, cant, nomP, des, img,idpro);
                    contenedor.Location = new Point(x, y);

                    if (i % 3 == 0)
                    {
                        if (i != 0 && i != 1)
                        {
                            x = 10;
                            y = y + 315;
                        }
                        else {
                            x = x + 252;
                        }
                    }
                    else
                    {
                        x = x + 252;
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

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            verPedidos();
        }

        private void Ordenes_Load(object sender, EventArgs e)
        {

        }
    }
}
