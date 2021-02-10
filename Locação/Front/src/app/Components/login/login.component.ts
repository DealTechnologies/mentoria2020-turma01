import { Router } from '@angular/router';

import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Login } from 'src/app/Services/login/Login';
import { LoginService } from 'src/app/Services/login/login.service';
import { state } from '@angular/animations';
import { ServicesUsuarioService } from 'src/app/Services/services-usuario.service';
import { Usuario } from 'src/app/Services/Usuario';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  usuario!: Usuario;
  login: Login = {
    cpf: '',
    senha: ''
  }

  mostrarMenu: boolean = false;
  teste = false;

  senhaFormControl = new FormControl('', [Validators.required])
  cpfFormControl = new FormControl('', [Validators.required]);

  constructor(

    private serviceLogin: LoginService,
    private servicesUsuario: ServicesUsuarioService,
    private router: Router,


  ) { }

  ngOnInit(): void {
    this.serviceLogin.mostrarMenu.subscribe(
      mostrar => this.mostrarMenu = mostrar
    )
  }


  // ClosedLogin(): void {
  //   this.dialogRef.close()
  //   this.router.navigate(['/cadastrar']);

  // }

  logar(): void {
    this.serviceLogin.login(this.login).subscribe(x => {


      this.login = x
      console.log(x)
      localStorage.clear();
      localStorage.setItem(`token`, `${this.login.data?.token}`);
      localStorage.setItem(`id`, `${this.login.data?.id}`);
      localStorage.setItem(`role`, `${this.login.data?.role}`);
    });

    this.router.navigate(['']);
  }

}
