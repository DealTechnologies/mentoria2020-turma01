import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { CarrinhoService } from 'src/app/Services/Carrinho/carrinho.service';
import { Carrinho } from 'src/app/Services/Carrinho/carrinho';

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
    private router: Router,
    private carrinhoservice: CarrinhoService
  ) { }

  carrinho: Carrinho[] = []
  ngOnInit(): void {
    if (localStorage.getItem('token') === null) {
      this.router.navigate(['/login'])
      
    }
    this.carrinhoservice.ListarTodos().subscribe(resp => {
      console.log(resp)
      this.carrinho = resp
    })
  }
  displayedColumns: string[] = ['name', 'symbol'];
  dataSource = this.carrinho;
}