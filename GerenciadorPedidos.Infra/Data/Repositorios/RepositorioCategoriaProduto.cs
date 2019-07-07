using GerenciadorPedidos.Domain.Entidades;
using GerenciadorPedidos.Domain.Interfaces.Repositorios;
using GerenciadorPedidos.Infra.Data.Context;
using GerenciadorPedidos.Infra.Data.Repositorios.Base;
using System;

namespace GerenciadorPedidos.Infra.Data.Repositorios
{
    public class RepositorioCategoriaProduto : RepositoryBase<CategoriaProduto, Guid>, IRepositorioCategoriaProduto
    {
        protected readonly GerenciadorPedidosContext _context;

        public RepositorioCategoriaProduto(GerenciadorPedidosContext context) : base(context)
        {
            _context = context;
        }
    }
}
