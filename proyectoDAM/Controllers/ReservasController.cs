using ProyectoDam.Datos.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace proyectoDAM.Controllers
{
    /// <summary>
    /// Clase controlador de reservas.
    /// Gestiona los métodos GET, GET(id), POST, PUT y DELETE.
    /// </summary>
    public class ReservasController : ApiController
    {
        ReservasEntities1 BD = new ReservasEntities1();


        ///// <summary>
        ///// Obtiene los objetos del reservorio.
        ///// </summary>
        ///// <returns>Listado de los objetos de reservorio.</returns>
        ///// <response code='200'>Devuelve el listado de objetos solicitado.</response>
        //[HttpGet]
        //[ResponseType(typeof(IEnumerable<Reservorio>))]
        //public IEnumerable<Reservorio> Get()
        //{

        //    var listado = BD.Reservorio.ToList();
        //    return listado;
        //}



        /// <summary>
        /// Obtiene los objetos del reservorio.
        /// </summary>
        /// <returns>Listado de los objetos de reservorio.</returns>
        /// <response code='200'>Devuelve el listado de objetos solicitado.</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Reservorio>))]
        public async Task<IEnumerable<Reservorio>> GETall()
        {
            return await BD.Set<Reservorio>().ToListAsync();
        }


        /// <summary>
        /// Obtiene el objeto reserva por su id.
        /// </summary>
        /// <param name="id">Id del objeto.</param>
        /// <returns>Devuelve un único objeto del reservorio.</returns>
        /// <response code='200'>Devuelve la reserva solicitada.</response>
        /// <response code='404'>Not found.</response>
        /// 
        //[HttpGet]
        //[ResponseType(typeof(Reservorio))]
        //public Reservorio Get(int id)
        //{
        //    var res = BD.Reservorio.FirstOrDefault(x => x.idResOnline == id);
        //    return res;

        //}

        [HttpGet]
        [ResponseType(typeof(Reservorio))]
        public async Task<Reservorio> GetId(int id)
        {
            
            var res = await BD.Set<Reservorio>().FindAsync(id);
            return res;

        }


        /// <summary>
        /// Crea un nuevo objeto reserva.
        /// </summary>
        /// <param name="reserva">Objeto reserva.</param>
        /// <returns>Devuelve un response.</returns>
        /// <Response code='200'>Se ha creado correctamente la reserva.</Response>
        /// <response code='400'>Bad request.</response> 
        [HttpPost]
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult Post(Reservorio reserva)
        {
            try
            {
                if(reserva != null)
                {
                    reserva.idResOnline = reserva.idReserva;
                    BD.Reservorio.Add(reserva);
                }
                if (BD.SaveChanges() > 0)
                {
                    return  Ok();
                }
                else
                    return BadRequest();  
            }

            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        /// <summary>
        /// Modifica una reserva existente en la base de datos.
        /// </summary>
        /// <param name="res">Objeto reserva objetivo de modificacion.</param>
        /// <returns>Devuelve true o false.</returns>
        /// <Response code='200'>Se ha modificado correctamente la reserva.</Response>
        /// <Response code='404'>Not found.</Response>
        [HttpPut]
        [ResponseType(typeof(Reservorio))]
        public bool Put(Reservorio res)
        {
            bool flag = true;
            try
            {
                var reservaActualizar = BD.Reservorio.FirstOrDefault(x => x.idResOnline == res.idReserva);
                if (reservaActualizar == null)
                {
                    flag = false;
                }
                if (flag)
                {
                    try
                    {
                        reservaActualizar.nombre = res.nombre;
                        reservaActualizar.apellidos = res.apellidos;
                        reservaActualizar.tipoHab = res.tipoHab;
                        reservaActualizar.fechaEntrada = res.fechaEntrada;
                        reservaActualizar.dias = res.dias;
                        reservaActualizar.precio = res.precio;
                        reservaActualizar.desayuno = res.desayuno;
                        reservaActualizar.garaje = res.garaje;
                        reservaActualizar.comentarios = res.comentarios + " Modificado:" + DateTime.Now;


                        return BD.SaveChanges() > 0;
                    }
                    catch (Exception)
                    {
                        flag = false;
                        Console.WriteLine("Error a la hora de modificar en la base de datos");
                    }
                }
            }
            //Capturo error por si no existiera en la base de datos para modificar
            catch (Exception)
            {
                flag = false;
                return false;
            }

            return flag;
        }


        /// <summary>
        /// Elimina una reserva.
        /// </summary>
        /// <param name="idReserva">Id del objeto.</param>
        /// <returns>Devuelve true o false.</returns>
        /// <Response code='204'>Se ha eliminado la reserva.</Response>
        /// <Response code='404'>Not found.</Response>
        [HttpDelete]
        [ResponseType(typeof(Reservorio))]
        public bool Delete(int idReserva)
        {
            bool flagDelete = true;
            try
            {
                var reservaEliminar = BD.Reservorio.FirstOrDefault(x => x.idResOnline == idReserva);
                if (flagDelete)
                {
                    BD.Reservorio.Remove(reservaEliminar);

                    try
                    {
                        return BD.SaveChanges() > 0;
                    }
                    catch (Exception)
                    {
                        flagDelete = false;
                        return false;
                    }
                }

            }
            //Capturo error por si no existiera en la base de datos para borrar
            catch (ArgumentNullException)
            {
                flagDelete = false;
                Console.WriteLine("Error a la hora de borrar elemento de la base de datos");
            }

            return flagDelete;
        }

    }
}