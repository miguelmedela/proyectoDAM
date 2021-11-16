using ProyectoDam.Datos.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace proyectoDAM.Controllers
{
    public class ReservasController : ApiController
    {
        //LibreriaConnection BD2 = new LibreriaConnection();

        ReservasEntities1 BD = new ReservasEntities1();

        //Permite consultar la información de todas las reservas
        //contenidas en la base de datos

        [HttpGet]
        public IEnumerable<Reservorio> Get()
        {
            var listado = BD.Reservorio.ToList();
            return listado;
        }


        //Devuelve la reserva contenida en la base de datos
        //con el IDReserva correspondiente
        [HttpGet]
        public Reservorio Get(int id)
        {
            //var res = BD2.Reserva.FirstOrDefault(x => x.idReserva == id);


            var res = BD.Reservorio.FirstOrDefault(x => x.idReserva == id);
            return res;
        }


        //por fecha--ahora mismo peta -->No sé si será util igualmente 
        //[HttpGet]
        //public IEnumerable<Reservorio> Get(DateTime d)
        //{

        //    var fecha = BD.Reservorio.ToList();
        //    return fecha.ToList();
        //}



        //Tengo que hacer que me pueda leer bien esto
        [HttpPost]
        public IHttpActionResult PostNewReserva(Models.ReservaP.Class1 res)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            try
            {
                using (var r = new ReservasEntities1())
                {
                    r.Reservorio.Add(new Reservorio()
                    {
                        idReserva = res.idReserva,
                        nombre = res.nombre,
                        apellidos = res.apellidos,
                        tipoHab = res.tipoHab,
                        fechaEntrada = res.fechaEntrada,
                        dias = res.dias,
                        precio = res.precio,
                        desayuno = res.desayuno,
                        garaje = res.garaje,
                        comentarios = res.comentarios
                    });
                    r.SaveChanges();
                }

            }
            catch (NullReferenceException)
            {

                Console.WriteLine("Objeto nulo");
            }

            return Ok();
        }

    }
}