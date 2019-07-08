using GerenciadorPedidos.Domain.Argumentos.CategoriasProduto;
using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using GerenciadorPedidos.Domain.Interfaces.Repositorios;
using GerenciadorPedidos.Domain.Interfaces.Servicos;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorPedidos.Domain.Services
{
    public class ServicoCategoriaProduto : Notifiable, IServicoCategoriaProduto
    {
        private IRepositorioCategoriaProduto _repository;

        public ServicoCategoriaProduto(IRepositorioCategoriaProduto repositoryCategoriaProduto)
        {
            _repository = repositoryCategoriaProduto;
        }

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
            return _repository.ListarOrdenadosPor(item => item.Descricao).ToList().Select(CategoriaProduto => (CategoriaProdutoResponse)CategoriaProduto);
        }
    }
}
