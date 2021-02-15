using EscuelaEtapa1.App;
using EscuelaEtapa1.Entidades;
using EscuelaEtapa1.Util;
using System;
using System.Collections.Generic;
using static System.Console; //Permite solo escribir el "WriteLine"

namespace EscuelaEtapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA!");
            Printer.Beep();
            Printer.Beep(10000, cantidad:10);
            //Se utiliza los métodos creados en la clase Printer
            //Printer.DibujarLinea(20);
            //Printer.DibujarLinea();

            ImprimirCursosEscuela(engine.Escuela);

            Console.ReadKey();
        }

        
        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la Escuela");

            if (escuela != null && escuela.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                   Console.WriteLine($"Nombre {curso.Nombre}, Id{curso.UniqueId}");
                }
            }
        }

       
    }
}