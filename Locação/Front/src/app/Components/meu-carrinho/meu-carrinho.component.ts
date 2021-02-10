import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { CardComponent } from 'src/app/Template/home/card/card.component';

export interface Transaction {
  item: string;
  cost: number;
}

@Component({
  selector: 'meu-carrinho',
  templateUrl: './meu-carrinho.component.html',
  styleUrls: ['./meu-carrinho.component.css']
})
export class MeuCarrinhoComponent implements OnInit {

  constructor(
    private router: Router,
    private carrinho: CardComponent
  ) { }

  ngOnInit(): void {
    if (localStorage.getItem('token') === null) {
      this.router.navigate(['/login'])
    }
    //  this.carrinho.equipamentos
  }

  displayedColumns: string[] = ['item', 'cost'];
  transactions: Transaction[] = [
    { item: 'Beach ball', cost: 4 },
    { item: 'Frete', cost: 15 },
  ];

  getTotalCost() {
    return this.transactions.map(t => t.cost).reduce((acc, value) => acc + value, 0);
  }
}