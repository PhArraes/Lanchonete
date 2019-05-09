import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-novo-item',
  templateUrl: './novo-item.component.html',
  styleUrls: ['./novo-item.component.css']
})
export class NovoItemComponent implements OnInit {

  nome = '';
  tempo = 0;

  @Output()
  novoItem = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

  adicionarItem() {
    if (this.itemValido()) {
      this.novoItem.emit({ nome: this.nome, tempoDePreparo: this.tempo });
    }
  }

  itemValido() {
    return this.nome && this.tempo > 0;
  }
}
