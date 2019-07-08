using GerenciadorPedidos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorPedidos.Infra.Data.Mapeamento
{
    public class PedidoProdutoMap : IEntityTypeConfiguration<PedidoProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoProduto> builder)
        {
            builder.HasOne(x => x.Pedido).WithMany().HasForeignKey(item => item.PedidoId);
            builder.HasOne(x => x.Produto).WithMany().HasForeignKey(item => item.ProdutoId);
            builder.Property(item => item.Quantidade).IsRequired();
            builder.Property(item => item.DataCriacao).IsRequired();
        }
    }
}
