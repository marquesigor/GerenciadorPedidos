using GerenciadorPedidos.Domain.Argumentos.PedidoProdutos;
using GerenciadorPedidos.Domain.Entidades.Base;
using GerenciadorPedidos.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace GerenciadorPedidos.Domain.Entidades
{
    public class PedidoProduto : EntidadeBase
    {
        public PedidoProduto(PedidoProdutoIncluirRequest request)
        {
            PedidoId = request.pedidoId;
            ProdutoId = request.produtoId;
            Quantidade = request.quantidade;

            new AddNotifications<PedidoProduto>(this).IfNotGuid(item => item.PedidoId.ToString(), Message.X0_INVALIDO.ToFormat("Pedido"));
            new AddNotifications<PedidoProduto>(this).IfNotGuid(item => item.ProdutoId.ToString(), Message.X0_INVALIDO.ToFormat("Produto"));
            new AddNotifications<PedidoProduto>(this).IfTrue(item => item.Quantidade <= 0, Message.EH_NECESSARIO_INFORMAR_UM_X0.ToFormat("Produto"));
        }

        public Guid PedidoId { get;private set; }
        public Pedido Pedido { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }

        public void Alterar(PedidoProdutoAlterarRequest request)
        {
            Id = request.id;
            PedidoId = request.pedidoId;
            ProdutoId = request.produtoId;
            Quantidade = request.quantidade;

            new AddNotifications<PedidoProduto>(this).IfNotGuid(item => item.PedidoId.ToString(), Message.X0_INVALIDO.ToFormat("Pedido"));
            new AddNotifications<PedidoProduto>(this).IfNotGuid(item => item.ProdutoId.ToString(), Message.X0_INVALIDO.ToFormat("Produto"));
            new AddNotifications<PedidoProduto>(this).IfTrue(item => item.Quantidade <= 0, Message.EH_NECESSARIO_INFORMAR_UM_X0.ToFormat("Produto"));
        }
    }
}
