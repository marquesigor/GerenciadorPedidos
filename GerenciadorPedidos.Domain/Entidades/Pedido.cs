using System;
using GerenciadorPedidos.Domain.Entidades.Base;

namespace GerenciadorPedidos.Domain.Entidades
{
    public class Pedido : EntidadeBase
    {
        public Guid ClienteId { get;private set; }
        public Cliente Cliente { get;private set; }
        public DateTime Data { get;private set; }

        public void Incluir()
        {

        }
    }
}
