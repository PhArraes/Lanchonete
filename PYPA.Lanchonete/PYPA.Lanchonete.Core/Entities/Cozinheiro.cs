using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PYPA.Lanchonete.Core
{
    class Cozinheiro
    {

        public bool Livre { get; set; }
        public Cozinheiro()
        {
            Livre = true;
        }

        public void Preparar(Pedido pedido, Action<Pedido> prontoCallBack)
        {
            if (!Livre) throw new Exception("Cozinheiro não está livre");
            Livre = false;
            new Task(() => {
                pedido.IniciarPreparo();
                int tempoDePreparoTotal = pedido.Itens.Sum(i => i.Lanche.TempoDePreparo * i.Quantidade);
                Thread.Sleep(1000 * tempoDePreparoTotal);
                pedido.FinalizarPreparo();
                Livre = true;
                prontoCallBack(pedido);
            }).Start();
        }
    }
}
