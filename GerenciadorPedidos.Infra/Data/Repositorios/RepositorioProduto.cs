using GerenciadorPedidos.Domain.Entidades;
using GerenciadorPedidos.Domain.Interfaces.Repositorios;
using GerenciadorPedidos.Infra.Data.Context;
using GerenciadorPedidos.Infra.Data.Repositorios.Base;
using System;

namespace GerenciadorProdutos.Infra.Data.Repositorios
{
    public class RepositorioProduto : RepositoryBase<Produto, Guid>, IRepositorioProduto
    {
        protected readonly GerenciadorPedidosContext _context;

        public RepositorioProduto(GerenciadorPedidosContext context) : base(context)
        {
            _context = context;
        }
    }
}
