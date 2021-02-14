using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    //Clase para enumerar
    public enum TiposEscuela
    {
        /*Utilizamos la enumeración para poder crear un tipo persoanlizado de objeto */
       
        Primaria, 
       Secundaria,
       PreEscolar,

        /*Si no se asigna un valor numerico se obvia por un valor ascendente y ordenado de numeración */

        /*En su defecto podemos asignar el valor manualmente
        Primaria = 2,
        Secundaria = 3,
        PreEscolar =1

         */
    }
}
