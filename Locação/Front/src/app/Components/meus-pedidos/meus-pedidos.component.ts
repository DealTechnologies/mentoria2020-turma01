import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

export interface PeriodicElement {
  name: string;
  weight: string;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { name: 'Martelo', weight: 'Martelo que martela os trem', symbol: 'Enviado' },
  { name: 'Martelo', weight: 'Martelo que martela os trem', symbol: 'Enviado' },
  { name: 'Martelo', weight: 'Martelo que martela os trem', symbol: 'Enviado' },
  { name: 'Martelo', weight: 'Martelo que martela os trem', symbol: 'Enviado' },
  { name: 'Martelo', weight: 'Martelo que martela os trem', symbol: 'Enviado' },
  { name: 'Martelo', weight: 'Martelo que martela os trem', symbol: 'Enviado' },
  { name: 'Martelo', weight: 'Martelo que martela os trem', symbol: 'Enviado' },
];

@Component({
  selector: 'meus-pedidos',
  templateUrl: './meus-pedidos.component.html',
  styleUrls: ['./meus-pedidos.component.css']
})
export class MeusPedidosComponent implements OnInit {
  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
    if (localStorage.getItem('token') === null) {
      this.router.navigate(['/login'])
    }
  }
  displayedColumns: string[] = ['name', 'weight', 'symbol'];
  dataSource = ELEMENT_DATA;
}