using Newtonsoft.Json;
using Restaurante.JSON;
using RestSharp;
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
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Nuevo_Socio nuevo_Socio = new Nuevo_Socio();
            nuevo_Socio.Show();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                JSON.Trabajador trabajador = new JSON.Trabajador();
                JSON.Api api = new JSON.Api();
                JSON.Curl curl = new Curl();


                curl.url = "http://192.168.0.7:8084/esp32-api/public/api/verTrabajador";
                curl.verbo = Method.POST;
                curl.json = trabajador;

                string fileJson = api.apicall(curl);
                //Console.WriteLine(fileJson);

                List<Trabajador> trabajadores = JsonConvert.DeserializeObject<List<Trabajador>>(fileJson);
                int array = trabajadores.Count;
                Console.WriteLine(""+array);
                int x = 10, y = 57;
                for (int i = 0; i < array; i++)
                {
                    string nom, ape, pue;

                    int id = Int32.Parse(trabajadores[i].idTrabajador.ToString()); ;
                    nom = trabajadores[i].Nombre.ToString();
                    ape = trabajadores[i].Apellido.ToString();
                    pue = trabajadores[i].Puesto.ToString();

                    Contenedor_Empleado contenedor = new Contenedor_Empleado(id,nom, ape, pue);
                    contenedor.Location = new Point(x, y);

                    if (i % 2 == 0)
                    {
                        if (i != 0 && i != 1)
                        {
                            x = 10;
                            y = y + 252;
                        }else
                            x = x + 395;
                    }
                    else
                    {
                        x = 10;
                        y = y + 252;
                    }
                    panel2.Controls.Add(contenedor);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ALGO SALIO MAAAAL :( : " + ex);
            }
        }
    }
}
