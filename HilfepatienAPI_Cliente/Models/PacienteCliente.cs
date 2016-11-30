using HilfepatienApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace HilfepatienAPI_Cliente.Models
{
    public class PacienteCliente
    {
        public String BASE_URL = "http://localhost:41827/api/";
        public IEnumerable<Paciente> findAll()
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.GetAsync("Paciente").Result;
                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadAsAsync<IEnumerable<Paciente>>().Result;
                return null;

            }
            catch
            {
                return null;
            }
        }
        public Paciente find(int id)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.GetAsync("Paciente/" + id).Result;
                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadAsAsync<Paciente>().Result;
                return null;

            }
            catch
            {
                return null;
            }
        }
        public bool Create(Paciente Paciente)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.PostAsJsonAsync("Paciente", Paciente).Result;
                return respuesta.IsSuccessStatusCode;

            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Paciente Paciente)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.PutAsJsonAsync((string)("Paciente/" + Paciente.Id), Paciente).Result;
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
                HttpResponseMessage respuesta = cliente.DeleteAsync("Paciente/" + id).Result;
                return respuesta.IsSuccessStatusCode;

            }
            catch
            {
                return false;
            }
        }
    }
}
