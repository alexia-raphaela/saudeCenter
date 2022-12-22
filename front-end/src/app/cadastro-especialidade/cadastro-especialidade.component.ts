import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IEspecialidadeDto } from '../interfaces/IEspecialidade';

@Component({
  selector: 'app-cadastro-especialidade',
  templateUrl: './cadastro-especialidade.component.html',
  styleUrls: ['./cadastro-especialidade.component.css']
})
export class CadastroEspecialidadeComponent {
  especialidade!: IEspecialidadeDto;
  idRecebido!: number;

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.route.paramMap.subscribe(params => {
      this.idRecebido = Number(params.get('id'))
    })
  }

  ngOnInit(): void {
    this.especialidade = {
      nome: '',
      descricao: '',
      ativo: true
    }
  }

  cadastrar() {
    this.http.post('https://localhost:7154/Especialidade/CadastrarEspecialidade', this.especialidade)
      .subscribe((data: any) => {
        this.router.navigate(['cadastro-especialidade'])
      })
  }

  submitFormularioEspecialidade(valorFormulario: any) {
    console.log(`valor do formulário: ${JSON.stringify(valorFormulario)}`)
    this.cadastrar()
  }
}

