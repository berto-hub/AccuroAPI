using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace APIAccuro.Models
{
    public class Empleado
    {
        public int Id {get; set;}

        public string Nombre {get; set;}=string.Empty;

        public string Apellido {get; set;}=string.Empty;

        public string Email {get; set;}=string.Empty;

        public int Telefono {get; set;}=0;

        public string Puesto {get; set;}=string.Empty;
    }
}