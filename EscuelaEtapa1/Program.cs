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
            Printer.Beep(10000, cantidad: 10);
            //Se utiliza los métodos creados en la clase Printer
            //Printer.DibujarLinea(20);
            //Printer.DibujarLinea();

            ImprimirCursosEscuela(engine.Escuela);

            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Pruebas de Polimorfismo");
            //Alumno es de tipo "Alumno" que hereda de "ObjetoEscuelaBase"
            var alumnoTest = new Alumno { Nombre = "Claire Murillo" };
            //Objetos compatibles por el polimorfismo
            ObjetoEscuelaBase ob = alumnoTest;

            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

            var evaluacion = new Evaluacion() { Nombre = "Evaluacion de matematicas", Nota = 4.5f };
            Printer.WriteTitle("Evaluacion");
            WriteLine($"Evaluacion: {evaluacion.Nombre}");
            WriteLine($"Evaluacion: {evaluacion.UniqueId}");
            WriteLine($"Evaluacion: {evaluacion.Nota}");
            WriteLine($"Evaluacion: {evaluacion.GetType()}");

            ob = evaluacion;
            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Evaluacion: {ob.Nombre}");
            WriteLine($"Evaluacion: {ob.UniqueId}");
            WriteLine($"Evaluacion: {ob.GetType()}");

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