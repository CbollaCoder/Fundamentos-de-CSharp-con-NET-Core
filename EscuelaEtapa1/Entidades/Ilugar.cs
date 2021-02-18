using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    //Las interfaces son soluciones alternativas para intentar manejar herencia múltple,
    //básicamente son firmas que exigen a las clases que la implementen, usar los métodos
    //o propiedades estipulados

    public interface Ilugar
    {
        //Los atributos no tienen "modificadores de acceso"
        string Direccion { get; set; }

        void LimpiarLugar();
    }
}
