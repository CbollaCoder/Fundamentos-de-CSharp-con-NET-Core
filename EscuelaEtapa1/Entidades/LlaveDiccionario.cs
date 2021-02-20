using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    /*//"ESTRUCTURA" que se utiliza para crear las llaves del diccionario
    // Recomendable cuando se manejan tipos sencillos de datos  
    public struct LlavesDiccionario
    {
        public const string CURSOS = "Cursos";
        public const string ALUMNOS = "Alumnos";
        public const string ASIGNATURAS = "Asignaturas";
        public const string ESCUELA = "Escuela";
        public const string EVALUACIONES = "Evaluaciones";
    }*/

    public enum LlaveDiccionario
    {
        Escuela,
        Curso,
        Alumno,
        Asignatura,
        Evaluacion
    }

}


