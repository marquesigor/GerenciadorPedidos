using System;
using System.Collections.Generic;
using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using GerenciadorPedidos.Domain.Interfaces.Servicos;

namespace GerenciadorPedidos.Domain.Services
{
    public class ServicoCategoriaProduto : IServicoCategoriaProduto
    {
        public IResponse Adicionar(IRequest request)
        {
            throw new NotImplementedException();
        }

        public IResponse Alterar(IRequest request)
        {
            throw new NotImplementedException();
        }

        public IResponse Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IResponse> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
