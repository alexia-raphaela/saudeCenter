import { HttpClient } from '@angular/common/http';
import { IPacienteDto } from '../interfaces/IPacienteDto';
import { Component } from '@angular/core';
import { map } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-listagem-paciente',
  templateUrl: './listagem-paciente.component.html',
  styleUrls: ['./listagem-paciente.component.css']
})
export class ListagemPacienteComponent {

  listaPacientes: IPacienteDto[] = [];
  telaParaApresentar = 'lista'

  constructor(private http: HttpClient, private route: Router){
    this.listarTodos();
  }

  listarTodos(){
    this.http.get('https://localhost:7154/Beneficiario/ListarTodos')
    .pipe(
      map((response:any) => {
        return Object.values(response);
      })
    )
    .subscribe((data) => {
      for(let index = 0; index <data.length; index++){
        let contentJson:any = data[index];
        this.listaPacientes.push(contentJson as IPacienteDto);
      }
    })
  }
}
