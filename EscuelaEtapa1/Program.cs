using EscuelaEtapa1.App;
using EscuelaEtapa1.Entidades;
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

            ImprimirCursosEscuela(engine.Escuela);

            Console.ReadKey();
        }

        
        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("====================");
            WriteLine("CURSOS DE LA ESCUELA");
            WriteLine("====================");
            if(escuela != null && escuela.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                   Console.WriteLine($"Nombre {curso.Nombre}, Id{curso.UniqueId}");
                }
            }
        }

       
    }
}