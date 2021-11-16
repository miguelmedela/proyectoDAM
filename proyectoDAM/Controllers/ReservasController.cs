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

        //Crea un nuevo registro en la base de datos
        [HttpPost]
        public bool Post(Reservorio reserva)
        {
            try
            {
                BD.Reservorio.Add(reserva);
                return BD.SaveChanges() > 0;
            }
            catch (Exception)
            {
                Console.WriteLine("No se guardó en la base de datos");
                return false;
            }
        }
        //Modifica un registro existente en la base de datos

        /// <summary>
        /// Gets the resource property descriptions.
        /// </summary>
        [HttpPut]
        public bool Put(Reservorio res)
        {
            bool flag = true;
            try
            {
                var reservaActualizar = BD.Reservorio.FirstOrDefault(x => x.idReserva == res.idReserva);
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
                        reservaActualizar.comentarios = res.comentarios;

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


        //Elimina un registro existente en la base de datos
        [HttpDelete]
        public bool Delete(int idReserva)
        {
            bool flagDelete = true;
            try
            {
                var reservaEliminar = BD.Reservorio.FirstOrDefault(x => x.idReserva == idReserva);
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