import { Observable, Subscriber } from 'rxjs';


import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-cadastrar-usuario',
  templateUrl: './cadastrar-produto.component.html',
  styleUrls: ['./cadastrar-produto.component.css']
})

export class CadastrarProdutoComponent {



  base64File($event: Event) {
    const file = ($event.target as HTMLInputElement).files![0];
    console.log(file)
    this.converterBase64(file)

  }

  converterBase64(file: File) {
    const observable = new Observable((subscribe: Subscriber<any>) => {
      this.readFile(file, subscribe);
    });
    observable.subscribe((d) => {
      console.log(d);
    })
  }

  readFile(file: File, subscribe: Subscriber<any>) {
    const fliereader = new FileReader();
    fliereader.readAsDataURL(file);

    fliereader.onload = () => {
      subscribe.next(fliereader.result);
      subscribe.complete();
    }
    fliereader.onerror = (error) => {
      subscribe.error(error);
      subscribe.complete();
    };


  }


}