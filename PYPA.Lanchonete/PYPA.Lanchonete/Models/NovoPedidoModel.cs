using PYPA.Lanchonete.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PYPA.Lanchonete.Models
{
    public class NovoPedidoModel
    {
        public List<ItemPedidoModel> Items { get; set; }
    }

    public class ItemPedidoModel : IItemPedido
    {
        public string Nome { get; set; }

        public int Quantidade { get; set; }
    }
}
