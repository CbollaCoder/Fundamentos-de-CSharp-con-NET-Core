﻿using EscuelaEtapa1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaEtapa1.App
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        //El constructor debe ser tan rapido como sea posible
        //En lo posible, desconectado de todo lo que puede ser entrada o salida
        /*public EscuelaEngine()
        {
            
        }*/

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, pais: "Bolivia", ciudad: "La Paz");
            
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        //Metodo que devuelve todos los objetos "escuela" que contiene
        //1era implementacion
        /* public List<ObjetoEscuelaBase> GetObjetosEscuela(
             bool traeEvaluaciones = true,
             bool traeAsignaturas = true,
             bool traeAlumnos = true,
             bool traeCursos = true)
         {
             var listObj = new List<ObjetoEscuelaBase>();
             listObj.Add(Escuela);

             if(traeCursos) listObj.AddRange(Escuela.Cursos);

             foreach (var curso in Escuela.Cursos)
             {
                 if(traeAsignaturas)listObj.AddRange(curso.Asignaturas);

                 if(traeAlumnos)listObj.AddRange(curso.Alumnos);

                 if (traeEvaluaciones)
                 {
                     foreach (var alumno in curso.Alumnos)
                     {
                         listObj.AddRange(alumno.Evaluaciones);
                     }
                 }

             }
             return listObj;
         }*/
        //2nda implementacion: CON TUPLAS, es decir que devuelve 2 valores, este caso una LISTA y un ENTERO.
        /*public (List<ObjetoEscuelaBase>, int) GetObjetosEscuela(
            bool traeEvaluaciones = true,
            bool traeAsignaturas = true,
            bool traeAlumnos = true,
            bool traeCursos = true)
        {
            int conteoEvaluaciones = 0;

            var listObj = new List<ObjetoEscuelaBase>();
            listObj.Add(Escuela);

            if (traeCursos) listObj.AddRange(Escuela.Cursos);

            foreach (var curso in Escuela.Cursos)
            {
                if (traeAsignaturas) listObj.AddRange(curso.Asignaturas);

                if (traeAlumnos) listObj.AddRange(curso.Alumnos);

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }

            }
            return (listObj,conteoEvaluaciones);
        }*/
        //3era implementaciión: CON PARÁMETROS DE SALIDA. Devuelve la cantidad de cada uno de los objetos.
        public List<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int  conteoAsignaturas,
            out int  conteoAlumnos,
            bool traeEvaluaciones = true,
            bool traeAsignaturas = true,
            bool traeAlumnos = true,
            bool traeCursos = true)
        {
            //Asignaciones múltiples
            conteoEvaluaciones = conteoCursos = conteoAsignaturas = conteoAlumnos = 0;

            var listObj = new List<ObjetoEscuelaBase>();
            listObj.Add(Escuela);

            if (traeCursos) listObj.AddRange(Escuela.Cursos);

            conteoCursos += Escuela.Cursos.Count;

            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;

                if (traeAsignaturas) listObj.AddRange(curso.Asignaturas);

                if (traeAlumnos) listObj.AddRange(curso.Alumnos);

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }

            }
            return listObj;
        }




        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipe", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Morty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            //El OrderBy Funciona como DELEGADO
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();

        }


        #region Métodos de Carga

        private void CargarEvaluaciones()
        {
            
            foreach (var curso in Escuela.Cursos)
            {
                foreach(var asignatura in curso.Asignaturas)
                {
                    foreach(var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for(int i=0; i<5; i++)
                        {
                            var ev = new Evaluacion
                            {
                                //Creamos 5 evaluaciones y se las asignamos a cada alumno
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5*rnd.NextDouble()),

                                //Asignar el alumno a cada evaluacion
                                Alumno = alumno
                            };

                            alumno.Evaluaciones.Add(ev); 
                            
                        }

                    }
                }
            }
        }

        private void CargarAsignaturas()
        {
            foreach(var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>() {
                        new Asignatura(){Nombre = "Matemáticas"},
                        new Asignatura(){Nombre = "Educación Física"},
                        new Asignatura(){Nombre = "Castellano"},
                        new Asignatura(){Nombre = "Ciencias Nturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>() {
                new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "401", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "102", Jornada = TiposJornada.Tarde },
                new Curso(){Nombre = "202", Jornada = TiposJornada.Tarde }
            };

            //Generador de numeros aleatorios
            Random rnd = new Random();
            

            //Para cada curso se generan alumnos
            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }

        #endregion

    }
}
