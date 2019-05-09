import { PedidosService } from './../services/pedidos.service';
import { RestaurantesService } from './../services/restaurantes.service';
import { Component, OnInit, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit, OnDestroy {
  itensCardapio = [];
  cardapioOk = false;
  timeout: any;
  pedidos = [];
  pedidosFila = [];
  pedidosProntos = [];
  pedidosEntregues = [];
  pedidosIniciados = [];

  pedido = [];
  constructor(private restaurantesService: RestaurantesService,
    private pedidosService: PedidosService) {
  }


  ngOnInit() {
    this.restaurantesService.get().subscribe(res => {
      if (res) {
        this.cardapioOk = true;
        this.itensCardapio = res.cardapio.lanches;
      }
    });
    this.carregarPedidos();
  }

  criarCardapio() {
    if (this.itensCardapio.length) {
      this.restaurantesService.criarCardápio(this.itensCardapio).subscribe(res => {
        this.cardapioOk = true;
      });
    }
  }

  novoPedido() {
    this.pedidosService.novoPedido(this.pedido).subscribe(res => {

    });
  }

  adicionarItem(event) {
    this.itensCardapio = this.itensCardapio.filter(i => i.nome !== event.nome);
    this.itensCardapio.push(event);
  }

  adicionarItemPedido(item) {
    let itemPedido = this.pedido.find(i => i.nome === item.nome);
    if (itemPedido === null || itemPedido === undefined) {
      itemPedido = { nome: item.nome, quantidade: 0 };
      this.pedido.push(itemPedido);
    }
    itemPedido.quantidade += 1;
  }

  retirarPedido(pedido) {
    this.pedidosService.retirarPedido(pedido.numero).subscribe();
  }

  removerItem(item) {
    this.pedido = this.pedido.filter(i => i.nome !== item.nome);
  }

  carregarPedidos() {
    this.pedidosService.pedidos().subscribe(res => {
      this.pedidos = res;
      this.pedidosFila = res.filter(p => p.status === 0);
      this.pedidosIniciados = res.filter(p => p.status === 1);
      this.pedidosProntos = res.filter(p => p.status === 2);
      this.pedidosProntos = res.filter(p => p.status === 2);
      this.pedidosEntregues = res.filter(p => p.status === 3);
      if (this.timeout) {
        clearTimeout(this.timeout);
      }
      this.timeout = setTimeout(() => {
        this.carregarPedidos();
      }, 1000);
    }, err => {
      if (this.timeout) {
        clearTimeout(this.timeout);
      }
      this.timeout = setTimeout(() => {
        this.carregarPedidos();
      }, 1000);
    });
  }

  ngOnDestroy() {
    if (this.timeout) {
      clearTimeout(this.timeout);
    }
  }
}
