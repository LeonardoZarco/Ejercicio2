using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;

namespace API.Models
{
    public class Numeros : ApiController
    {
        public int Numero { get; set; }


        public Dictionary<int, bool> GetList()
        {
            Dictionary<int, bool> numeros = new Dictionary<int, bool>();

            var session = HttpContext.Current.Application ;

            if (session["numeros"] != null)
            {
                numeros = (Dictionary<int, bool>)session["numeros"];
            }
            else
            {
                numeros = FillNumbers();
                session["numeros"] = numeros;
            }         

            return numeros;
        }

        public Dictionary<int, bool> FillNumbers()
        {
            Dictionary<int, bool> numeros = new Dictionary<int, bool>();

            for (int i = 1; i <= 100; i++)
            {
                numeros.Add(i, true);
            }

            return numeros;
        }

        public bool ExtraerNumero(int Numero)
        {
            try
            {
                Dictionary<int, bool> numeros = GetList();
                numeros[Numero] = false;
                return true;
            }
            catch
            {
                return false;
            }

        }


        public int ObtenerNumero()
        {
            try
            {
                Dictionary<int, bool> numeros = GetList();
                foreach (var item in numeros)
                {
                    if (!item.Value)
                    {
                        numeros[item.Key] = true;
                        
                        return item.Key;
                    }
                }
            }
            catch
            {
                return 0;
            }

            return 0;
        }
    }
}