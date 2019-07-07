using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using System;

namespace GerenciadorPedidos.Domain.Argumentos.PedidoProdutos
{
    public class PedidoProdutoAlterarRequest : IRequest
    {
        public Guid id { get; set; }
        public Guid pedidoId { get; set; }
        public Guid produtoId { get; set; }
        public int quantidade { get; set; }
    }
}
