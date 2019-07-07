using GerenciadorPedidos.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorPedidos.Infra.Data.Mapeamento
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Cliente");
            Property(item => item.Email.EnderecoEletronico).HasMaxLength(200).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UK_Cliente_EMAIL") { IsUnique = true })).HasColumnName("Email");
            Property(item => item.Nome.PrimeiroNome).HasMaxLength(50).IsRequired();
            Property(item => item.Nome.UltimoNome).HasMaxLength(100).IsRequired();
            Property(item => item.Telefone).HasMaxLength(20).IsRequired();
            Property(item => item.Endereco).HasMaxLength(200).IsRequired();
            Property(item => item.DataCriacao).IsRequired();
        }
    }
}
