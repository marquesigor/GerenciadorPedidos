using GerenciadorPedidos.Domain.Entidades;
using GerenciadorPedidos.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorPedidos.Infra.Data.Mapeamento
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.OwnsOne<Nome>(x => x.Nome, cb => {
                cb.Property(x => x.PrimeiroNome).HasMaxLength(50).HasColumnName("PrimeiroNome").IsRequired();
                cb.Property(x => x.UltimoNome).HasMaxLength(50).HasColumnName("UltimoNome").IsRequired();
            });

            builder.OwnsOne<Email>(x => x.Email, cb => {
                cb.Property(x => x.EnderecoEletronico).HasMaxLength(200).HasColumnName("Email").IsRequired();
            });
            builder.Property(item => item.Telefone).HasMaxLength(20).IsRequired();
            builder.Property(item => item.Endereco).HasMaxLength(200).IsRequired();
            builder.Property(item => item.DataCriacao).IsRequired();
        }
    }
}
