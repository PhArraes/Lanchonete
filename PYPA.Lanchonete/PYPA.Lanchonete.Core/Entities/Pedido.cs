using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PYPA.Lanchonete.Core
{
    public class Pedido
    {
        public StatusPedido Status { get; private set; }
        public String StatusDesc { get { return Enum.GetName(typeof(StatusPedido), Status); } }
        public int Numero { get; }
        public List<ItemPedido> Itens { get; }

        public Pedido(int numero, List<ItemPedido> itens)
        {
            Status = StatusPedido.NaFila;
            Numero = numero;
            Itens = itens;
        }

        public void AdicionarItem(ItemPedido item)
        {
            var itemExistente = Itens.FirstOrDefault(i => i.Lanche.Nome == item.Lanche.Nome);
            if (itemExistente == null) Itens.Add(item);
            else itemExistente.DefinirQuantidade(itemExistente.Quantidade + item.Quantidade);
        }
        public void IniciarPreparo()
        {
            if (Status != StatusPedido.NaFila) throw new Exception("Pedido já iniciado.");
            this.Status = StatusPedido.PreparoIniciado;
        }
        public void FinalizarPreparo()
        {
            if (Status != StatusPedido.PreparoIniciado) throw new Exception("Pedido não está em preparo.");
            this.Status = StatusPedido.PreparoFinalizado;
        }
        public void EntregarPedido()
        {
            if (Status == StatusPedido.PedidoEntregue) throw new Exception("Pedido já entregue.");
            if (Status != StatusPedido.PreparoFinalizado) throw new Exception("Pedido não finalizado.");
            this.Status = StatusPedido.PedidoEntregue;
        }
    }
}
