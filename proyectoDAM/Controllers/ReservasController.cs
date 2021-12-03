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
        [HttpGet]
        [ResponseType(typeof(object))]
        public async Task<object> GetId(int id)
        {
            try
            {
                var res = await Task.FromResult(BD.Reservorio.Where(x => x.idResOnline == id).SingleOrDefault());
                if (res == null)
                {
                    return NotFound();
                }
                else
                {
                    return res;
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }


        /// <summary>
        /// Crea un nuevo objeto reserva.
        /// </summary>
        /// <param name="reserva">Objeto reserva.</param>
        /// <returns>Devuelve un response.</returns>
        /// <Response code='200'>Se ha creado correctamente la reserva.</Response>
        [HttpPost]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> Post(Reservorio reserva)
        {
            try
            {
                if (reserva != null)
                {
                    reserva.idResOnline = reserva.idReserva;
                    BD.Reservorio.Add(reserva);

                }
                if (await BD.SaveChangesAsync() > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
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
        /// <returns>Devuelve un response.</returns>
        /// <Response code='200'>Se ha modificado la reserva.</Response>
        [HttpPut]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> Put(Reservorio res)
        {
            try
            {
                var reservaActualizar =
                await Task.FromResult(BD.Reservorio.Where(x => x.idResOnline == res.idResOnline).SingleOrDefault());

                if (reservaActualizar == null)
                {
                    return NotFound();
                }
                else
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

                        await BD.SaveChangesAsync();

                    }
                    catch (Exception)
                    {
                        return BadRequest();
                    }
                }
            }
            //Capturo error por si no existiera en la base de datos para modificar
            catch (Exception)
            {
                return NotFound();
            }
            return Ok();

        }


        /// <summary>
        /// Elimina una reserva.
        /// </summary>
        /// <param name="idReserva">Id del objeto.</param>
        /// <returns>Devuelve un response.</returns>
        /// <Response code='204'>Se ha eliminado la reserva.</Response>
        [HttpDelete]
        [ResponseType(typeof(IHttpActionResult))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var reservaEliminar =
                    await Task.FromResult(BD.Reservorio.Where(x => x.idResOnline == id).SingleOrDefault());
                if (reservaEliminar != null)
                {
                    BD.Reservorio.Remove(reservaEliminar);

                    if (await BD.SaveChangesAsync() > 0)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}