using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Context
{
    public class Seed
    {
        private DbContextOptionsBuilder<ContextEF> optionsBuider;

        public Seed()
        {
            optionsBuider = new DbContextOptionsBuilder<ContextEF>();
            optionsBuider.UseInMemoryDatabase();
            this.Init(new ContextEF(optionsBuider.Options));
        }

        public DbContextOptions<ContextEF> GetOptions
        {
            get
            {
                return optionsBuider.Options;
            }
        }

        public void Init(ContextEF context)
        {
            if (context.Estado.Count() > 0)
                return;

            optionsBuider.UseInMemoryDatabase();

            context.Estado.Add(new Domain.Estado() { Id = 1, Nome = "SP" });
            context.Estado.Add(new Domain.Estado() { Id = 2, Nome = "RJ" });
            context.Estado.Add(new Domain.Estado() { Id = 3, Nome = "MG" });
            context.SaveChanges();

            context.Cidade.Add(new Domain.Cidade() { Id = 1, Nome = "SÂO PAULO", Estado_id = 1 });
            context.Cidade.Add(new Domain.Cidade() { Id = 2, Nome = "PARATI", Estado_id = 2 });
            context.Cidade.Add(new Domain.Cidade() { Id = 3, Nome = "MONTE VERDE", Estado_id = 3 });
            context.SaveChanges();
        }
    }
}
