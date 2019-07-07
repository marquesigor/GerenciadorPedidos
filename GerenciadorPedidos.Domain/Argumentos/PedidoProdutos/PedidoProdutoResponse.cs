using GerenciadorPedidos.Domain.Entidades;
using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using System;

namespace GerenciadorPedidos.Domain.Argumentos.PedidoProdutos
{
    public class PedidoProdutoResponse : IResponse
    {
        public Guid id { get; set; }
        public Guid pedidoId { get; set; }
        public Pedido pedido { get; set; }
        public Guid produtoId { get; set; }
        public Produto produto { get; set; }
        public int quantidade { get; set; }

        public static explicit operator PedidoProdutoResponse(PedidoProduto model)
        {
            return new PedidoProdutoResponse()
            {
                id = model.Id,
                pedidoId = model.PedidoId,
                pedido = model.Pedido,
                produto = model.Produto,
                produtoId = model.ProdutoId,
                quantidade = model.Quantidade
            };
        }
    }
}
