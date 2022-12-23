import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListagemMedicosComponent } from './listagem-medicos.component';

describe('ListagemMedicosComponent', () => {
  let component: ListagemMedicosComponent;
  let fixture: ComponentFixture<ListagemMedicosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListagemMedicosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListagemMedicosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
