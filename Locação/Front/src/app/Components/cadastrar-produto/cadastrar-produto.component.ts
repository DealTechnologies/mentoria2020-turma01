import { Equipamentos } from './../../Services/equipamentos/Equipamentos';
import { Observable, Subscriber } from 'rxjs';


import { Component, OnInit } from '@angular/core';
import { EquipamentosService } from 'src/app/Services/equipamentos/equipamentos.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-cadastrar-usuario',
  templateUrl: './cadastrar-produto.component.html',
  styleUrls: ['./cadastrar-produto.component.css']
})

export class CadastrarProdutoComponent implements OnInit {

  imagem: string = '';
  id = localStorage.getItem('idProduto')

  equipamento: Equipamentos = {
    nome: '',
    cor: '',
    descricao: '',
    imagem: ' ',
    modelo: '',
    saldoEstoque: 0,
    valorDiaria: 0
  }
  constructor(
    private equipamentosService: EquipamentosService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id != null) {
      this.equipamentosService.BuscarEquipamentoId(id).subscribe(resp => {
        this.equipamento = resp;
        console.log(this.equipamento)
        localStorage.setItem('idProduto', `${this.equipamento.id}`);
      })

    }
  }

  Adicionar(): void {

    if (localStorage.getItem('idProduto') != '') {
      this.equipamento.imagem = this.equipamento.imagem;
      this.equipamentosService.AtualizarEquipamento(this.id, this.equipamento).subscribe(x => {
        try {
          console.log(x)
          localStorage.removeItem('idProduto')

        } catch (error) {
          console.log(error);
        }
      })
    } else {
      this.equipamento.imagem = this.imagem;
      this.equipamentosService.AdicionarEquipamento(this.equipamento).subscribe(x => {
        try {
          console.log(x)

        } catch (error) {
          console.log(error);
        }
      })
    }
  }


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
      this.imagem = d;
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