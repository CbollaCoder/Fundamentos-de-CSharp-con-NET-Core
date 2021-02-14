using System;
using System.Threading;

namespace CoreEscuela
{
    class Escuela
    {
        //Atributos con nivel de acceso privado. Para poder ser modificado, el nivel de acceso debe ser +public
        public string nombre;
        public string direccion;
        public int añoFundacion; //C# Soporta internacionalizacion
        public string ceo = "Freddy Vega";

        //Metodos
        public void Timbrar()
        {
            //Todo
            //Console.Beep(2000,3000); //1000Hz, 3s
            Console.Beep(987, 1000); //Si
            Console.Beep(1174, 500); //Re'
            Console.Beep(880, 1500); //La

            Console.Beep(783, 250); //Sol
            Console.Beep(880, 250); //La
            Console.Beep(987, 1000); //Si

            Console.Beep(1174, 500); //Re'
            Console.Beep(880, 1500); //La

            Console.Beep(987, 1000); //Si
            Console.Beep(1174, 500); //Re'
            Console.Beep(1760, 1000); //La'
            Console.Beep(1567, 500); //Sol'
            Console.Beep(1174, 1000); //Re'

            Console.Beep(1046, 250); //Do
            Console.Beep(987, 250); //Si
            Console.Beep(880, 1000); //La

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Instancia de la clae Escuela
            var miEscuela = new Escuela();
            miEscuela.nombre = "Platzi Academy";
            miEscuela.direccion = "Carrera 9na, calle 72";
            miEscuela.añoFundacion = 2012;
            Console.WriteLine("Timbre....");
            miEscuela.Timbrar();

            Console.ReadKey();
        }


    }
}
