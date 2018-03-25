﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlacksComerce.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        
        public DateTime Data { get; set; }
        

        public Usuario Usuario{ get; set; }
        

        public ICollection<PedidoItem> PedidosItens { get; set; }

    }
}
