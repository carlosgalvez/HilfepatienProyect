using HilfepatienApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http.Formatting;



namespace HilfepatienAPI_Cliente.Models
{
    public class MedicinaCliente
    {
        public String BASE_URL = "http://localhost:41827/api/";

        public IEnumerable<Medicina> findAll()
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.GetAsync("Medicina").Result;
                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadAsAsync<IEnumerable<Medicina>>().Result;
                return null;

            }
            catch
            {
                return null;
            }
        }
        public Medicina find(int id)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.GetAsync("Medicina/" + id).Result;
                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadAsAsync<Medicina>().Result;
                return null;

            }
            catch
            {
                return null;
            }
        }
        public bool Create(Medicina Medicina)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.PostAsJsonAsync("Medicina", Medicina).Result;
                return respuesta.IsSuccessStatusCode;

            }
            catch
            {
                return false;
            }
        }
    }
}
