using EscuelaEtapa1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.App
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        //El constructor debe ser tan rapido como sea posible
        //En lo posible, desconectado de todo lo que puede ser entrada o salida
        public EscuelaEngine()
        {
            
        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, pais: "Bolivia", ciudad: "La Paz");

            Escuela.Cursos = new List<Curso>() {
                new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "401", Jornada = TiposJornada.Mañana},
                new Curso() { Nombre = "102", Jornada = TiposJornada.Tarde },
                new Curso() { Nombre = "202", Jornada = TiposJornada.Tarde }
        };

            
        }

    }
}
