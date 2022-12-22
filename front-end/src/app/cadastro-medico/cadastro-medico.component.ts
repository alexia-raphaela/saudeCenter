import { HttpClient } from "@angular/common/http";

import { Component } from "@angular/core";

import { ActivatedRoute, Router } from "@angular/router";

import { IProfissionalDto} from "../interfaces/IProfissionalDto";



@Component({

  selector: 'app-cadastro-medico',

  templateUrl: './cadastro-medico.component.html',

  styleUrls: ['./cadastro-medico.component.css']

})



export class CadastroMedicoComponent {

    profissional!: IProfissionalDto;

    idRecebido!: number;


    constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {

      this.route.paramMap.subscribe(params => {

        this.idRecebido = Number(params.get('id'));

      });

    }



    //REST_API_SERVER = "https://localhost:7154/swagger/index.html";




    ngOnInit(): void {

      this.profissional = {

        nome: '',

        endereco: '',

        telefone: '',

        ativo:true,

      }

    }



    cadastrarProfissional() {

      //implementar o objeto na api, chamar a api(subcribe)

      this.http.post('https://localhost:7154/Profissional/CadastrarProfissional', this.profissional)

        .subscribe((data: any) => {

            this.router.navigate(['cadastro-medico']);

        });

    }



    submitFormulario(valorFormulario: any) {

      console.log(`valor do formulário: ${JSON.stringify(valorFormulario)}`);

      this.cadastrarProfissional();

    }

}

