using System;
using GerenciadorPedidos.Domain.Argumentos.Pedidos;
using GerenciadorPedidos.Domain.Entidades.Base;
using GerenciadorPedidos.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace GerenciadorPedidos.Domain.Entidades
{
    public class Pedido : EntidadeBase
    {
        public Pedido() { }
        public Pedido(PedidoIncluirRequest request)
        {
            ClienteId = request.clienteId;
            Data = request.data;

            new AddNotifications<Pedido>(this).IfNotGuid(item => item.ClienteId.ToString(), Message.X0_INVALIDO.ToFormat("Cliente"));
        }

        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
        public DateTime Data { get; private set; }

        public void Alterar(PedidoAlterarRequest request)
        {
            Id = request.id;
            ClienteId = request.clienteId;
            Data = request.data;

            new AddNotifications<Pedido>(this).IfNotGuid(item => item.ClienteId.ToString(), Message.X0_INVALIDO.ToFormat("Cliente"));
        }
    }
}
