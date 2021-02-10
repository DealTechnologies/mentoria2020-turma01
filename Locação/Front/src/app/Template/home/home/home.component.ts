import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login/login.service';
import { Usuario } from './../../../Services/Usuario';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from 'src/app/Components/login/login.component';

import { ServicesUsuarioService } from 'src/app/Services/services-usuario.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  mostrarMenu: boolean = false;
  showButton: boolean = true;
  usuario!: Usuario;


  constructor(
    private dialog: MatDialog,
    private router: Router,
    private serviceLogin: LoginService) { }

  ngOnInit(): void {
    this.serviceLogin.mostrarMenu.subscribe(
      mostrar => this.mostrarMenu = mostrar
    );


  }

  sair(): void {
    localStorage.clear();
    this.router.navigate(['']);
    this.mostrarMenu = false
    this.showButton = false
  }
  // openDialog() {
  //   const dialogRef = this.dialog.open(LoginComponent, {
  //     width: '400px',
  //     height: '500px'
  //   });
  // }

}
