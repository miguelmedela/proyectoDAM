using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoDam.Datos.Model;

namespace ProyectoDam.Serv
{
    class Program
    {
        //Falta hacer el grueso del servidor


        ReservasEntities1 BD = new ReservasEntities1();
        static void Main(string[] args)
        {
            //Invocar servicio Rest
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://localhost:44328/");

            var request = cliente.GetAsync("api/Reservas").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var lista = JsonConvert.DeserializeObject<List<Reservorio>>(resultString);

                foreach (var item in lista)
                {
                    Console.WriteLine(item.idReserva);
                }
                Console.ReadLine();
            }

        }
    }
}
