import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PacienteConsultaComponent } from './liquidacion/paciente-consulta/paciente-consulta.component';
import { PacienteRegistroComponent } from './liquidacion/paciente-registro/paciente-registro.component';


const routes: Routes = [

  {
  path: 'pacienteConsulta', 
  component: PacienteConsultaComponent
  },
  {
  path: 'pacienteRegistro',
  component: PacienteRegistroComponent
  
  }
  ];
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
