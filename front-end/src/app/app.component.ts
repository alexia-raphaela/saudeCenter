import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'saudeCenter';
  constructor(private router: Router) {

  }
  ngOnInit() {
  }
  goToCadastro(){
    this.router.navigate(['/', 'cadastro']);
  }

  goToAgendamento(){
    this.router.navigate(['/', 'agendamento']);
  }

}
