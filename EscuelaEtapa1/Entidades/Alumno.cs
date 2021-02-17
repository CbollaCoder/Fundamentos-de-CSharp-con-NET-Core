using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    //Se agrega la herencia de ObjetoEscuelaBase
    public class Alumno
    {
        public string UniqueId { get; set; }
        public string Nombre { get; set; }

        //Inicializar lista
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();

        public Alumno() {
            UniqueId = Guid.NewGuid().ToString();
            Evaluaciones = new List<Evaluacion>(); 
        } 

    }
}
