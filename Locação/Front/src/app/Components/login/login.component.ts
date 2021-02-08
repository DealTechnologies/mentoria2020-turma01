
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Login } from 'src/app/Services/login/Login';
import { LoginService } from 'src/app/Services/login/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login: Login = {
    cpf: '',
    senha: ''
  }



  senhaFormControl = new FormControl('', [Validators.required])
  cpfFormControl = new FormControl('', [Validators.required]);

  constructor(
    public dialogRef: MatDialogRef<LoginComponent>,
    private serviceLogin: LoginService
  ) { }

  ngOnInit(): void {
    this.login
  }


  ClosedLogin(): void {
    this.dialogRef.close()

  }

  logar(): void {
    this.serviceLogin.login(this.login).subscribe(x => {
      this.login = x
      console.log(this.login.data?.id)
      localStorage.clear();
      localStorage.setItem(`token`, `${this.login.data?.token}`);
      localStorage.setItem(`id`, `${this.login.data?.id}`);
      this.ClosedLogin();
    })
  }

}
