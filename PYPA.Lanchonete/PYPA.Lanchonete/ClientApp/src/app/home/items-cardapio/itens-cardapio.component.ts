import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-itens-cardapio',
  templateUrl: './itens-cardapio.component.html',
  styleUrls: ['./itens-cardapio.component.css']
})
export class ItensCardapioComponent implements OnInit {

  @Input()
  Itens = [];
  @Input()
  PodeSelecionar = false;
  @Output()
  ItemSelecionado = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  selecionarItem(item) {
    this.ItemSelecionado.emit(item);
  }

}
