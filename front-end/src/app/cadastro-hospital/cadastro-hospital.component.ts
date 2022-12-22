import { IHospitalDto } from './../interfaces/IHospitalDto';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-cadastro-hospital',
  templateUrl: './cadastro-hospital.component.html',
  styleUrls: ['./cadastro-hospital.component.css']
})
export class CadastroHospitalComponent {
  hospital!: IHospitalDto;
  idRecebido!: number;

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.route.paramMap.subscribe(params => {
      this.idRecebido = Number(params.get('id'));
    });
  }

  ngOnInit(): void {
    this.hospital = {
      nome: '',
      cnpj: '',
      endereco: '',
      telefone: '',
      cnes: '',
      ativo:true,
    }
  }

  cadastrarHospital() {
    //implementar o objeto na api, chamar a api(subcribe)
    this.http.post('https://localhost:7154/api/Hospital/CadastrarHospital', this.hospital)
      .subscribe((data: any) => {
          this.router.navigate(['hospital']);
      });
  }

  submitFormulario(valorFormulario: any) {
    console.log(`valor do formulário: ${JSON.stringify(valorFormulario)}`);
    this.cadastrarHospital();
  }

}
