using Entity;

namespace APLICACIONSPA.Models
{
    public class PacienteInputModel
    {
        public string identificacion { get; set; }        
        public double valorServicio { get; set; }        
        public double salario { get; set; }       
         public double tarifa { get; set; } 
       

         
         }
       public class PacienteViewModel : PacienteInputModel
     {
        public PacienteViewModel()
        {

        }
        public PacienteViewModel(Paciente paciente)
        {
            identificacion = paciente.Identificacion;
            valorServicio = paciente.valorServicio;
            salario = paciente.salario;
            tarifa = paciente.tarifa;
            coPago = paciente.coPago;
        }
        public double coPago { get; set; }      
    }
    }
