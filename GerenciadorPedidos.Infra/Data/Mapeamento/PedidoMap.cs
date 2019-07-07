using GerenciadorPedidos.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorPedidos.Infra.Data.Mapeamento
{
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            ToTable("Pedido");
            HasRequired(item => item.Cliente).WithMany().HasForeignKey(fk => fk.ClienteId).WillCascadeOnDelete(false);
            Property(item => item.Data).IsRequired();
            Property(item => item.DataCriacao).IsRequired();
        }
    }
}
