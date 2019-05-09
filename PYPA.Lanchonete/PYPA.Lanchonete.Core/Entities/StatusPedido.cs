using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PYPA.Lanchonete.Core
{
    public enum StatusPedido
    {
        [Description("Na Fila")]
        NaFila = 0,
        [Description("Preparo Iniciado")]
        PreparoIniciado = 1,
        [Description("Preparo Finalizado")]
        PreparoFinalizado = 2,
        [Description("Pedido Entregue")]
        PedidoEntregue = 3
    }
}
