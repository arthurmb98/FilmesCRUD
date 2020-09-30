import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {FilmeComponent} from './filme/filme.component';

const routes: Routes = [
  {path:'filme',component:FilmeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
