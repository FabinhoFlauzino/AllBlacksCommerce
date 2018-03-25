using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlacksComerce.Models
{
    public class Produto
    {
        public int Id { get; set; }
        
        public decimal PrecoUnitario { get; set; }
        public string Nome { get; set; }

        
    }
}
