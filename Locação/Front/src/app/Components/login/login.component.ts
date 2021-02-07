import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  senhaFormControl = new FormControl('', [Validators.required,])
  emailFormControl = new FormControl('', [Validators.required, Validators.email,]);

  constructor(public dialogRef: MatDialogRef<LoginComponent>) { }

  ngOnInit(): void {
  }

  ClosedLogin(): void {
    this.dialogRef.close();
  }

}
