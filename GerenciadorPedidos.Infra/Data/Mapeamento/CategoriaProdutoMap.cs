using GerenciadorPedidos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorPedidos.Infra.Data.Mapeamento
{
    public class CategoriaProdutoMap : IEntityTypeConfiguration<CategoriaProduto>
    {
        public void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            builder.Property(item => item.Descricao).HasMaxLength(200).IsRequired();
            builder.Property(item => item.DataCriacao).IsRequired();
        }
    }
}
