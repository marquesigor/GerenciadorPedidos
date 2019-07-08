using GerenciadorPedidos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorPedidos.Infra.Data.Mapeamento
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasOne(x => x.CategoriaProduto).WithMany().HasForeignKey(item => item.CategoriaProdutoId);
            builder.Property(item => item.Descricao).HasMaxLength(200).IsRequired();
            builder.Property(item => item.ValorVenda).IsRequired();
            builder.Property(item => item.Quantidade).IsRequired();
        }
    }
}
