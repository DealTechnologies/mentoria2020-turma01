import { UsuarioAdd } from './../../Services/UsuarioAdd';
import { Usuario } from './../../Services/Usuario';

import { Component, OnInit } from '@angular/core';
import { ServicesUsuarioService } from 'src/app/Services/services-usuario.service';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastrar-usuario',
  templateUrl: './cadastrar-usuario.component.html',
  styleUrls: ['./cadastrar-usuario.component.css']
})
export class CadastrarUsuarioComponent implements OnInit {

  usuario!: Usuario;
  usuarioAdd: UsuarioAdd = {
    nome: '',
    senha: '',
    rg: '',
    cpf: '',
    email: '',
    dataNascimento: ''

  };



  constructor(
    private servicesUsuario: ServicesUsuarioService,
    private router: Router
  ) {

  }

  ngOnInit(): void {
    console.log(localStorage.getItem('token'))

  }

  AdicionarUsuario(): void {
    this.servicesUsuario.AdicionarUsuario(this.usuarioAdd).subscribe(resp => {
      console.log(resp);
      this.router.navigate(['']);
    });

    console.log(this.usuarioAdd)
  }


}
