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
            Console.WriteLine(escuela.Nombre);
        }
    }
}