using GerenciadorPedidos.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorPedidos.Infra.Data.Mapeamento
{
    public class PedidoProdutoMap : EntityTypeConfiguration<PedidoProduto>
    {
        public PedidoProdutoMap()
        {
            ToTable("PedidoProduto");
            HasRequired(item => item.Pedido).WithMany().HasForeignKey(fk => fk.PedidoId).WillCascadeOnDelete(false);
            HasRequired(item => item.Produto).WithMany().HasForeignKey(fk => fk.ProdutoId).WillCascadeOnDelete(false);
            Property(item => item.Quantidade).IsRequired();
            Property(item => item.DataCriacao).IsRequired();
        }
    }
}
