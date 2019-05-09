using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PYPA.Lanchonete.Core
{
    class Promoção
    {
        public Lanche Lanche { get; }
        public int QuantidadeLanche { get;  }
        public Lanche LancheGratís { get; }
        public int QuantidadeLancheGratís { get;  }

        public Promoção(Lanche lanche, int quantidadeLanche, Lanche lancheGratís, int quantidadeLancheGratís)
        {
            Lanche = lanche;
            QuantidadeLanche = quantidadeLanche;
            LancheGratís = lancheGratís;
            QuantidadeLancheGratís = quantidadeLancheGratís;
        }

        public List<ItemPedido> PegarPromoção(Pedido pedido) {
            var result = new List<ItemPedido>();
            var quantidade = pedido.Itens.Where(i => i.Lanche.Nome == Lanche.Nome).Sum(i => i.Quantidade);
            var quantidadePromoções = quantidade / QuantidadeLanche;
            if (quantidadePromoções > 0) result.Add(new ItemPedido(LancheGratís, QuantidadeLancheGratís * quantidadePromoções));
            return result;
        }
    }
}
