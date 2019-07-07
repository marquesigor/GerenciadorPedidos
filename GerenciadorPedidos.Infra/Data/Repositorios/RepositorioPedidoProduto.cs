using GerenciadorPedidos.Domain.Entidades;
using GerenciadorPedidos.Domain.Interfaces.Repositorios;
using GerenciadorPedidos.Infra.Data.Context;
using GerenciadorPedidos.Infra.Data.Repositorios.Base;
using System;

namespace GerenciadorPedidoProdutos.Infra.Data.Repositorios
{
    public class RepositorioPedidoProduto : RepositoryBase<PedidoProduto, Guid>, IRepositorioPedidoProduto
    {
        protected readonly GerenciadorPedidosContext _context;

        public RepositorioPedidoProduto(GerenciadorPedidosContext context) : base(context)
        {
            _context = context;
        }
    }
}
