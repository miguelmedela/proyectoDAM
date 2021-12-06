using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoDAM.Models
{
    public class ReservaP
    {
        public class Rootobject
        {
            public Res[] Property1 { get; set; }
        }

        public class Res
        {
            public int idReserva { get; set; }
            public string nombre { get; set; }
            public string apellidos { get; set; }
            public int tipoHab { get; set; }
            public DateTime fechaEntrada { get; set; }
            public int dias { get; set; }
            public float precio { get; set; }
            public bool desayuno { get; set; }
            public bool garaje { get; set; }
            public string comentarios { get; set; }
            public int idResOnline { get; set; }

            public Res(int idReserva, string nombre, string apellidos, int tipoHab,
                DateTime fechaEntrada, int dias, float precio,
                bool desayuno, bool garaje, string comentarios, int idResOnline)
            {
                this.idReserva = idReserva;
                this.nombre = nombre;
                this.apellidos = apellidos;
                this.tipoHab = tipoHab;
                this.fechaEntrada = fechaEntrada;
                this.dias = dias;
                this.precio = precio;
                this.desayuno = desayuno;
                this.garaje = garaje;
                this.comentarios = comentarios;
                this.idResOnline = idResOnline;
            }
        }

    }
}