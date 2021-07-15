using CursoEFCore.Data.Mapping;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace CursoEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());
        public  DbSet<Cliente> Cliente { get; set; }
        public  DbSet<Pedido> Pedidos { get; set; }
        public  DbSet<Produto> Produtos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()
                .UseSqlServer("Server=.\\SQLEXPRESS;Database=CursoEFCore; UID=sa; PWD=sa123456; MultipleActiveResultSets=true;",
                p=>p.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null )
                .MigrationsHistoryTable(Data.Constantes.Constantes.Tabelas.CursoEFCore, Data.Constantes.Constantes.Schemas.Migracao));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new PedidoMapping());
            modelBuilder.ApplyConfiguration(new PedidoItemMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            //mapeando as propriedades que não foram configuradas, caso tenho este esquecimento automaticamente o modelbuilder vai
            //criar para os tipos string uma configuração padrao varchar(255).
            MapearPropriedades(modelBuilder);
        }

        private void MapearPropriedades(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var prop in properties)
                {
                    if (string.IsNullOrEmpty(prop.GetColumnType()) && !prop.GetMaxLength().HasValue )
                        prop.SetColumnType("VARCHAR(255)");
                }
            }
        }
    }
}
