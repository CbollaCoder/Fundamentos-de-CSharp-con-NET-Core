using EscuelaEtapa1.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    //Clase Curso que implementa la estructuta de Ilugar
    public class Curso: ObjetoEscuelaBase, Ilugar
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        
        //Implementla la dirección que está en Ilugar
        public string Direccion { get; set; }

        //Implementa el método que está en Ilugar
        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando el establecimiento...");
            Console.WriteLine($"Curso {Nombre} limpio.");
        }
    }
}
