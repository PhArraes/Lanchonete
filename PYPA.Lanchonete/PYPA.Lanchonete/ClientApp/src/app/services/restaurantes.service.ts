import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RestaurantesService {
  url = 'https://localhost:44358/api/Restaurantes';
  constructor(private http: HttpClient) { }

  get(): Observable<any> {
    return this.http.get(this.url);
  }

  criarCardápio(items): Observable<any> {
    return this.http.post(this.url, {
      'Lanches': items
    });
  }
}
