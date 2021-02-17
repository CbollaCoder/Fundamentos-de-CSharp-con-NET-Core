using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaEtapa1.Entidades
{
    class ObjetoEscuelaBase
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}
