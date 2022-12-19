import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TelaBeneficiarioComponent } from './tela-beneficiario/tela-beneficiario.component';

@NgModule({
  declarations: [
    AppComponent,
    TelaBeneficiarioComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
