using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;




namespace AutoToken
{
    public class Autorizar
    {

        //Proceso de autenticación con SAP
        public String AutorizarSAP(string client_id, string client_secret)
        {
            Root modelo = new Root();

            string credentials = client_id + ":" + client_secret; 

            var client = new RestClient("https://auth.coresuite.com/api/oauth2/v1/token/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic " + EncodeStringToBase64(credentials));
            request.AddHeader("Cache-Control", "no-cache, no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Host", "auth.coresuite.com");
            request.AddHeader("Content-Length", "36");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("scope", "");
            IRestResponse response = client.Execute(request);

            if (response.Content != null)
            {
                Console.WriteLine("Autenticación con éxito");

            }
            else
            {
                Console.WriteLine("Hubo un problema en la autenticacion");

            }

            modelo = JsonConvert.DeserializeObject<Root>(response.Content);

            Console.WriteLine("Deserializando respuesta");

            return modelo.access_token;
        }

        //Método para encodear en BASE64 las credenciales client_id y client_secret
        public static string EncodeStringToBase64(string texto)
        {
            var textoABytes = System.Text.Encoding.UTF8.GetBytes(texto);
            return System.Convert.ToBase64String(textoABytes);

        }














    }
}
