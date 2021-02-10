import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { CardComponent } from 'src/app/Template/home/card/card.component';
import { CarrinhoService } from 'src/app/Services/Carrinho/carrinho.service';
import { Carrinho } from 'src/app/Services/Carrinho/carrinho';
import Swal from 'sweetalert2';

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
  transactions: Transaction[] = JSON.parse(localStorage.getItem("carrinho") || '[]')
  carrinho: Carrinho = {
    idUsuario: 'string',
    equipamentos: [
      {
        id: 'string',
        nome: 'string',
        descricao: 'string',
        cor: 'string',
        modelo: 'string',
        imagem: 'string',
        saldoEstoque: 0,
        valorDiaria: 0,
        quantidadeAlugado: 0
      }
    ],
    dataLocacao: 'string',
    dataDevolucao: 'string',
    valorFrete: 0,
    valorAluguel: 0,
    valorTotal: 0
  }

  constructor(
    private router: Router,
    private serviceCarrinho: CarrinhoService,
  ) { }

  ngOnInit(): void {
    if (localStorage.getItem('token') === null) {
      this.router.navigate(['/login'])
    }
  }
  salvarLocacao() {
    let requisicao: Carrinho = {
      idUsuario: localStorage.getItem('id') || '',
      equipamentos: JSON.parse(localStorage.getItem("carrinho") || '[]'),
      dataLocacao: this.carrinho.dataLocacao,
      dataDevolucao: this.carrinho.dataDevolucao,
      valorFrete: 15.0,
      valorAluguel: this.transactions.map(t => t.valorDiaria).reduce((acc, value) => acc + value, 0),
      valorTotal: this.transactions.map(t => t.valorDiaria).reduce((acc, value) => acc + value, 0) + 15.0
    }
    this.serviceCarrinho.AdicionarCarrinho(requisicao).subscribe(resp => {
      console.log(resp)
      Swal.fire(
        'Produtos Alugado!',
        'Com Sucesso!',
        'success'
      );
    });
  }

  getTotalCost() {
    return this.transactions.map(t => t.valorDiaria).reduce((acc, value) => acc + value, 0);
  }
}