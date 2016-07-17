using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Cidade
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Estado_id { get; set; }

        public Estado Estado { get; set; }
    }
}
