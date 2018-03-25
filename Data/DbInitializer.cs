using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlacksComerce.Data;
using BlacksComerce.Models;

namespace BlacksComerce.Data
{
    public class DbInitializer
    {
        public static int ProdutoId { get; private set; }

        public static void Initialize(BlackContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Produtos.Any())
            {
                return;   // DB has been seeded
            }

            //simulando um usuario ja cadastrado
            var usuario = new Usuario
            { Nome = "Fabio", Cpf = "123456", Email = "test@com.br"};
            context.Usuarios.Add(usuario);
            context.SaveChanges();


            var Produto1 = new Produto { Nome = "Produtop1", PrecoUnitario = 1000 };
            var Produto2 = new Produto { Nome = "Produtop2", PrecoUnitario = 2000 };
            var Produto3 = new Produto { Nome = "Produtop3", PrecoUnitario = 3000 };
            var produtos = new[] { Produto1, Produto2, Produto3 };
            context.Produtos.AddRange(produtos);
            context.SaveChanges();

            var Pedido = new Pedido { UsuarioId = usuario.Id, Data = DateTime.Now };
            context.Pedidos.Add(Pedido);
            context.SaveChanges();

            var produtosComprados = new List<Produto> { Produto1, Produto3 };

            //salvando cada item de pedido
            foreach (var prod in produtosComprados)
            {
                var pedidoItem = new PedidoItem { PedidoId = Pedido.Id, ProdutoId = ProdutoId = prod.Id };
                context.PedidosItens.Add(pedidoItem);
                context.SaveChanges();
            }
        }
    }
}
