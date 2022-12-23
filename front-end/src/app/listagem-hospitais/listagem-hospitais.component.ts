import { HttpClient } from '@angular/common/http';
import { IHospitalDto } from './../interfaces/IHospitalDto';

import { Component } from '@angular/core';

import { map } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-listagem-hospitais',
  templateUrl: './listagem-hospitais.component.html',
  styleUrls: ['./listagem-hospitais.component.css']
})
export class ListagemHospitaisComponent {
  listaHospitais: IHospitalDto[] = [];
  telaParaApresentar = 'lista'

  constructor(private http: HttpClient, private router: Router){

    this.listarTodos();

  }
  listarTodos(){

    this.http.get('https://localhost:7154/Hospital/ListarTodos')

    .pipe(

      map((response:any) => {

        return Object.values(response);

      })

    )

    .subscribe((data) => {
      for(let index = 0; index <data.length; index++){
        let contentJson:any = data[index];
        this.listaHospitais.push(contentJson as IHospitalDto);
      }

    });

  }

}

