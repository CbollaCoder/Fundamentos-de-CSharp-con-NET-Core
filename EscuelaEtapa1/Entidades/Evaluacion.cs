using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    public class Evaluacion : ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public float Nota { get; set; }

        //Metodo sobreescrito de ToString de la clase padre, 
        public override string ToString()
        {
            return $"{Nota},{Alumno.Nombre},{Asignatura.Nombre}";
        }
    }
}
