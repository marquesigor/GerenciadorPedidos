using System;
using GerenciadorPedidos.Domain.Entidades.Base;

namespace GerenciadorPedidos.Domain.Entidades
{
    public class PedidoProduto : EntidadeBase
    {
        public Guid PedidoId { get;private set; }
        public Pedido Pedido { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }

        public void Incluir()
        {

        }
    }
}
