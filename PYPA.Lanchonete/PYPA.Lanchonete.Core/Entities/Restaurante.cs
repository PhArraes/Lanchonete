﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PYPA.Lanchonete.Core
{
   public class Restaurante
    {
        public String Nome { get; }
        public Cardápio Cardapio { get; }
        public Cozinha Cozinha { get; }

        public List<Pedido> Pedidos { get; }
        private List<Promoção> Promoções { get; }
        private int NúmeroDePedido = 0;
        private object MonitorNúmeroDePedido = new object();

        public Restaurante(int numCozinheiros, Cardápio cardápio)
        {
            Nome = "";
            Cozinha = new Cozinha(numCozinheiros);
            Cardapio = cardápio;
            Pedidos = new List<Pedido>();
            Promoções = new List<Promoção>();
            AdicionarPromoçãoPadrão(cardápio);
        }

        public void NovoPedido(Pedido pedido) {
            Promoções.ForEach(p => { 
               p.PegarPromoção(pedido).ForEach(i => pedido.AdicionarItem(i));               
            });            
            Cozinha.NovoPedido(pedido);
            Pedidos.Add(pedido);
        }

        public int PegarPróximoNúmero()
        {
            var número = -1;
            if (Monitor.TryEnter(MonitorNúmeroDePedido, 10000))
            {
                try
                {
                    número =  this.NúmeroDePedido++;
                }
                finally
                {
                    Monitor.Exit(MonitorNúmeroDePedido);
                }
            }
            return número;
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
