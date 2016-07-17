using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNetCore.Controllers
{
    public class ClienteController : Controller
    {
        private Seed seed;

        public ClienteController()
        {
            if(this.seed == null)
                this.seed = new Seed();
        }

        [Route("Cliente")]
        public IActionResult Index()
        {
            using (ContextEF _db = new ContextEF(seed.GetOptions))
            {
                return View(_db.Cliente.Include(x => x.Cidade).ToList());
            }
        }

        public IActionResult Adicionar()
        {
            Domain.Cliente model = new Domain.Cliente();

            using (ContextEF _db = new ContextEF(seed.GetOptions))
            {
                model.Estados = _db.Estado.Select(x=> new SelectListItem() { Value =  x.Id.ToString(), Text = x.Nome}).ToList();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Adicionar(Domain.Cliente model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (ContextEF _db = new ContextEF(seed.GetOptions))
            {
                model.Cidade = _db.Cidade.Single(x=> x.Id == model.Cidade_id);
                _db.Cliente.Add(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        [Route("ObtemCidadesPorEstado/{id}")]
        public JsonResult ObtemCidadesPorEstado(int id)
        {
            using (ContextEF _db = new ContextEF(seed.GetOptions))
            {
                var model = _db.Cidade.Where(x => x.Estado_id == id).Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nome.ToString() }).ToList();
                return Json(model);
            }
        }
    }
}
