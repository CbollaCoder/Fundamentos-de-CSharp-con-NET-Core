using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    public class Curso
    {
        //Se asigna que el set sea de tipo private
        public string Nombre { get;  set; }
        
        //Referencia al ENCAPSULAMIENTO
        public string UniqueId { get; private set; }

        public TiposJornada Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }


        //Creacion del METODO CONSTRUCTOR
        //ctor + 2xtab: para crear constructor
        //el GUID genera un tipo de numero
        public Curso() => UniqueId = Guid.NewGuid().ToString();
        

    }
}
