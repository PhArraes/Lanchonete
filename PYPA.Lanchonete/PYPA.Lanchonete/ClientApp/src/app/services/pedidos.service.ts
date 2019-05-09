import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PedidosService {
  url = 'https://localhost:44358/api/Pedidos';
  constructor(private http: HttpClient) { }

  pedidos(): Observable<any> {
    return this.http.get(this.url);
  }

  novoPedido(itens): Observable<any> {
    return this.http.post(this.url, {
      'Items': itens
    });
  }

  retirarPedido(numero) {
    return this.http.put(`${this.url}/${numero}`, {});
  }
}
