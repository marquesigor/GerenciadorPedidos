using prmToolkit.NotificationPattern;
using System;

namespace GerenciadorPedidos.Domain.Entidades.Base
{
    public abstract class EntidadeBase : Notifiable
    {
        public EntidadeBase()
        {
            Id = new Guid();
            DataCriacao = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}
