import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { CardComponent } from 'src/app/Template/home/card/card.component';

export interface Transaction {
  nome: string;
  valorDiaria: number;
}

@Component({
  selector: 'meu-carrinho',
  templateUrl: './meu-carrinho.component.html',
  styleUrls: ['./meu-carrinho.component.css']
})
export class MeuCarrinhoComponent implements OnInit {

  displayedColumns: string[] = ['nome', 'valor'];
  carrinho = JSON.parse(localStorage.getItem("carrinho") || '[]')
  transactions : Transaction[] = this.carrinho
  
  constructor(
    private router: Router
    ) { }
    
    ngOnInit(): void {
      if (localStorage.getItem('token') === null) {
        this.router.navigate(['/login'])
      }
      console.log(localStorage.getItem("carrinho"))
  }


  getTotalCost() {
    return this.transactions.map(t => t.valorDiaria).reduce((acc, value) => acc + value, 0);
  }
}