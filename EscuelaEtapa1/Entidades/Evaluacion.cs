using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    public class Evaluacion
    {
        public string UniqueId { get; set; }

        public string Nombre { get; set; }

        public Alumno Alumno { get; set; }

        public Asignatura Asignatura { get; set; }

        public float Nota { get; set; }

        public Evaluacion() => UniqueId = Guid.NewGuid().ToString();
    }
}
