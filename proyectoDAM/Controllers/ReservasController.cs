using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace proyectoDAM.Controllers
{
    public enum tipoHab
    {
        individual,
        dobleMAt,
        doble,
        triple
    }

    public class Reserva
    {
        int idReserva, dias;
        string nombre, apellido;
        tipoHab habitacion;
        DateTime fechaEntrada;
        double [] precio;
        bool desayuno;
        bool garaje;
        string comentarios;
        

        public int IdReserva { get => idReserva; set => idReserva = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public tipoHab Habitacion { get => habitacion; set => habitacion = value; }
        public DateTime FechaEntrada { get => fechaEntrada; set => fechaEntrada = value; }
        public int Dias { get => dias; set => dias = value; }
        public double[] Precio { get => precio; set => precio = value; }
        public bool Desayuno { get => desayuno; set => desayuno = value; }
        public bool Garaje { get => garaje; set => garaje = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        

        public Reserva()
        {

        }


        public Reserva(int idReserva, string nombre, string apellido,
            tipoHab habitacion, DateTime fechaEntrada, int dias, double[] precio,
            bool desayuno, bool garaje, string comentarios )
        {
            IdReserva = idReserva;
            Nombre = nombre;
            Apellido = apellido;
            Habitacion = habitacion;
            FechaEntrada = fechaEntrada;
            Dias = dias;
            Precio = precio;
            Desayuno = desayuno;
            Garaje = garaje;
            Comentarios = comentarios;
            
        }


    }



    public class ReservasController : ApiController
    {
        Reserva reserva = new Reserva();
        // GET: Reservas
        public IEnumerable<Reserva> Get()
        {
            IList lista = (IList)reserva;

            return (IEnumerable<Reserva>)lista;
        }
    }
}