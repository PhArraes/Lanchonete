using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PYPA.Lanchonete.Core
{
   public class Restaurante
    {
        public String Nome { get; }
        public Cardápio Cardápio { get; }
        public Cozinha Cozinha { get; }

        public List<Pedido> Pedidos { get; }
        private List<Promoção> Promoções { get; }

        public Restaurante(int numCozinheiros, Cardápio cardápio)
        {
            Nome = "";
            Cozinha = new Cozinha(numCozinheiros);
            Cardápio = cardápio;
            Pedidos = new List<Pedido>();
            Promoções = new List<Promoção>();
            AdicionarPromoçãoPadrão(cardápio);
        }

        public void NovoPedido(Pedido pedido) {
            Promoções.ForEach(p => pedido.Itens.AddRange(p.PegarPromoção(pedido)));
        }

        private void AdicionarPromoçãoPadrão(Cardápio cardápio)
        {
            var hambúrguer = cardápio.Lanches.FirstOrDefault(l => l.Nome == "hambúrguer");
            if (hambúrguer == null) return;
            var suco = cardápio.Lanches.FirstOrDefault(l => l.Nome == "suco");
            if (suco == null) suco = new Lanche("suco", 0);
            Promoções.Add(new Promoção(hambúrguer, 2, suco, 1));
        }
    }
}
