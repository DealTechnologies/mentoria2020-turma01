import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from './Login';
import { EventEmitter } from '@angular/core';
import { ServicesUsuarioService } from '../services-usuario.service';

import { Usuario } from '../Usuario';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private usuarioAutenticado: boolean = false;

  mostrarMenu = new EventEmitter<boolean>()
  showButton = new EventEmitter<boolean>()
  url = 'https://localhost:44375/v1';

  constructor(private http: HttpClient,
    private servicesUsuario: ServicesUsuarioService) { }
  usuario!: Usuario;

  login(login: Login): Observable<Login> {
    var baseurl = `${this.url}/login`
    let entrar = this.http.post<Login>(baseurl, login)

    if (entrar != null) {
      this.usuarioAutenticado = true;
      this.mostrarMenu.emit(true);
    } else {
      this.usuarioAutenticado = false;
      this.mostrarMenu.emit(false);
    }

    return entrar;
  }


  usuarioLogado() {
    return this.usuarioAutenticado;
  }

}