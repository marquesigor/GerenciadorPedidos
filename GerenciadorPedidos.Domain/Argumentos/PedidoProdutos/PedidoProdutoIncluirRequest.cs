using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using System;

namespace GerenciadorPedidos.Domain.Argumentos.PedidoProdutos
{
    public class PedidoProdutoIncluirRequest : IRequest
    {
        public Guid pedidoId { get; set; }
        public Guid produtoId { get; set; }
        public int quantidade { get; set; }
    }
}
