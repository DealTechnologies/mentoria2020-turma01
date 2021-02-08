import { CardComponent } from './Template/home/card/card.component.spec';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrarUsuarioComponent } from './Components/cadastrar-usuario/cadastrar-usuario.component';

const routes: Routes = [
  { path: '', component: CardComponent },
  { path: 'cadastrar', component: CadastrarUsuarioComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
