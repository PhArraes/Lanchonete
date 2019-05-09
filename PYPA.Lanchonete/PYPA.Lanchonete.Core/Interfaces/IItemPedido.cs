using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Lanchonete.Core.Interfaces
{
    public interface IItemPedido
    {
        String Nome { get; }
        int Quantidade { get; }
    }
}
