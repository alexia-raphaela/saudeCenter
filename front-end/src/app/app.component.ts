import { IBeneficiarioDto } from './interfaces/IBeneficiario';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'saudeCenter';
  home: IBeneficiarioDto[] = [];
  cadastro!: IBeneficiarioDto;
  telaParaApresentar = 'beneficiario'

  cadastrarBeneficiario(){}

  constructor(private router: Router){

  }
  ngOnInit(){}

  goToCadastrar(){
    this.router.navigate(['/cadastrar'])
  }
}

