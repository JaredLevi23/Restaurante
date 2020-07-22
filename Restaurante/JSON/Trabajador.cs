using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.JSON
{
    class Trabajador
    {

        string url = "http://192.168.0.7:8084/esp32-api/public/api/trabajador";
        
        public string PostTrabajador(string nom,string ape,string pue)
        {
            string resultado = "";
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset-UTF-8";

            using (var oSW = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"Nombre\":\""+nom+"\",\"Apellido\":\""+ape+"\",\"Puesto\":\""+pue+"\"}";
                oSW.Write(json);
                oSW.Flush();
                oSW.Close();

            }
            WebResponse response = request.GetResponse();

            using (var oSR = new StreamReader(response.GetResponseStream())) {
                resultado = oSR.ReadToEnd().Trim();
            }

                return resultado;
        }


        public string GetTrabajador(string id)
        {
            string resultado = "";
            int ide = Int32.Parse(id);
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json;charset-UTF-8";

            using (var oSW = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"idTrabajador\":\"" + ide + "\"}";
                oSW.Write(json);
                oSW.Flush();
                oSW.Close();

            }
            WebResponse response = request.GetResponse();

            using (var oSR = new StreamReader(response.GetResponseStream()))
            {
                resultado = oSR.ReadToEnd().Trim();
            }

            return resultado;
        }
    }
}
