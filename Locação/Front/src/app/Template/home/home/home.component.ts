import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login/login.service';
import { Usuario } from './../../../Services/Usuario';
import { Component, OnInit, AfterViewInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from 'src/app/Components/login/login.component';

import { ServicesUsuarioService } from 'src/app/Services/services-usuario.service';
import { stringify } from '@angular/compiler/src/util';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  mostrarMenu: boolean = false;
  showButtonClient: boolean = true;
  showButtonAdin: boolean = true;
  teste: string = '';
  usuario!: Usuario;


  constructor(
    private dialog: MatDialog,
    private router: Router,
    private serviceLogin: LoginService) { }

  ngOnInit(): void {
    localStorage.clear();
    this.primeiroAcesso()

    this.serviceLogin.mostrarMenu.subscribe(
      mostrar => this.mostrarMenu = mostrar);

  }

  ngDoCheck() {
    if (localStorage.getItem('role') === 'Administrador' && localStorage.getItem('role') != null) {
      this.showButtonClient = false
    }
    if (localStorage.getItem('role') === 'Cliente' && localStorage.getItem('role') != null) {
      this.showButtonAdin = false
    }
  }


  primeiroAcesso() {
    localStorage.setItem('primeiroAcesso', 'true')
  }

  sair(): void {
    localStorage.clear();
    this.router.navigate(['']);
    this.mostrarMenu = false
    this.showButtonAdin = true
    this.showButtonClient = true
  }

  // openDialog() {
  //   const dialogRef = this.dialog.open(LoginComponent, {
  //     width: '400px',
  //     height: '500px'
  //   });
  // }

}
