import { IBeneficiarioDto } from '../interfaces/IBeneficiario';
import { Component, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent {
  beneficiario!: IBeneficiarioDto;
  idRecebido!: number;


  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.route.paramMap.subscribe(params => {
      this.idRecebido = Number(params.get('id'));
    });
  }

  //REST_API_SERVER = "https://localhost:7154/swagger/index.html";


  ngOnInit(): void {
    this.beneficiario = {
      nome: '',
      cpf: '',
      email: '',
      senha: '',
      endereco: '',
      telefone: '',
      numeroCarteirinha: '',
      ativo:true,
    }
  }

  cadastrar() {
    //implementar o objeto na api, chamar a api(subcribe)
    this.http.post('https://localhost:7154/Beneficiario/CadastrarBeneficiario', this.beneficiario)
      .subscribe((data: any) => {
          this.router.navigate(['cadastro']);
      });
  }

  submitFormularioTarefa(valorFormulario: any) {
    console.log(`valor do formulário: ${JSON.stringify(valorFormulario)}`);
    this.cadastrar();
  }

}

