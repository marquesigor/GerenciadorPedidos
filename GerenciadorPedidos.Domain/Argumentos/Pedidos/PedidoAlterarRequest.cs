using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using System;

namespace GerenciadorPedidos.Domain.Argumentos.Pedidos
{
    public class PedidoAlterarRequest : IRequest
    {
        public Guid id { get; set; }
        public Guid clienteId { get; set; }
        public DateTime data { get; set; }
    }
}
