using GerenciadorPedidos.Domain.Entidades;
using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using System;

namespace GerenciadorPedidos.Domain.Argumentos.Pedidos
{
    public class PedidoResponse : IResponse
    {
        public Guid id { get; set; }
        public Guid clienteId { get; set; }
        public Cliente cliente { get; set; }
        public DateTime data { get; set; }

        public static explicit operator PedidoResponse(Pedido model)
        {
            return new PedidoResponse()
            {
                id = model.Id,
                clienteId = model.ClienteId,
                cliente = model.Cliente,
                data = model.Data
            };
        }
    }
}
