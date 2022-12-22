
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IDadosBancariosDto } from '../interfaces/IDadosBancariosDto';


@Component({
  selector: 'app-cadastro-dados-bancarios',
  templateUrl: './dados-bancarios.component.html',
  styleUrls: ['./dados-bancarios.component.css']
})
export class CadastroDadosBancariosComponent {
  dadosBancarios!: IDadosBancariosDto;
  idRecebido!: number;
  storageInfo!: Storage;



  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.route.paramMap.subscribe(params => {
      this.idRecebido = Number(params.get('id'));
      this.storageInfo = window.localStorage;
    });
  }
  //REST_API_SERVER = "https://localhost:7154/swagger/index.html";




  ngOnInit(): void {
    this.dadosBancarios = {
      NumeroBanco: '',
      CodigoPix:'',
      Agencia:'',
      NumeroConta:'',
      Poupanca: true,
      IdProfissional: 0,
    }
  }



  cadastrarDadosBancarios() {
    //implementar o objeto na api, chamar a api(subcribe)
    this.http.post('https://localhost:7154/DadosBancarios/CadastrarDadosBancario', this.dadosBancarios)
      .subscribe((data: any) => {
          this.router.navigate(['cadastro-dados-bancarios']);
      });
  }



  submitFormularioTarefa(valorFormulario: any) {
    console.log(`valor do formulário: ${JSON.stringify(valorFormulario)}`);
    this.cadastrarDadosBancarios();
  }



}
