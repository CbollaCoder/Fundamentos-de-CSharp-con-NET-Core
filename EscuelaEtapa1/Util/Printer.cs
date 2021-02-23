using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace EscuelaEtapa1.Util
{
    //Clase estática: clase que no permite la creación de nuevas instancias. Se comporta como un objeto.
    public static class Printer
    {
        //Línea impresa con un tamaño de 10 (parámetro opcional). Es posible que también el cliente pase otro tamaño.
        public static void DrawLine(int tam = 10)
        {
            //Cadena vacia que se la rellena a la izquierda con "=".
            var linea = "".PadLeft(tam, '=');
            WriteLine(linea);
        }

        public static void PresioneENTER()
        {
            WriteLine("Presione ENTER para continuar");
        }

        public static void WriteTitle (string titulo)
        {
            var tamano = titulo.Length + 4;
            DrawLine(tamano);
            WriteLine($"| {titulo} |");
            DrawLine(tamano);
        }

        public static void Beep(int hz=2000, int tiempo=500, int cantidad=1)
        {
            while (cantidad>0)
            {
                Console.Beep(hz, tiempo);
                cantidad--;
            }
        }
    }
}
