using System.Data.Common;
using System.Data;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class PacienteRepository
    {
           private readonly SqlConnection _connection;
           private readonly List<Paciente> _pacientes = new List<Paciente>();

           public PacienteRepository(ConectionManager connection)
          {
             _connection= connection._conexion;

           } 
                 public void Guardar(Paciente paciente)
          {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Paciente (Identificacion,ValorServicio,Salario, tarifa, Copago)
                 values (@Identificacion,@ValorServicio,@Salario,@Tarifa,@CoPago)";       
                 command.Parameters.AddWithValue("@Identificacion", paciente.Identificacion);      
                 command.Parameters.AddWithValue("@ValorServicio", paciente.valorServicio);        
                 command.Parameters.AddWithValue("@Salario", paciente.salario);     
                 command.Parameters.AddWithValue("@Tarifa", paciente.tarifa);      
                 command.Parameters.AddWithValue("@CoPago", paciente.coPago);         
                 var filas = command.ExecuteNonQuery();
            }
        }
         public List<Paciente> ConsultarTodos()  {            
             SqlDataReader dataReader; 
                    List<Paciente> pacientes = new List<Paciente>();           
                     using (var command = _connection.CreateCommand())           
                      {command.CommandText = "Select * from paciente ";    
                     dataReader = command.ExecuteReader();        
                             if (dataReader.HasRows) {          
                              while (dataReader.Read())   
                              {Paciente paciente = DataReaderMapToPerson(dataReader);    
                               pacientes.Add(paciente); 
                            }               
                         }           
                     }            
                     
                return pacientes;     
           }

           public Paciente BuscarPorIdentificacion(string identificacion){   
                SqlDataReader dataReader;           
                 using (var command = _connection.CreateCommand()){
                       command.CommandText = "select * from paciente where Identificacion=@Identificacion";
                 command.Parameters.AddWithValue("@Identificacion", identificacion);       
                 dataReader = command.ExecuteReader();   
                 dataReader.Read();         
                 return DataReaderMapToPerson(dataReader);           
                  }       
           } 

           private Paciente DataReaderMapToPerson(SqlDataReader dataReader) {
            if(!dataReader.HasRows) return null;
            Paciente paciente = new Paciente();  
             paciente.Identificacion = (string)dataReader["Identificacion"];
             paciente.valorServicio = (double)dataReader["ValorServicio"]; 
             paciente.salario = (double)dataReader["Salario"];
             paciente.tarifa = (double)dataReader["Tarifa"];            
             paciente.coPago = (double)dataReader["CoPago"];            
             return paciente;
             }

    }
}
