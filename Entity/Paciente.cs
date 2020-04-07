using System;

namespace Entity
{
 public class Paciente
 {
 public string Identificacion { get; set; }
 public double valorServicio { get; set; }
 public double salario { get; set; }
 public double tarifa { get; set; }
 public double coPago { get; set; }
public void CalcularCopago(){
            if(salario>2500000){
                tarifa= 0.20;
                coPago=tarifa*valorServicio;
            }else{
                if(salario<=2500000){
                    tarifa=0.10;
                    coPago=tarifa*valorServicio;
                }
            }
        }
 }
}
