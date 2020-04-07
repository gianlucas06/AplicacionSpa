export class Paciente {
    identificacion: string;
    valorServicio: number;
    salario: number;
    tarifa: number;
    coPago: number;
    CalcularCopago(): void {
if(this.salario>2500000){
    this.tarifa= 0.20;
    this.coPago = this.tarifa*this.valorServicio;

}else{
    this.tarifa= 0.10;
    this.coPago= this.tarifa*this.valorServicio;
}
   }
}

