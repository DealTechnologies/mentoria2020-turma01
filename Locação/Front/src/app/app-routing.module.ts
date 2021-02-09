import { AtualizarUsuarioComponent } from './Components/atualizarUsuario/atualizar-usuario/atualizar-usuario.component';
import { CardComponent } from './Template/home/card/card.component.spec';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { CadastrarUsuarioComponent } from './Components/cadastrar-usuario/cadastrar-usuario.component';
import { CadastrarProdutoComponent } from './Components/cadastrar-produto/cadastrar-produto.component';
import { ListarProdutoComponent } from './Components/listar-produto/listar-produto.component';
import { MeusPedidosComponent } from './Components/meus-pedidos/meus-pedidos.component';

const routes: Routes = [
  { path: '', component: CardComponent },
  { path: 'cadastrar', component: CadastrarUsuarioComponent },
  { path: 'cadastrarproduto', component: CadastrarProdutoComponent },
  { path: 'listarproduto', component: ListarProdutoComponent },
  { path: 'meuspedidos', component: MeusPedidosComponent },
  { path: 'atualizar', component: AtualizarUsuarioComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
