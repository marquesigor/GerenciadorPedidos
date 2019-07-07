using GerenciadorPedidos.Domain.Entidades;
using GerenciadorPedidos.Domain.Interfaces.Repositorios;
using GerenciadorPedidos.Infra.Data.Context;
using GerenciadorPedidos.Infra.Data.Repositorios.Base;
using System;

namespace GerenciadorPedidos.Infra.Data.Repositorios
{
    public class RepositorioPedido : RepositoryBase<Pedido, Guid>, IRepositorioPedido
    {
        protected readonly GerenciadorPedidosContext _context;

        public RepositorioPedido(GerenciadorPedidosContext context) : base(context)
        {
            _context = context;
        }
    }
}
