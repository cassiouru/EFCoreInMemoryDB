using Domain;
using Domain.Context;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.ViewComponents
{
    public class ListarClienteViewComponent : ViewComponent
    {
        private Seed seed;

        public ListarClienteViewComponent()
        {
            if (this.seed == null)
                this.seed = new Seed();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clientes = new List<Cliente>();
            using (ContextEF _db = new ContextEF(seed.GetOptions))
            {
                await Task.Run(delegate() {
                    clientes = _db.Cliente.ToList();
                });

                return View(clientes);
            }
        }
    }
}
