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

        public IEnumerable<string> GetListaAsignaturas()
        {
            var listaEvaluaciones = GetListaEvaluaciones();

            //Por cada objeto en mi lista de Evaluaciones (1era linea), donde las evaluaciones esten aprobadas (3ra linea),haga (2nda linea) : de cada una de las evaluaciones, seleccione la asignatura.
            return (from Evaluacion ev in listaEvaluaciones //origen de datos
                   //where ev.Nota >= 3.0f
                   select ev.Asignatura.Nombre).Distinct();
                
        }


    }
}
