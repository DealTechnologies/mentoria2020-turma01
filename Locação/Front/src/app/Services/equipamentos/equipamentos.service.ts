import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Equipamentos } from './Equipamentos';

@Injectable({
  providedIn: 'root'
})
export class EquipamentosService {

  url = 'https://localhost:44375/v1';

  constructor(private http: HttpClient) { }


  ListarTodos(): Observable<Equipamentos[]> {
    var client = `${this.url}/Equipamentos`
    return this.http.get<Equipamentos[]>(client)
  }

  AdicionarEquipamento(usuario: Equipamentos): Observable<Equipamentos> {

    let headers = new HttpHeaders();
    if (localStorage.getItem('token') != null) {

      headers = headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`);
    }
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    var client = `${this.url}/Equipamentos`
    return this.http.post<Equipamentos>(client, usuario, { headers: headers })
  }

  AtualizarEquipamento(id: string | null, usurio: Equipamentos): Observable<Equipamentos> {

    let headers = new HttpHeaders();
    if (localStorage.getItem('token') != null) {

      headers = headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`);
    }
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    var client = `${this.url}/Equipamentos/${id}`
    return this.http.put<Equipamentos>(client, usurio, { headers: headers });
  }

  BuscarEquipamentoId(id: string | null): Observable<Equipamentos> {

    let headers = new HttpHeaders();
    if (localStorage.getItem('token') != null) {

      headers = headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`);
    }

    headers = headers.set('Content-Type', 'application/json; charset=utf-8');



    var client = `${this.url}/Equipamentos/${id}`
    return this.http.get<Equipamentos>(client, { headers: headers })
  }

  deletarEquipamento(id: string): Observable<Equipamentos> {

    let headers = new HttpHeaders();
    if (localStorage.getItem('token') != null) {

      headers = headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`);
    }
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    var client = `${this.url}/Equipamentos/${id}`
    return this.http.delete<Equipamentos>(client, { headers: headers })
  }
}
