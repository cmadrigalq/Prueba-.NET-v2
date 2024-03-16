using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SalesSystem.Controllers;
using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Repositorio
{
    public class RepServiceAPI : IAPIService
    {
        private static string _usuarioApi = "";
        private static string _passwordApi = "";
        private static string _urlBaseApi = "";
        private static string _tokenApi = "";

        private readonly HttpClient _httpClient;
        public RepServiceAPI()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            _usuarioApi = builder.GetSection("ConexionApi:UsuarioApi").Value;
            _passwordApi = builder.GetSection("ConexionApi:PasswordApi").Value;
            _urlBaseApi = builder.GetSection("ConexionApi:UrlBase").Value;

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_urlBaseApi);
        }

        public async Task LoginAPI()
        {
            ModLoginAPI modLogin = new();
            modLogin.Usuario = _usuarioApi;
            modLogin.Password = _passwordApi;

            StringContent content = new(JsonConvert.SerializeObject(modLogin), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_urlBaseApi + "token", content);

            _tokenApi = await response.Content.ReadAsStringAsync();
        }
        async Task<TArticulo> IAPIService.BuscarArticulo(string codArticulo)
        {
            TArticulo? oArticulo = new();
            await LoginAPI();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenApi);
            HttpResponseMessage response = await _httpClient.GetAsync("Shopping/Obtener" + codArticulo);

            if (response.IsSuccessStatusCode)
            {
                string respuesta = await response.Content.ReadAsStringAsync();
                oArticulo = JsonConvert.DeserializeObject<TArticulo>(respuesta);
                return oArticulo;
            }
            else
            {
                return await Task.FromResult(oArticulo);
            }
        }

        async Task<bool> IAPIService.EliminarArticulo(string codArticulo)
        {
            await LoginAPI();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenApi);
            HttpResponseMessage response = await _httpClient.DeleteAsync("Shopping/Eliminar" + codArticulo);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        async Task<bool> IAPIService.GuardarArticulo(TArticulo articulo)
        {
            await LoginAPI();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenApi);
            StringContent content = new(JsonConvert.SerializeObject(articulo), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("Shopping/Guardar", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        async Task<List<TArticulo>> IAPIService.ListarArticulos()
        {
            List<TArticulo>? oArticulos = new();
            await LoginAPI();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenApi);
            HttpResponseMessage response = await _httpClient.GetAsync("Shopping/Listar");

            if (response.IsSuccessStatusCode)
            {
                string respuesta = await response.Content.ReadAsStringAsync();
                oArticulos = JsonConvert.DeserializeObject<List<TArticulo>>(respuesta);

                return oArticulos;
            }
            else
            {
                return null;
            }
        }

        async Task<bool> IAPIService.ModificarArticulo(TArticulo articulo)
        {
            await LoginAPI();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenApi);
            StringContent content = new(JsonConvert.SerializeObject(articulo), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync("Shopping/Editar", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        async Task<List<TFactura>> IAPIService.ListaFacturaConArticulos()
        {
            List<TFactura>? oFactura = new();
            await LoginAPI();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenApi);
            HttpResponseMessage response = await _httpClient.GetAsync("Factura/Listar");

            if (response.IsSuccessStatusCode)
            {
                string respuesta = await response.Content.ReadAsStringAsync();
                oFactura = JsonConvert.DeserializeObject<List<TFactura>>(respuesta);

                return oFactura;
            }
            else
            {
                return null;
            }
        }

        async Task<bool> IAPIService.AgregarArticuloAFactura(TFactura factura)
        {

            await LoginAPI();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenApi);
            StringContent content = new(JsonConvert.SerializeObject(factura), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("Factura/Guardar", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
