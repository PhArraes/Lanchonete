using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PYPA.Lanchonete.Core
{
    public enum StatusPedido
    {
        [Description("NaFila")]
        NaFila = 0,
        [Description("Iniciado")]
        Iniciado = 1,
        [Description("Finalizado")]
        Finalizado = 2,
        [Description("Entrege")]
        Entrege = 3
    }
}
