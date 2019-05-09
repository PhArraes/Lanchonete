import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-itens-pedido',
  templateUrl: './itens-pedido.component.html',
  styleUrls: ['./itens-pedido.component.css']
})
export class ItensPedidoComponent implements OnInit {

  @Input()
  Itens = [];
  @Output()
  RemoverItem = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

  removerItem(item) {
    this.RemoverItem.emit(item);
  }
}
