using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class PacienteService
    {
        private readonly ConectionManager _conexion;
        private readonly PacienteRepository _repositorio;
        public PacienteService (string connectionString){
           _conexion = new  ConectionManager(connectionString);
           _repositorio = new PacienteRepository (_conexion);
        }
        public GuardarPacienteResponse Guardar (Paciente paciente)
     {
        try {
            paciente.CalcularCopago();
            _conexion.Open();
            _repositorio.Guardar(paciente);
            _conexion.Close();
            return new GuardarPacienteResponse(paciente);

        }
        catch (Exception e){
          return new GuardarPacienteResponse($"error de la aplicacion: {e.Message}");
        }
        finally{_conexion.Close();}           
     }
     public class GuardarPacienteResponse{
                        public GuardarPacienteResponse(Paciente paciente)
                        {
                            Error = false;
                            Paciente = paciente;
                            }
                            public GuardarPacienteResponse(string mensaje){
                                Error = true;
                                Mensaje = mensaje;
                                 }
                public bool Error { get; set; }
                public string Mensaje { get; set; }
                public Paciente Paciente { get; set; }
            }
        public List<Paciente> ConsultarTodos()
        {
            _conexion.Open();
            List<Paciente> pacientes = _repositorio.ConsultarTodos();
            _conexion.Close();
            return pacientes;
        }
    }
     
}
