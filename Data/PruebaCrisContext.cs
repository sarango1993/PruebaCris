using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PruebaCris.Models
{
    public class PruebaCrisContext : DbContext
    {
        public PruebaCrisContext (DbContextOptions<PruebaCrisContext> options)
            : base(options)
        {
        }

        public DbSet<PruebaCris.Models.factura> factura { get; set; }
    }
}
