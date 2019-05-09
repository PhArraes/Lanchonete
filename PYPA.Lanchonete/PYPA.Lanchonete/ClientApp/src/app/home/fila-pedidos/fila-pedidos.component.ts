import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-fila-pedidos',
  templateUrl: './fila-pedidos.component.html',
  styleUrls: ['./fila-pedidos.component.css']
})
export class FilaPedidosComponent implements OnInit {
  @Input()
  Pedidos = [];
  @Input()
  PodeRetirar = false;
  constructor() { }
  @Output()
  RetirarPedido = new EventEmitter();
  ngOnInit() {
  }

  itens(pedido) {
    let itens = '';
    pedido.itens.forEach(item => {
      itens += `${item.lanche.nome}(${item.quantidade}), `;
    });
    return itens;
  }

  retirar(pedido) {
    pedido.retirando = true;
    this.RetirarPedido.emit(pedido);
  }
}
