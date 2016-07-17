using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Domain
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public Cidade Cidade { get; set; }

        public int Cidade_id { get; set; }

        [NotMapped]
        public IList<SelectListItem> Estados { get; set; }

        [NotMapped]
        public IList<SelectListItem> Cidades { get; set; }
    }
}
