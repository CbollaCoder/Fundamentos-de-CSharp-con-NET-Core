using EscuelaEtapa1.Entidades;
using System;

namespace EscuelaEtapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            //presionar ctrl + . para agregar las referencias
            //En este caso, los parametros opcionales pueden ir en desorden o pueden ir en blanco
            var escuela = new Escuela("Platzi Academy",2012, TiposEscuela.Primaria, pais:"Bolivia", ciudad:"La Paz");
           // escuela.Pais = "Colombia";
           // escuela.Ciudad = "Bogota";

            //Llamando a la enumeracion:
            //escuela.TipoEscuela = TiposEscuela.Primaria;

            //Console.WriteLine(escuela.Nombre);
            //En este caso, cada vez que se quiera llamar a una cadena, se imprime el metodo sobre-escrito
            Console.WriteLine(escuela);

            var curso1 = new Curso() { 
                Nombre = "101"
            };

            var curso2 = new Curso()
            {
                Nombre = "201"
            };

            var curso3 = new Curso()
            {
                Nombre = "301"
            };

            //Imprimir una linea
            System.Console.WriteLine("----------------");
            //Imprimir la informacion de los cursos
            Console.WriteLine(curso1.Nombre + "," + curso1.UniqueId);
            //Otro tipo de impresion
            Console.WriteLine($"{curso2.Nombre},{curso2.UniqueId}");
            Console.WriteLine(curso3);

            Console.ReadKey();
        }
    }
}