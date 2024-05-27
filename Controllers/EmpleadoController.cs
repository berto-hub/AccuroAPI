using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAccuro.Data;
using APIAccuro.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace APIAccuro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly ILogger<EmpleadoController> _logger;
        private readonly DataContext _context;

        public EmpleadoController(ILogger<EmpleadoController> logger, DataContext context){
            _logger = logger;
            _context = context;
        }

//pag siendo la página en la que estamos y tamanio siendo el tamaño de cada página
        [HttpGet(Name = "GetEmpleados")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados(string nombre = "", int pag = 1, int tamanio = 10){
            var total = _context.Empleados.Count();
            var paginas = (int)Math.Ceiling((decimal)total / tamanio);
            List<Empleado> empleados = new List<Empleado>();

            try{
                if(nombre == null){
                    empleados = await _context.Empleados.ToListAsync();
                }else{
                    empleados = await _context.Empleados.Where(x => x.Nombre.Contains(nombre)).ToListAsync();
                }

                empleados = empleados.Skip((pag-1) * tamanio).Take(tamanio).ToList();
                
                return Ok(empleados);
            }catch{
                return BadRequest("Error");
            }
        }

        [HttpGet("{id}", Name = "GetEmpleadoId")]
        public async Task<ActionResult<Empleado>> GetEmpleadoById(int id){
            var empleado = await _context.Empleados.FindAsync(id);
            
            if(empleado == null){
                return NotFound();
            }

            return empleado;
        }

        [HttpPost]      
        public async Task<ActionResult<Empleado>> PostEmpleados(Empleado empleado){
            _context.Add(empleado);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetEmpleadoId", new {id = empleado.Id}, empleado);
        }
        
    }
}