using GerenciadorPedidos.Domain.Argumentos.Base;
using GerenciadorPedidos.Domain.Argumentos.Produtos;
using GerenciadorPedidos.Domain.Entidades;
using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using GerenciadorPedidos.Domain.Interfaces.Repositorios;
using GerenciadorPedidos.Domain.Interfaces.Servicos;
using GerenciadorPedidos.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorPedidos.Domain.Services
{
    public class ServicoProduto : Notifiable, IServicoProduto
    {
        private Produto _produto;
        private IRepositorioProduto _repository;

        public ServicoProduto(IRepositorioProduto repositoryProduto)
        {
            _repository = repositoryProduto;
        }

        public IResponse Adicionar(IRequest request)
        {
            if (request is null) AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToString().ToFormat("ProdutoIncluirRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (ProdutoIncluirRequest)request;
            _produto = new Produto(requestClasse);
            AddNotifications(_produto);
            if (IsInvalid()) return null;
            _produto = _repository.Adicionar(_produto);

            return (ResponseBase)_produto.Id;
        }


        public IResponse Alterar(IRequest request)
        {
            if (request is null) AddNotification("Alterar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("ProdutoAlterarRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (ProdutoAlterarRequest)request;
            _produto = _repository.ObterPorId(requestClasse.id);
            if (_produto == null)
            {
                AddNotification("Produto", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _produto.Alterar(requestClasse);
            _repository.Editar(_produto);

            return new ResponseBase() { Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IResponse Excluir(Guid id)
        {
            _produto = _repository.ObterPorId(id);
            if (_produto == null)
            {
                AddNotification("Produto", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repository.Remover(_produto);

            return new ResponseBase() { Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IEnumerable<IResponse> Listar()
        {
            return _repository.ListarOrdenadosPor(item => item.Descricao).ToList().Select(Produto => (ProdutoResponse)Produto);
        }
    }
}
