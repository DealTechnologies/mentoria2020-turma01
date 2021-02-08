import { HttpClient } from '@angular/common/http';
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

  BuscarUsuarioId(): Observable<Usuario> {
    var id = localStorage.getItem("id");
    localStorage.getItem("token");
    var client = `${this.url}/clientes/${id}`
    return this.http.get<Usuario>(client)

  }
}
