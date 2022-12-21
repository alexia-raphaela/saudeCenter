import { AgendamentoComponent } from './agendamento/agendamento.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroMedicoComponent } from './cadastro-medico/cadastro-medico.component';
import { CadastroHospitalComponent } from './cadastro-hospital/cadastro-hospital.component';
import { CadastroComponent } from './cadastro-paciente/cadastro.component';
import { CadastroEspecialidadeComponent } from './cadastro-especialidade/cadastro-especialidade.component'
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'cadastro', component: CadastroComponent },
  { path: 'cadastro-medico', component: CadastroMedicoComponent },
  { path: 'cadastro-hospital', component: CadastroHospitalComponent },
  { path: 'cadastro-especialidade', component: CadastroEspecialidadeComponent },
  { path: 'agendamento', component: AgendamentoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
