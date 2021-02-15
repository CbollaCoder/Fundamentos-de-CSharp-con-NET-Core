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

            //1ERA FORMA DE DECLARAR EL ARRAY
            /*var arregloCursos = new Curso[3];
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
            };*/

            //2NDA FORMA DE DECLARA EL ARRAY
            /*var arregloCursos = new Curso[3] {
                new Curso(){Nombre = "201"},
                new Curso(){Nombre = "201"},
                new Curso{Nombre = "301"}
            };*/

            //3ERA FORMA DE DECLARAR EL ARRAY
            /*Curso[] arregloCursos = {
                new Curso(){Nombre = "201"},
                new Curso(){Nombre = "201"},
                new Curso(){Nombre = "301"}
            };*/

            //4TA FORMA CON EL ATRIBUTO "CURSOS" CREADO EN "ESCUELA"
            /*escuela.Cursos = new Curso[] {
                new Curso(){Nombre = "201"},
                new Curso(){Nombre = "201"},
                new Curso(){Nombre = "301"}
            };*/
            

            //IMPRESIONES CON CICLOS REPETITIVOS
            /*//Forma de imprimir por la generacion del metodo WHILE
            System.Console.WriteLine("While: ----------------");
            ImprimirCursosWhile(arregloCursos);
            //Forma de imprimir por la generacion del metodo DOWHILE
            System.Console.WriteLine("DoWhile: ----------------");
            ImprimirCursosDoWhile(arregloCursos);
            //Forma de imprimir por la generacion del metodo FOR
            System.Console.WriteLine("For: ----------------");
            ImprimirCursosFor(arregloCursos);
            //Forma de imprimir por la generacion del metodo FOR EACH
            System.Console.WriteLine("ForEach: ----------------");
            ImprimirCursosForEach(arregloCursos);*/

            //Nuevo metodo:
            //ImprimirCursosEscuela(escuela);

            //OPERADOR IF
            /*bool respuesta = 10 == 10;
            int cantidad = 10;
            if(!respuesta)
            {
                WriteLine("Se cumplio la condicion #1");
            }
            else if(cantidad > 15)
            {
                WriteLine("Se cumplio la condicion #2");
            }
            else if (cantidad > 20)
            {
                WriteLine("Se cumplio la condicion #3");
            }
            else
            {
                WriteLine("No se cumplio la condicion");
            }

            if((cantidad > 5 || respuesta) && (cantidad%5 == 0))
            {
                WriteLine("Se cumplio la condicion #4");
            }*/

            //IMPLEMENTANDO COLECCIONES
            //Lista con elementos tipo "Curso".
            escuela.Cursos = new List<Curso>() {
                new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "401", Jornada = TiposJornada.Mañana}
            };

            //AGREGAR CURSOS A LA LISTA
            escuela.Cursos.Add(new Curso() {Nombre = "102", Jornada = TiposJornada.Tarde });
            escuela.Cursos.Add(new Curso() { Nombre = "202", Jornada = TiposJornada.Tarde });

            //Adicionar otra coleccion que se quedo fuera
            var otraColeccion = new List<Curso>() {
                new Curso(){Nombre = "403", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "503", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "603", Jornada = TiposJornada.Mañana}
            };
            escuela.Cursos.AddRange(otraColeccion);

            //Quitar todos los datos de la lista
            //otraColeccion.Clear(); //No recibe ningun parametro adicional

            //Quitar algunos datos de la lista (item determinado)
            Curso temporal = new Curso { Nombre = "Vacacional", Jornada = TiposJornada.Noche};
            escuela.Cursos.Add(temporal);
            WriteLine(" Con dato adicional: -----------------------------------------------");
            ImprimirCursosEscuela(escuela);
            //Cuando elimina busca el hashcode indicado
            WriteLine("Curso Hash:" + temporal.GetHashCode());
            escuela.Cursos.Remove(temporal);

            //Otra forma de borrar todo
            //PASO ADICIONAL: Creamos un "predicado" para entender:
            //DELEGADO: especifica los parametros de entrada y salida que debe tener una funcion, y debe cumplirse sino no funciona.
            //DELEGADO: funcion como parametro de otro metodo.
            // Predicate<Curso> miAlgoritmo = Predicado;
            // Otra forma, escribiendo toda la funcion directamente:
            escuela.Cursos.RemoveAll(delegate (Curso cur) 
                                     {
                                         return cur.Nombre == "301";
                                     });

            //DELEGADO con expresion LAMBDA
            escuela.Cursos.RemoveAll((cur) => cur.Nombre == "603" && cur.Jornada == TiposJornada.Mañana);
            
            WriteLine(" Con datos removidos: -----------------------------------------------");
            ImprimirCursosEscuela(escuela);

            Console.ReadKey();
        }

        // DELEGADO mediante la forma de METODO
        //Con la referencia de "RemoveAll(Predicado), llama a la funcion por cada uno de los cursos y busca el "301"". El que retorna verdadero es el que va a borrar.
        private static bool Predicado(Curso curobj)
        {
            return curobj.Nombre == "301";
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

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                Console.WriteLine($"Nombre {curso.Nombre}, Id{curso.UniqueId}");
            }
        }

    }
}