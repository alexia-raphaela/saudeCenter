import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroHospitalComponent } from './cadastro-hospital.component';

describe('CadastroHospitalComponent', () => {
  let component: CadastroHospitalComponent;
  let fixture: ComponentFixture<CadastroHospitalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadastroHospitalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadastroHospitalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
