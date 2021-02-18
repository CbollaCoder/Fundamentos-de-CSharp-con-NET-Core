using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    public abstract class ObjetoEscuelaBase
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        //Que retorne el nombre y el identificador unico
        //La sobrescritura del método ToString se utiliza para mejorar la depuración de nuestro proyecto. Gracias a la herencia podemos sobrescribir el método en nuestra clase padre y todas sus clases hijas también tendrán sobrescrito el método.
        public override string ToString()
        {
            return $"{Nombre},{UniqueId}";
        }
    }
}
