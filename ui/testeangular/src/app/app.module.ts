import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FilmeComponent } from './filme/filme.component';
import { ListarFilmesComponent } from './filme/listar-filmes/listar-filmes.component';
import { IncluirFilmeComponent } from './filme/incluir-filme/incluir-filme.component';
import { EditarFilmeComponent } from './filme/editar-filme/editar-filme.component';
import{ SharedService } from './shared.service';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms'

@NgModule({
  declarations: [
    AppComponent,
    FilmeComponent,
    ListarFilmesComponent,
    IncluirFilmeComponent,
    EditarFilmeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
