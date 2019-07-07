using GerenciadorPedidos.Domain.Entidades;
using GerenciadorPedidos.Domain.Interfaces.Repositorios.Base;
using System;

namespace GerenciadorPedidos.Domain.Interfaces.Repositorios
{
    public interface IRepositorioPedido : IRepositoryBase<Pedido, Guid>   {    }
}
