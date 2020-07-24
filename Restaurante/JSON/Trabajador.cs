using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using RestSharp;


namespace Restaurante.JSON
{
    class Trabajadores
    {


    }
    /*
    PAQUETES NUGGET.
    - RestSharp
    - System.Text.Json

    */
    class Api
    {
        public string apicall(Curl datos)
        {
            var cliente = new RestClient(datos.url);
            var request = new RestRequest(datos.verbo);

            request.AddHeader("Content-Type", "Application/Json");
            string json = JsonSerializer.Serialize(datos.json);
            request.AddJsonBody(json);
            Console.WriteLine(json);
            IRestResponse response = cliente.Execute(request);
            return response.Content;
        }

        public string apiDes(Curl datos) {

            var client = new RestClient(datos.url);
            var request = new RestRequest(datos.verbo);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            
            var queryResult = client.Execute(request);
            Object objeto = JsonSerializer.Deserialize<Object>(queryResult.Content);
            //Console.WriteLine(objeto.result[0].Nombre);
            return queryResult.Content;
        }

    }

    class Curl
    {
        public string url { set; get; }
        public Method verbo { set; get; }
        public object json { set; get; }

        public Curl(string origen)
        {

            if(origen == "trabajador")
                this.url = "http://192.168.0.7:8084/esp32-api/public/api/trabajador";
            if(origen == "menu")
                this.url = "http://192.168.0.7:8084/esp32-api/public/api/menu";

        }
    }

    class Trabajador
    {
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Puesto { set; get; }

    }

    class Producto {

        public int idProducto { set; get; }
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        public int Precio { set; get; }
        public string Imagen { set; get; }
    }

    class Menu {
        public Producto [] result {set;get;}
    }



}
