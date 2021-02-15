using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    public class Alumno
    {
        public string UniqueId { get; set; }
        public string Nombre { get; set; }

        public Alumno() => UniqueId = Guid.NewGuid().ToString();

    }
}
