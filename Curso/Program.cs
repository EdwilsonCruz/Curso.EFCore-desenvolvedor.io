using CursoEFCore.Domain;
using CursoEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //InserirDados();
            //InserirDadosEmMassa();
            //ConsultarDados();
            //CadastrarPedido();
            //ConsultarPedidoListItens();
            AtualizaDados();
        }

        //inserindo dados
        private static void InserirDadosEmMassa()
        {
            var produto = new Produto
            {
                Descricao =    "Produto teste 2",
                CodigoBarras = "20211234567890",
                Valor = 10m,
                TipoProduto =  TipoProduto.MercadoriaParaRevenda,
                Ativo =        false
            };

            var cliente = new Cliente
            {
                Nome = "Ranger",
                CEP = "21555590",
                Cidade = "Rio de janeiro",
                Estado = "RJ",
                Telefone = "02122548978",
                Email = "ranger@gmail.com"
            };

            using var db = new Data.ApplicationContext();
            db.AddRange(produto, cliente);
            var registros = db.SaveChanges();
            Console.WriteLine($"Total de Registro(s): { registros }");
        }
        private static void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "Produto teste 1",
                CodigoBarras = "20211234567890",
                Valor = 5m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };
            using var db = new Data.ApplicationContext();
            db.Add(produto);
            var registro = db.SaveChanges();

            Console.WriteLine($"Registro: { registro }");
        }
        
        //consultando dados
        private static void ConsultarDados()
        {
            using var db = new Data.ApplicationContext();

            var consultaPorSintaxe = (from c in db.Cliente where c.Id > 0 select c).ToList();

            var consultaPorSintaxe2 = db.Cliente.Where(p => p.Id > 0).ToList();
        }
        private static void CadastrarPedido()
        {
            using var db = new Data.ApplicationContext();

            var cliente = db.Cliente.FirstOrDefault();
            var produto = db.Produtos.FirstOrDefault();

            var pedido = new Pedido
            {
                ClienteId = cliente.Id,
                IniciadoEm = DateTime.Now,
                FinalizadoEm = DateTime.Now,
                Observacao = "Pedido Teste 2",
                StatusPedido = StatusPedido.Analise,
                TipoFrete = TipoFrete.SemFrete,
                Itens = new List<PedidoItem>
                {
                    new PedidoItem
                    {
                        ProdutoId = produto.Id,
                        Desconto = 0,
                        Quantidade = 1,
                        Valor = 10
                    }
                }
            };

            db.Pedidos.Add(pedido);
            db.SaveChanges();
        }
    
        private static void ConsultarPedidoListItens()
        {
            using var db = new Data.ApplicationContext();
            var pedidos = db.Pedidos
                .Include(pedidos => pedidos.Itens)
                .ThenInclude(itens=>itens.Produto)
                .ToList();
            Console.WriteLine(pedidos.Count);
        }

        private static void AtualizaDados()
        {
            using var db = new Data.ApplicationContext();

            var cliente = db.Cliente.Find(1);
            //cliente.Nome = "Ciente atlerado 1";

            db.Cliente.Update(cliente);
            db.SaveChanges();
        }

        //deletar dados
        private static void RemoverRegistro()
        {
            using var db = new Data.ApplicationContext();
            var cliente = db.Cliente.Find(1);

            db.Cliente.Remove(cliente);
            db.SaveChanges();
        }
    }
}
