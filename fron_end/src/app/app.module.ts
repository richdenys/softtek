import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from './plantillas/header/header.component';
import { FooterComponent } from './plantillas/footer/footer.component';
import { routingComponents } from './app-routing.module';
// import { LoginComponent } from './Vistas/login/login.component';
// import { DashboardComponent } from './Vistas/dashboard/dashboard.component';
// import { NuevoComponent } from './Vistas/nuevo/nuevo.component';
// import { EditarComponent } from './Vistas/editar/editar.component';
 import { AppRoutingModule } from './app-routing.module';

 import {ReactiveFormsModule,FormsModule} from '@angular/forms'
import {HttpClientModule} from '@angular/common/http'

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    routingComponents
    // LoginComponent,
    // DashboardComponent,
    // NuevoComponent,
    // EditarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
