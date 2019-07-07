using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using System;

namespace GerenciadorPedidos.Domain.Argumentos.Pedidos
{
    public class PedidoIncluirRequest : IRequest
    {
        public Guid clienteId { get; set; }
        public DateTime data { get; set; }
    }
}
