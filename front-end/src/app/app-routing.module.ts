import { AgendamentoComponent } from './agendamento/agendamento.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroComponent } from './cadastro/cadastro.component';

const routes: Routes = [
  // rota dos componentes
  { path: 'cadastro', component: CadastroComponent },
  { path: 'agendamento', component: AgendamentoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
