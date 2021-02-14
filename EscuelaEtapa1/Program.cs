using EscuelaEtapa1.Entidades;
using System;

namespace EscuelaEtapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            //presionar ctrl + . para agregar las referencias
            var escuela = new Escuela("Platzi Academy",2012);
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogota";

            //Llamando a la enumeracion:
            escuela.TipoEscuela = TiposEscuela.Primaria;

            //Console.WriteLine(escuela.Nombre);
            Console.WriteLine(escuela);

            Console.ReadKey();
        }
    }
}