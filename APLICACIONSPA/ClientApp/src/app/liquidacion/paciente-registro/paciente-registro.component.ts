import { Component, OnInit } from '@angular/core';
import { PacienteService } from 'src/app/services/paciente.service';
import { Paciente } from '../models/paciente';

@Component({
  selector: 'app-paciente-registro',
  templateUrl: './paciente-registro.component.html',
  styleUrls: ['./paciente-registro.component.css']
})
export class PacienteRegistroComponent implements OnInit {

  paciente: Paciente;
 constructor(private pacienteService: PacienteService) { }

 ngOnInit() {
  this.paciente= new Paciente();
  }
  add() {
  
  alert('la liquidacion a sido resgistrada correctamente'+ JSON.stringify(this.paciente));
  
  }
  }
 