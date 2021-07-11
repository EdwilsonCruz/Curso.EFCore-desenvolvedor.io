using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable(Constantes.Constantes.Tabelas.Produto, Constantes.Constantes.Schemas.Sistema);

            builder.HasKey(produto => produto.Id);
            
            builder.Property(produto => produto.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(produto => produto.Descricao).HasColumnType("VARCHAR(255)");
            builder.Property(produto => produto.Valor).IsRequired();
            builder.Property(produto => produto.TipoProduto).HasConversion<string>();
        }
    }
}
