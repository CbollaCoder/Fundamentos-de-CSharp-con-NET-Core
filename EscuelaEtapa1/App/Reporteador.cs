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

        public IEnumerable<Escuela> GetListaEvaluaciones()
        {
            IEnumerable<Escuela> rta;
            if(_diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                rta = lista.Cast<Escuela>();
            }
            else{

                rta = null;
            }

            return rta;
        }
    }
}
