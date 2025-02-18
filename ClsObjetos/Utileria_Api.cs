using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ClsEntidades;
using Newtonsoft.Json;


namespace ClsObjetos
{
  
    public class Utileria_Api
    {
        private static string _host = $"http://localhost:5155/api/";
        // public static string _host = $"https://desarrollorh.sinaloa.gob.mx/Api-Descuentos/api/";

        private static string _usuario;
        private static string _clave;
        private static string _token;

        public Utileria_Api(IConfiguration config)
        {
            _usuario = config.GetSection("ApiSettings").GetSection("usuario").ToString();
            _clave = config.GetSection("ApiSettings").GetSection("clave").ToString();              
        }
        public async Task Autentificar() {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_host);
            var credenciales = new Credencial() { usuario = _usuario, clave = _clave };
            var content = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("/Validar/validar",content);
            var json_respuesta= await response.Content.ReadAsStringAsync();

            var resultado = JsonConvert.DeserializeObject<ResultadoCredencial>(json_respuesta);
            _token = resultado.token;
        }

        public async Task<ObjMensaje> Get(string ruta) {
            await Autentificar();
            ObjMensaje resultado = new ObjMensaje();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_host);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await cliente.GetAsync(ruta);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ObjMensaje>(json_respuesta);
            }
            return resultado;
        }
    }
}
   
