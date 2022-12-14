using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using API.Models;

namespace Presentation.Controllers
{
    public class EjercicioAPIController : Controller
    {
        [HttpGet]
        public ActionResult Numbers(Numeros numeros)
        {
            return View(numeros);
        }

        [HttpGet]
        public ActionResult GetNumeroExtraido()
        {
            Numeros numeros = new Numeros();

            using (var client = new HttpClient())
            {
                string url_API = System.Configuration.ConfigurationManager.AppSettings["URL_API"].ToString();
                client.BaseAddress = new Uri(url_API);
                var getTask = client.GetAsync("EjercicioAPI/ObtenerNumero/");

                getTask.Wait();
                var result = getTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<int>();
                    numeros.Numero = readTask.Result;
                }
            }
            return RedirectToAction("Numbers", numeros);
        }

        [HttpGet]
        public ActionResult ExtraerNumero(int Numero)
        {
            using (var client = new HttpClient())
            {
                string url_API = System.Configuration.ConfigurationManager.AppSettings["URL_API"].ToString();
                client.BaseAddress = new Uri(url_API);

                var getTask = client.GetAsync("EjercicioAPI/ExtraerNumero/" + Numero);
                getTask.Wait();

                var result = getTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Se extrajo el número correctamente";

                }
                else
                {
                    ViewBag.Mensaje = "Ocurrió un error al extraer el número";

                }
            }

            return PartialView("Message");
        }


    }
}