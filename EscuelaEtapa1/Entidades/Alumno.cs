using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    //Se agrega la herencia de ObjetoEscuelaBase
    public class Alumno: ObjetoEscuelaBase
    {
        //Inicializar lista
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    }
}
