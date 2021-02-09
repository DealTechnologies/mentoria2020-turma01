import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Equipamentos } from './Equipamentos';

@Injectable({
  providedIn: 'root'
})
export class EquipamentosService {

  url = 'https://localhost:44375/v1';

  constructor(private http: HttpClient) { }

  ListarTodos(): Observable<Equipamentos[]> {
    var client = `${this.url}/Equipamentos`
    return this.http.get<Equipamentos[]>(client)
  }

  AdicionarEquipamento(usuario: Equipamentos): Observable<Equipamentos> {
    var client = `${this.url}/Equipamentos`
    return this.http.post<Equipamentos>(client, usuario)
  }

  AtualizarEquipamento(id: string | null, usurio: Equipamentos): Observable<Equipamentos> {

    var client = `${this.url}/Equipamentos/${id}`
    return this.http.put<Equipamentos>(client, usurio)
  }

  BuscarEquipamentoId(id: string | null): Observable<Equipamentos> {
    var client = `${this.url}/Equipamentos/${id}`
    return this.http.get<Equipamentos>(client)
  }

  deletarEquipamento(id: string): Observable<Equipamentos> {
    var client = `${this.url}/Equipamentos/${id}`
    return this.http.delete<Equipamentos>(client)
  }
}
