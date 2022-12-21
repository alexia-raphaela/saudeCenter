import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroEspecialidadeComponent } from './cadastro-especialidade.component';

describe('CadastroEspecialidadeComponent', () => {
  let component: CadastroEspecialidadeComponent;
  let fixture: ComponentFixture<CadastroEspecialidadeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadastroEspecialidadeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadastroEspecialidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
