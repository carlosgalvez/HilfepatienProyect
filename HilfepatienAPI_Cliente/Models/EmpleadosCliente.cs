#region librerias 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using HilfepatienApi.Models;
using System.Net.Http.Headers;
#endregion 


namespace HilfepatienAPI_Cliente.Models
{
    public class EmpleadosCliente
    {
        public String BASE_URL = "http://localhost:41709/api/";

        public IEnumerable<Empleados> findAll() {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.GetAsync("Empleados").Result;
                if (respuesta.IsSuccessStatusCode) 
                return respuesta.Content.ReadAsAsync<IEnumerable<Empleados>>().Result;
                return null;
                
            }
            catch {
                return null;
            }
        }
        public Empleados find(int id)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.GetAsync("Empleados/" + id).Result;
                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadAsAsync<Empleados>().Result;
                return null;

            }
            catch
            {
                return null;
            }
        }
        public bool Create(Empleados Empleados)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(BASE_URL);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respuesta = cliente.PostAsJsonAsync("Empleados", Empleados).Result;
                return respuesta.IsSuccessStatusCode;               

            }
            catch
            {
                return false;
            }
        }
    }
}