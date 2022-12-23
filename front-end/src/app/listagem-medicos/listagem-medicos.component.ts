import { HttpClient } from '@angular/common/http';
import { IProfissionalDto } from './../interfaces/IProfissionalDto';

import { Component } from '@angular/core';

import { map } from 'rxjs';
import { Router } from '@angular/router';



@Component({

  selector: 'app-listagem-medico',

  templateUrl: './listagem-medicos.component.html',

  styleUrls: ['./listagem-medicos.component.css']

})

export class ListagemMedicoComponent {

  listaProfissionais: IProfissionalDto[] = [];
  telaParaApresentar = 'lista'

  constructor(private http: HttpClient, private router: Router){

    this.listarTodos();

  }

  listarTodos(){

    this.http.get('https://localhost:7154/Profissional/ListarTodos')

    .pipe(

      map((response:any) => {

        return Object.values(response);

      })

    )

    .subscribe((data) => {

      for(let index = 0; index <data.length; index++){

        let contentJson:any = data[index];

        //let conteudoTipoTemp:IProfissionalDto = conteudoJson as IProfissionalDto;

       // this.listaProfissionais.push({idProfissional:conteudoJson.idProfissional, nome:conteudoJson.nome, telefone:conteudoJson.telefone, endereco:conteudoJson.endereco, ativo:conteudoJson.ativo});

       this.listaProfissionais.push(contentJson as IProfissionalDto);

      }

    });

  }

}
