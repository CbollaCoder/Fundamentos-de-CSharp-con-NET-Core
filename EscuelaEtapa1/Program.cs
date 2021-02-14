﻿using EscuelaEtapa1.Entidades;
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

            /*var curso1 = new Curso() { 
                Nombre = "101"
            };

            var curso2 = new Curso()
            {
                Nombre = "201"
            };

            var curso3 = new Curso()
            {
                Nombre = "301"
            };*/

            //Imprimir una linea
            //System.Console.WriteLine("----------------");
            //Imprimir la informacion de los cursos
            //Console.WriteLine(curso1.Nombre + "," + curso1.UniqueId);
            //Otro tipo de impresion
            //Console.WriteLine($"{curso2.Nombre},{curso2.UniqueId}");
            //Console.WriteLine(curso3);

            //COMO HACER PARA MANEJAR MULTIPLES OBJETOS EN LA ESCUELA?
            //Pues, creamos un arreglo de objetos
            //3 formas de crearlo:
            var arregloCursos = new Curso[3];

            arregloCursos[0] = new Curso()
            {
                Nombre = "101"
            };

            var curso2 = new Curso()
            {
                Nombre = "201"
            };
            arregloCursos[1] = curso2;

            arregloCursos[2] = new Curso
            {
                Nombre = "301"
            };


            //Forma de imprimir por la generacion del metodo WHILE
            System.Console.WriteLine("While: ----------------");
            ImprimirCursosWhile(arregloCursos);
            //Forma de imprimir por la generacion del metodo DOWHILE
            System.Console.WriteLine("DoWhile: ----------------");
            ImprimirCursosDoWhile(arregloCursos);
            //Forma de imprimir por la generacion del metodo FOR
            System.Console.WriteLine("For: ----------------");
            ImprimirCursosFor(arregloCursos);
            

            Console.ReadKey();
        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, Id{arregloCursos[contador].UniqueId}");
                contador++;
            }
        }

        
        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            do
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, Id{arregloCursos[contador].UniqueId}");
                contador++;
            } while (contador < arregloCursos.Length);
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre {arregloCursos[i].Nombre}, Id{arregloCursos[i].UniqueId}");
            }
                
                
        }

    }
}