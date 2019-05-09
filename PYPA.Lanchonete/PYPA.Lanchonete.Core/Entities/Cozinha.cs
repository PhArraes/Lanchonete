using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PYPA.Lanchonete.Core
{
    public class Cozinha
    {
        private readonly object AlocarCozinheiroMonitor = new object();
        private List<Cozinheiro> Cozinheiros { get;  }
        public ConcurrentQueue<Pedido> FilaDePedidos { get; }
        public List<Pedido> PedidosProntos { get; }
        public Cozinha(int numCozinheiros)
        {
            if (numCozinheiros < 1) throw new Exception("Número de cozinheiros inválido");
            Cozinheiros = new List<Cozinheiro>();
            for (int i = 0; i < numCozinheiros; i++)
                Cozinheiros.Add(new Cozinheiro());
            FilaDePedidos = new ConcurrentQueue<Pedido>();
            PedidosProntos = new List<Pedido>();
        }

        public void NovoPedido(Pedido pedido) {
            FilaDePedidos.Enqueue(pedido);
            TentarIniciarPreparo();
        }

        private void TentarIniciarPreparo() {
            if(Monitor.TryEnter(AlocarCozinheiroMonitor, 200))
            {
                try
                {
                    var cozinheiro = Cozinheiros.FirstOrDefault(c => c.Livre);
                    if (cozinheiro == null) return;
                    Pedido pedido = null;
                    if (FilaDePedidos.TryDequeue(out pedido))
                        cozinheiro.Preparar(pedido, PedidoPronto);
                }
                finally
                {
                    Monitor.Exit(AlocarCozinheiroMonitor);
                }
            }
        }

        private void PedidoPronto(Pedido pedido)
        {
            PedidosProntos.Add(pedido);
            TentarIniciarPreparo();
        }
    }
}
