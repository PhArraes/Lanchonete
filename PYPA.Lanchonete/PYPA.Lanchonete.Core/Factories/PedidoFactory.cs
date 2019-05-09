using PYPA.Lanchonete.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PYPA.Lanchonete.Core.Factories
{
    public class PedidoFactory
    {

        public Pedido Create(int numero, Cardápio cardápio, List<IItemPedido> itemPedido)
        {
            List<ItemPedido> items = new List<ItemPedido>();

            itemPedido.ForEach(i => {
                var lanche = cardápio.Lanches.FirstOrDefault(l => l.Nome == i.Nome);
                if (lanche == null) throw new Exception("Cardápio não contém item pedido");
                items.Add(new ItemPedido(lanche, i.Quantidade));
            });

            return new Pedido(numero, items);
        }
    }
}
