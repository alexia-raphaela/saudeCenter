import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'saudeCenter';

  constructor(private router: Router) {}

  ngOnInit(): void {
  }

  goToHome(){
    this.router.navigate(['/home'])
  }

  goToCadastro(){
    this.router.navigate(['/cadastro']);
  }

  goToCadastroMedicos(){
    this.router.navigate(['/cadastro-medico'])
  }

  goToCadastroHospitais(){
    this.router.navigate(['/cadastro-hospital'])
  }

  goToCadastroEspecialidades(){
    this.router.navigate(['/cadastro-especialidade'])
  }

  goToAgendamento(){
    this.router.navigate(['/agendamento']);
  }

}
