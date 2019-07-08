using GerenciadorPedidos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorPedidos.Infra.Data.Mapeamento
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasOne(x => x.Cliente).WithMany().HasForeignKey(item => item.ClienteId);
            builder.Property(item => item.Data).IsRequired();
            builder.Property(item => item.DataCriacao).IsRequired();
        }
    }
}
