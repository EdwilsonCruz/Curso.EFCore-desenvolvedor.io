using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Mapping
{
    public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable(Constantes.Constantes.Tabelas.PedidoItem, Constantes.Constantes.Schemas.Sistema);

            builder.HasKey(pedidoItem => pedidoItem.Id);

            builder.Property(pedidoItem => pedidoItem.Quantidade).HasDefaultValue(1).IsRequired();
            builder.Property(pedidoItem => pedidoItem.Valor).IsRequired();
            builder.Property(pedidoItem => pedidoItem.Desconto).IsRequired();
        }
    }
}
