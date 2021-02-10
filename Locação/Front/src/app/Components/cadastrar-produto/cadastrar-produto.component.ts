import { Equipamentos } from './../../Services/equipamentos/Equipamentos';
import { Observable, Subscriber } from 'rxjs';


import { Component, OnInit } from '@angular/core';
import { EquipamentosService } from 'src/app/Services/equipamentos/equipamentos.service';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-cadastrar-usuario',
  templateUrl: './cadastrar-produto.component.html',
  styleUrls: ['./cadastrar-produto.component.css']
})

export class CadastrarProdutoComponent implements OnInit {

  imagem: string = '';
  id: boolean = false

  equipamento: Equipamentos = {
    id: '',
    nome: '',
    cor: '',
    descricao: '',
    imagem: ' ',
    modelo: '',
    saldoEstoque: 0,
    valorDiaria: 0,
    quantidadeAlugado: 1
  }
  constructor(
    private equipamentosService: EquipamentosService,
    private router: Router,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {

    if (localStorage.getItem('token') === null) {
      this.router.navigate(['/login'])
    }

    const id = this.route.snapshot.paramMap.get('id');
    if (id != null) {
      this.equipamentosService.BuscarEquipamentoId(id).subscribe(resp => {
        this.equipamento = resp;
        console.log(this.equipamento)
        this.id = true
        localStorage.setItem('idProduto', `${this.equipamento.id}`);
      })

    }
  }

  Adicionar(): void {

    if (this.id) {
      console.log(this.equipamento)
      this.equipamento.imagem = this.equipamento.imagem;
      this.equipamentosService.AtualizarEquipamento(localStorage.getItem('idProduto'), this.equipamento).subscribe(x => {
        try {
          console.log(x)
          this.id = false
          this.router.navigate([''])
          Swal.fire(
            'Atualizado!',
            'Equipamento Atualizado!',
            'success'
          );
        } catch (error) {
          console.log(error);
        }
      })
    } else {
      this.equipamento.imagem = this.imagem;
      this.equipamentosService.AdicionarEquipamento(this.equipamento).subscribe(x => {
        try {
          console.log(x)
          this.router.navigate([''])
          Swal.fire(
            'Adicionado!',
            'Equipamento Adicionado!',
            'success'
          );
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