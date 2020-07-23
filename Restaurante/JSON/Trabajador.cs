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
    }

    class Curl
    {
        public string url { set; get; }
        public Method verbo { set; get; }
        public object json { set; get; }

        public Curl()
        {
            this.url = "http://192.168.0.7:8084/esp32-api/public/api/trabajador";
        }
    }

    class Trabajador
    {
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Puesto { set; get; }

    }

}
