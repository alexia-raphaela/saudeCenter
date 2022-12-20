import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TelaBeneficiarioComponent } from './tela-beneficiario.component';

describe('TelaBeneficiarioComponent', () => {
  let component: TelaBeneficiarioComponent;
  let fixture: ComponentFixture<TelaBeneficiarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TelaBeneficiarioComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TelaBeneficiarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
