using System.Collections.Generic;
using System.Linq;
using APLICACIONSPA.Models;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace APLICACIONSPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PacienteController : ControllerBase
    {
         private readonly PacienteService _pacienteService;
        public IConfiguration Configuration { get; }
        public PacienteController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _pacienteService = new PacienteService(connectionString);
        }

        
        [HttpGet]
        public IEnumerable<PacienteViewModel> Gets()
        {
            var pacientes= _pacienteService.ConsultarTodos().Select(p=> new PacienteViewModel(p));
            return pacientes;
        }

        [HttpPost]
        public ActionResult<PacienteViewModel> Post(PacienteInputModel pacienteInput)
        {
            Paciente paciente = DataReaderMapToPerson(pacienteInput);
            var response = _pacienteService.Guardar(paciente);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Paciente);
        }

          private Paciente DataReaderMapToPerson(PacienteInputModel pacienteInput)
        {
            var paciente = new Paciente
            {
                Identificacion = pacienteInput.identificacion,
                valorServicio = pacienteInput.valorServicio,
                salario = pacienteInput.salario,
                tarifa = pacienteInput.tarifa
                
            };
            return paciente;
        }



    }
}