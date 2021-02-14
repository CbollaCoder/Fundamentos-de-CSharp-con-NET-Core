using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    //Lo importante es el nombre de la clase
    //ctrl + a + f: formato a nombre
    class Escuela
    {
        string nombre;
        //Propiedad que hace posible que se acceda al "nombre" que es private.
        public string Nombre
        {
            get { return "Copia:" +nombre; }
            set { nombre = value.ToUpper(); }
        }

        //Crear una variable + su propiedad de acceso de forma automatica con el atajo PROP:
        //PROP (presionar: 2 veces "Tab"): atajo para crear una propiedad
        //PROP FULL: crea la variable que encapsula ademas de la propiedad para acceder a ella.
        public int AñoDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }

        //MECANISMOS PARA INICIALIZAR LA ESCUELA
        //Constructor: metodo que ayuda a crear una instancia de este objeto
        //La escuela se crea con un nombre y un año
        //Hay muchas formas de escribir un CONTRUCTOR
        /*public Escuela(string nombreEntrada, int año)
        {
            this.nombre = nombreEntrada;
            AñoDeCreacion = año;
        }*/

        //Manera corta de escribir un metodo: IGUALACION POR TUPLAS
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreacion) = (nombre, año);

        //Sobre-escribir un metodo:
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Tipo: {TipoEscuela} \nPaís: {Pais}, Ciudad: {Ciudad}";
        }


    }
}
