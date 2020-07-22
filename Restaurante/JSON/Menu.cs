using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.JSON
{
    class Menu
    {

        string url = "http://192.168.0.7:8084/esp32-api/public/api/menu";

        public string PostProducto(string nom, string descripcion, string precios)
        {
            string resultado = "";
            int precio = Int32.Parse(precios);
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset-UTF-8";

            using (var oSW = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"Nombre\":\"" + nom + "\",\"Descripcion\":\"" + descripcion + "\",\"Precio\":\"" + precio + "\"}";
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
