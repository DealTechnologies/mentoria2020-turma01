import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Carrinho } from './carrinho';

@Injectable({
  providedIn: 'root'
})
export class CarrinhoService {
  url = 'https://localhost:44375/v1';

  constructor(private http: HttpClient) { }


  ListarTodos(): Observable<Carrinho[]> {
    let headers = new HttpHeaders();
    if (localStorage.getItem('token') != null) {

      headers = headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`);
    }
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    var client = `${this.url}/locacoes`
    return this.http.get<Carrinho[]>(client, {headers:headers})
  }

  AdicionarCarrinho(locacao: Carrinho): Observable<Carrinho> {

    let headers = new HttpHeaders();
    if (localStorage.getItem('token') != null) {

      headers = headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`);
    }
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    var client = `${this.url}/locacoes`
    return this.http.post<Carrinho>(client, locacao, { headers: headers })
  }

//   AtualizarEquipamento(id: string | null, usurio: Carrinho): Observable<Carrinho> {

//     let headers = new HttpHeaders();
//     if (localStorage.getItem('token') != null) {

//       headers = headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`);
//     }
//     headers = headers.set('Content-Type', 'application/json; charset=utf-8');

//     var client = `${this.url}/Equipamentos/${id}`
//     return this.http.put<Carrinho>(client, usurio, { headers: headers });
//   }

//   BuscarEquipamentoId(id: string | null): Observable<Equipamentos> {

//     let headers = new HttpHeaders();
//     if (localStorage.getItem('token') != null) {

//       headers = headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`);
//     }

//     headers = headers.set('Content-Type', 'application/json; charset=utf-8');



//     var client = `${this.url}/Equipamentos/${id}`
//     return this.http.get<Equipamentos>(client, { headers: headers })
//   }

//   deletarCarrinho(id: string): Observable<Carrinho> {

//     let headers = new HttpHeaders();
//     if (localStorage.getItem('token') != null) {

//       headers = headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`);
//     }
//     headers = headers.set('Content-Type', 'application/json; charset=utf-8');

//     var client = `${this.url}/locacoes/${id}`
//     return this.http.delete<Carrinho>(client, { headers: headers })
//   }
// }


}
