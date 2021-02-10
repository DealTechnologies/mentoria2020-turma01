import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Equipamentos } from 'src/app/Services/equipamentos/Equipamentos';
import { EquipamentosService } from 'src/app/Services/equipamentos/equipamentos.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {

  equipamentos: Equipamentos[] = [];
  equipamentosCarrinho: Equipamentos[] = []

  constructor(private router: Router,
    private equipamentoService: EquipamentosService) { }

  ngOnInit(): void {
    this.equipamentoService.ListarTodos().subscribe(resp => {
      try {
        this.equipamentos = resp;
        console.log(this.equipamentos);
      } catch (error) {
        console.log(error);
      }
    })
  }

  Alugar(equipamento: Equipamentos) {
    this.equipamentosCarrinho.push(equipamento);
    console.log(this.equipamentosCarrinho);
  }

}
