import { Component, OnInit } from '@angular/core';

export interface Transaction {
    item: string;
    cost: number;
  }

@Component({
  selector: 'meu-carrinho',
  templateUrl: './meu-carrinho.component.html',
  styleUrls: ['./meu-carrinho.component.css']
})
export class MeuCarrinhoComponent {
    displayedColumns: string[] = ['item', 'cost'];
    transactions: Transaction[] = [
      {item: 'Beach ball', cost: 4},
      {item: 'Towel', cost: 80},
      {item: 'Frisbee', cost: 2},
      {item: 'Sunscreen', cost: 4},
      {item: 'Cooler', cost: 25},
      {item: 'Swim suit', cost: 15},
    ];

    getTotalCost() {
        return this.transactions.map(t => t.cost).reduce((acc, value) => acc + value, 0);
      }
}