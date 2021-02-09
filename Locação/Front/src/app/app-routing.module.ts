import { HomeComponent } from './Template/home/home/home.component';
import { CardComponent } from './Template/home/card/card.component.spec';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { CadastrarUsuarioComponent } from './Components/cadastrar-usuario/cadastrar-usuario.component';
import { CadastrarProdutoComponent } from './Components/cadastrar-produto/cadastrar-produto.component';
import { ListarProdutoComponent } from './Components/listar-produto/listar-produto.component';
import { AtualizarUsuarioComponent } from './Components/atualizarUsuario/atualizar-usuario/atualizar-usuario.component';
import { AuthGuardGuard } from './guard/auth-guard.guard';
import { MeusPedidosComponent } from './Components/meus-pedidos/meus-pedidos.component';
const routes: Routes = [
  {
    path: '', component: HomeComponent, children: [
      { path: '', component: CardComponent },
      { path: 'cadastrar', component: CadastrarUsuarioComponent },
      { path: 'cadastrarproduto', component: CadastrarProdutoComponent },
      { path: 'meuspedidos', component: MeusPedidosComponent },
      { path: 'listarproduto', component: ListarProdutoComponent },
      { path: 'atualizar', component: AtualizarUsuarioComponent }],
    canActivate: [AuthGuardGuard]
  },
  {
    path: '', component: HomeComponent, children: [
      { path: '', redirectTo: 'card', pathMatch: 'full' },
      { path: 'card', component: CardComponent },
      { path: 'cadastrar', component: CadastrarUsuarioComponent }
    ]
  },

]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
