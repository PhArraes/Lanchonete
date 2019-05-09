using PYPA.Lanchonete.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PYPA.Lanchonete.Models
{
    public class NovoPedidoModel
    {
        public List<IItemPedido> Items { get; set; }
    }
}
