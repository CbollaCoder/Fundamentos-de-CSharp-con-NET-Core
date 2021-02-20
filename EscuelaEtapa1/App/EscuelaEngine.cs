using EscuelaEtapa1.Entidades;
using EscuelaEtapa1.Util;
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

        //CREACIÓN DE UN DICCIONARIO: listar los objetos ObjetoEscuelaBase
        //El segundo parámetro del diccionario es un IEnumerable de tipo lista de objetos ObjetoEscuela
        //IEnumerable: Tipo de lista generico ya que es 1.Una interfaz generica de lista y 2. Cuando hacemos Cast() para convertir los cursos, se nos devuelve un IEnumerable 
        
        //Es inseguro dejar las llaves del diccionario como string por lo tanto se las cambia por una enumeración
        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            //Objeto escuela de tipo Lista pero que solo tiene un elemento
            diccionario.Add(LlaveDiccionario.Escuela, new[] { Escuela });
            diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            
            var listatmp = new List<Evaluacion>();
            var listatmpas = new List<Asignatura>();
            var listatmpal = new List<Alumno>();

            foreach (var cur in Escuela.Cursos)
            {
                listatmpas.AddRange(cur.Asignaturas);
                listatmpal.AddRange(cur.Alumnos);

                foreach (var alum in cur.Alumnos)
                {
                    listatmp.AddRange(alum.Evaluaciones);
                }
                
            }
            diccionario.Add(LlaveDiccionario.Evaluacion, listatmp.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Asignatura, listatmpas.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumno, listatmpal.Cast<ObjetoEscuelaBase>());
            
            return diccionario;
        }

        //Metodo de imresion del diccionario
        //Se agrega un parámetro opcional para imprimir o no las evaluaciones
        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic, 
            bool imprEval = false)
        {
            //Imprime la llave
            foreach (var obj in dic)
            {

                Printer.WriteTitle(obj.Key.ToString());

                //Imprime todos los valores asociados a las llaves
                foreach (var val in obj.Value)
                {
                    if (val is Evaluacion)
                    {
                        if(imprEval) Console.WriteLine(val);
                    }
                    else if( val is Escuela)
                    {
                        Console.WriteLine("Escuela: " + val);
                    }
                    else if(val is Alumno)
                    {
                        Console.WriteLine("Alumno: " + val.Nombre);
                    }
                    else
                    {
                        Console.WriteLine(val);
                    }
                        
                }
            }
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
        public IReadOnlyList <ObjetoEscuelaBase> GetObjetosEscuela( //Es importante notar que estas listas listas solo pueden ser de lectura por lo cual se utiliza IReadOnlyList.
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
            return listObj.AsReadOnly(); //Lista de solo lectura
        }
        //SE EVIDENCIA LA SOBRECARGA DE METODOS con WRAPPERS del PRIMERO.
        //4ta implementación: MÉTODO OPTIMIZADO con SOBRECARGA al método anterior
        //Implementacion que no pide los parámetros de salida
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            bool traeEvaluaciones = true,
            bool traeAsignaturas = true,
            bool traeAlumnos = true,
            bool traeCursos = true)
        {
            //Llamado al método que pide todos los parámetros de salida
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }
        //5ta implementación: nuevo método con SOBRECARGA, solo un parámetro de salida
        //Implementación 
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
           out int conteoEvaluaciones,
           bool traeEvaluaciones = true,
           bool traeAsignaturas = true,
           bool traeAlumnos = true,
           bool traeCursos = true)
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }
        //6ta implementación: Ccon 2 parámetros de salida
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
           out int conteoEvaluaciones,
           out int conteoCursos,
           bool traeEvaluaciones = true,
           bool traeAsignaturas = true,
           bool traeAlumnos = true,
           bool traeCursos = true)
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoCursos, out int dummy, out dummy);
        }
        //7ma implementacion: con 3 parámetros de salida.
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
           out int conteoEvaluaciones,
           out int conteoCursos,
           out int conteoAsignaturas,
           bool traeEvaluaciones = true,
           bool traeAsignaturas = true,
           bool traeAlumnos = true,
           bool traeCursos = true)
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoCursos, out conteoAsignaturas, out int dummy);
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
