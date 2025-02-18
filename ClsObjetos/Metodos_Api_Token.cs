using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using ClsEntidades;

namespace ClsObjetos
{
    public class Metodos_Api_Token
    {
        private static string host = "http://localhost:5155/api/";

        // public static string host = $"https://desarrollorh.sinaloa.gob.mx/Api-Descuentos/api/";


        public async Task<string> Get(string url,string token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync(host+url);

            var json_respuesta = await response.Content.ReadAsStringAsync();

            return json_respuesta;
        }

        public async Task<string> Post(string url, string data)
        {
            var client = new HttpClient();            
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(host+url, content);           
            var json_respuesta= await response.Content.ReadAsStringAsync();
            return json_respuesta;
        }
    }
}
