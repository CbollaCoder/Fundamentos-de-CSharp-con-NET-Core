using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    class Curso
    {
        //Se asigna que el set sea de tipo private
        public string Nombre { get;  set; }
        
        //Referencia al ENCAPSULAMIENTO
        public string UniqueId { get; private set; }

        public TiposJornada Jornada { get; set; }

        //Creacion del METODO CONSTRUCTOR
        //ctor + 2xtab: para crear constructor
        //el GUID genera un tipo de numero
        public Curso() => UniqueId = Guid.NewGuid().ToString();
        

    }
}
