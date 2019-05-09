using System;
using System.Collections.Generic;
using System.Text;

namespace PYPA.Lanchonete.Core
{
    public class ItemPedido
    {
        public Lanche Lanche { get; }
        public int Quantidade { get; private set; }

        public ItemPedido(Lanche lanche, int quantidade)
        {
            Lanche = lanche;
            DefinirQuantidade(quantidade);
        }

        public void DefinirQuantidade(int quantidade)
        {
            if (quantidade <= 0) throw new Exception("Quantidade do item de pedido é inválida");
            Quantidade = quantidade;
        }
    }
}
