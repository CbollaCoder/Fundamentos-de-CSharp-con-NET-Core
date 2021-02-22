using EscuelaEtapa1.Entidades;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.App
{
    //REPORTEADOR QUE EXTRAE LOS DATOS
    public class Reporteador
    {

        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;

        //Funciona con un "diccionario Objeto Escuela"
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjEsc)
        {
            if (dicObjEsc == null) throw new ArgumentException(nameof(dicObjEsc));
            _diccionario = dicObjEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            
            if(_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            else{

                return new List<Evaluacion>();
            }

        }

        //Sobrecarga de métodos
        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }

        public IEnumerable<string> GetListaAsignaturas(
            out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            //Por cada objeto en mi lista de Evaluaciones (1era linea), donde las evaluaciones esten aprobadas (3ra linea),haga (2nda linea) : de cada una de las evaluaciones, seleccione la asignatura.
            return (from Evaluacion ev in listaEvaluaciones //origen de datos
                                                            //where ev.Nota >= 3.0f
                    select ev.Asignatura.Nombre).Distinct();

        }

        
        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvaluaXAsig()
        {
            var dictaRta = new Dictionary<string, IEnumerable<Evaluacion>>();

            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalAsig = from eval in listaEval
                               where eval.Asignatura.Nombre == asig
                               select eval;

                dictaRta.Add(asig, evalAsig);
            }

            return dictaRta;
        }

        //Reporte para extraer el promedio de los alumnos en cada una de las asgnaturas
        public Dictionary<string, IEnumerable<object>> GetPromAlumnPorAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<Object>>();
            var dicEvalxAsig = GetDicEvaluaXAsig();

            foreach (var asigConEval in dicEvalxAsig)
            {
                var promsAlumn = from eval in asigConEval.Value
                            group eval by new {
                                eval.Alumno.UniqueId,
                                eval.Alumno.Nombre
                            }
                            into grupEvalsAlumno
                            //Objeto anónimo
                            select new AlumnoPromedio
                            {
                                alumnoid = grupEvalsAlumno.Key.UniqueId,
                                alumnoNombre = grupEvalsAlumno.Key.Nombre,
                                //Por cada uno de los miembors de "eval"
                               promedio = grupEvalsAlumno.Average(evaluacion => evaluacion.Nota)
                            };

                rta.Add(asigConEval.Key, promsAlumn);
            }

            return rta;
        }
    }
}
