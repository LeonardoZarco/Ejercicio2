using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using API.Models;


namespace API.Controllers
{
    public class EjercicioAPIController : ApiController
    {

        [HttpGet]
        [Route("api/EjercicioAPI/ObtenerNumero")]
        public IHttpActionResult ObtenerNumero()
        {
            Numeros objecto = new Numeros();
            int resultado = objecto.ObtenerNumero();

            if (resultado>0)
            {                
                return Ok(resultado);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/EjercicioAPI/ExtraerNumero/{Numero}")]
        public IHttpActionResult ExtraerNumero(int Numero)
        {
            Numeros objecto = new Numeros();           

            bool resultado = objecto.ExtraerNumero(Numero);

            if (resultado)
            {               
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
