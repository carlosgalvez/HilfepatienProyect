using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using HilfepatienApi.Models;

namespace HilfepatienAPI_Cliente.Models
{
    public class UsuariosCliente
    {
        public String BASE_URL = "http://localhost:41709/api/";
        public IEnumerable<Usuarios> findAll()
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.GetAsync("Usuarios").Result;
                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadAsAsync<IEnumerable<Usuarios>>().Result;
                return null;

            }
            catch
            {
                return null;
            }
        }
        public Usuarios find(int id)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.GetAsync("Usuarios/" + id).Result;
                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadAsAsync<Usuarios>().Result;
                return null;

            }
            catch
            {
                return null;
            }
        }
        public bool Create(Usuarios Usuarios)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.PostAsJsonAsync("Usuarios", Usuarios).Result;
                return respuesta.IsSuccessStatusCode;

            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Usuarios Usuarios)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.PutAsJsonAsync("Usuarios/" + Usuarios.Id, Usuarios).Result;
                return respuesta.IsSuccessStatusCode;

            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.DeleteAsync("Usuarios/" + id).Result;
                return respuesta.IsSuccessStatusCode;

            }
            catch
            {
                return false;
            }
        }
        
    }
}