using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly PRUEBA_ANARContext _context;
        private readonly ILogger<HomeController> _logger;


        public HomeController(PRUEBA_ANARContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// CONSULT
        /// </summary>
        /// <returns></returns>
        [HttpGet("Consult")]
        public List<Paciente> consultarPacientes()
        {
            var pacientes = _context.Pacientes.ToList();

            return pacientes;
        }

        /// <summary>
        /// ADD
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public bool pacienteNuevo(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// EDIT
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPut("Edit")]
        public bool editarPaciente(Paciente paciente)
        {
            var pac = _context.Pacientes.Where(p => p.Id == paciente.Id).FirstOrDefault();
            pac.NumeroIdentificacion=paciente.NumeroIdentificacion;
            pac.TipoIdentificacion = paciente.TipoIdentificacion;
            pac.CodigoPostal = paciente.CodigoPostal;
            pac.Correo = paciente.Correo;
            pac.Direccion = paciente.Direccion;
            pac.PrimerNombre = paciente.PrimerNombre;
            pac.PrimerApellido = paciente.PrimerApellido;
            pac.SegundoApellido = paciente.SegundoApellido;
            pac.SegundoNombre = paciente.SegundoNombre;
            pac.Telefono = paciente.Telefono;
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="idPaciente"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{idPaciente}")]
        public bool eliminarPaciente(int idPaciente)
        {
            var paciente = _context.Pacientes.Where(p => p.Id == idPaciente).FirstOrDefault();
            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();
            return true;
        }
    }
}
