using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Context
{
    public class ContextEF : DbContext
    {
        public ContextEF(DbContextOptions options) : base(options)
        {          
        }

        public DbSet<Estado> Estado { get; set; }

        public DbSet<Cidade> Cidade { get; set; }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
