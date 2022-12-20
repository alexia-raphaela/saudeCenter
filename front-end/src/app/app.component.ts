import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'saudeCenter';
  constructor(private router: Router) {

  }
  goToCadastro(){
    this.router.navigate(['/', 'casdastro']);
  }

  goToAgendamento(){
    this.router.navigate(['/', 'agendamento']);
  }

}
