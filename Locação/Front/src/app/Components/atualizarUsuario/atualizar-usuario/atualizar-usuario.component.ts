import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ServicesUsuarioService } from 'src/app/Services/services-usuario.service';
import { Usuario } from 'src/app/Services/Usuario';
import { UsuarioAdd } from 'src/app/Services/UsuarioAdd';

@Component({
  selector: 'app-atualizar-usuario',
  templateUrl: './atualizar-usuario.component.html',
  styleUrls: ['./atualizar-usuario.component.css']
})
export class AtualizarUsuarioComponent implements OnInit {


  usuario: Usuario = {
    nome: '',
    senha: '',
    rg: '',
    cpf: '',
    email: '',
    dataNascimento: '',
    cep: '',
    rua: '',
    numero: undefined,
    complemento: '',
    cidade: '',
    estado: '',
    pais: ''
  };


  constructor(
    private serviceUsuario: ServicesUsuarioService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.serviceUsuario.BuscarUsuarioId().subscribe(resp => {
      this.usuario = resp;

    })
  }

  atualizar(): void {
    this.serviceUsuario.AtualizarUsuario(this.usuario).subscribe(resp => {
      console.log(resp)
      this.router.navigate([''])
    })
    console.log(this.usuario)
  }

}
