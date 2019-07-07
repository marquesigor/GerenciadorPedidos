using GerenciadorPedidos.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorPedidos.Infra.Data.Mapeamento
{
    public class CategoriaProdutoMap : EntityTypeConfiguration<CategoriaProduto>
    {
        public CategoriaProdutoMap()
        {
            ToTable("CategoriaProduto");
            Property(item => item.DataCriacao).IsRequired();
            Property(item => item.Descricao).IsRequired();
        }
    }
}
