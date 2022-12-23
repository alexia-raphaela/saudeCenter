import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListagemHospitaisComponent } from './listagem-hospitais.component';

describe('ListagemHospitaisComponent', () => {
  let component: ListagemHospitaisComponent;
  let fixture: ComponentFixture<ListagemHospitaisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListagemHospitaisComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListagemHospitaisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
