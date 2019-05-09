import { FilaPedidosComponent } from './home/fila-pedidos/fila-pedidos.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ItensCardapioComponent } from './home/items-cardapio/itens-cardapio.component';
import { NovoItemComponent } from './home/novo-item/novo-item.component';
import { ItensPedidoComponent } from './home/itens-pedido/itens-pedido.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ItensCardapioComponent,
    FilaPedidosComponent,
    NovoItemComponent,
    ItensPedidoComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
