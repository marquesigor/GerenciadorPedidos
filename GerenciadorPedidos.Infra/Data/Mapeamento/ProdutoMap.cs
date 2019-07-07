using GerenciadorPedidos.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorPedidos.Infra.Data.Mapeamento
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");
            HasRequired(item => item.CategoriaProduto).WithMany().HasForeignKey(fk => fk.CategoriaProdutoId).WillCascadeOnDelete(false);
            Property(item => item.Descricao).HasMaxLength(200).IsRequired();
            Property(item => item.ValorVenda).IsRequired().HasPrecision(18, 6);
            Property(item => item.Quantidade).IsRequired();
        }
    }
}
