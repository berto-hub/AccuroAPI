using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAccuro.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAccuro.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) {}

        public DbSet<Empleado> Empleados { get; set; }
    }
}