import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastroComponent } from './cadastro-paciente/cadastro.component';
import { AgendamentoComponent } from './agendamento/agendamento.component';
import { CadastroHospitalComponent } from './cadastro-hospital/cadastro-hospital.component';
import { CadastroMedicoComponent } from './cadastro-medico/cadastro-medico.component';
import { CadastroEspecialidadeComponent } from './cadastro-especialidade/cadastro-especialidade.component';
import { HomeComponent } from './home/home.component';
import { ListagemPacienteComponent } from './listagem-paciente/listagem-paciente.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    CadastroComponent,
    AgendamentoComponent,
    CadastroHospitalComponent,
    CadastroMedicoComponent,
    CadastroEspecialidadeComponent,
    HomeComponent,
    ListagemPacienteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }