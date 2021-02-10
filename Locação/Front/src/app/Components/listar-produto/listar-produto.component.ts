import { Equipamentos } from './../../Services/equipamentos/Equipamentos';
import { Component, OnInit } from '@angular/core';
import { EquipamentosService } from 'src/app/Services/equipamentos/equipamentos.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H' },
  { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He' },
  { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li' },
  { position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be' },
  { position: 5, name: 'Boron', weight: 10.811, symbol: 'B' },
  { position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C' },
  { position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N' },
  { position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O' },
  { position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F' },
  { position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne' },
];

@Component({
  selector: 'listar-produto',
  templateUrl: './listar-produto.component.html',
  styleUrls: ['./listar-produto.component.css']
})
export class ListarProdutoComponent implements OnInit {

  equipamentos: Equipamentos[] = []
  displayedColumns: string[] = ['name', 'descricao', 'cor', 'modelo', 'saldo', 'valor', 'acao'];


  constructor(
    private equipamentosService: EquipamentosService,
    private router: Router,

  ) {

  }

  ngOnInit(): void {

    if (localStorage.getItem('token') === null) {
      this.router.navigate(['/login'])
    }
    this.listarTodos()
  }

  listarTodos(): void {

    this.equipamentosService.ListarTodos().subscribe(resp => {
      console.log(resp)
      this.equipamentos = resp
      console.log(this.equipamentos)

    })
  }

  removerEqp(id: string): void {
    this.equipamentosService.deletarEquipamento(id).subscribe(resp => {
      Swal.fire(
        'deletado!',
        'Equipamento removido!',
        'success'
      );
      this.listarTodos()
    });
    this.router.navigate(['/listarproduto'])
  }
}
