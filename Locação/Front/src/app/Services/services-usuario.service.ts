import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from './Usuario';
import { UsuarioAdd } from './UsuarioAdd';


@Injectable({
  providedIn: 'root'
})
export class ServicesUsuarioService {

  url = 'https://localhost:44375/v1';

  constructor(private http: HttpClient) { }

  ListarTodos(): Observable<Usuario> {
    var client = `${this.url}/clientes`
    return this.http.get<Usuario>(client)
  }

  AdicionarUsuario(usuario: UsuarioAdd): Observable<UsuarioAdd> {
    var client = `${this.url}/clientes`
    return this.http.post<UsuarioAdd>(client, usuario)
  }

  AtualizarUsuario(usurio: Usuario): Observable<Usuario> {
    let headers = new HttpHeaders();
    if (localStorage.getItem('token') != null) {

      headers = headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`);
    }
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    var id = localStorage.getItem("id");
    var client = `${this.url}/clientes/${id}`
    return this.http.put<Usuario>(client, usurio, { headers: headers })
  }

  BuscarUsuarioId(): Observable<Usuario> {

    let headers = new HttpHeaders();
    if (localStorage.getItem('token') != null) {

      headers = headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`);
    }
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    var id = localStorage.getItem("id");
    localStorage.getItem("token");
    var client = `${this.url}/clientes/${id}`
    return this.http.get<Usuario>(client, { headers: headers })
  }
}
