using GerenciadorPedidos.Domain.Argumentos.Base;
using GerenciadorPedidos.Domain.Argumentos.PedidoProdutos;
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
    public class ServicoPedidoProduto : Notifiable, IServicoPedidoProduto
    {
        private PedidoProduto _pedidoProduto;
        private IRepositorioPedidoProduto _repository;

        public ServicoPedidoProduto(IRepositorioPedidoProduto repositoryPedidoProduto)
        {
            _repository = repositoryPedidoProduto;
        }

        public IResponse Adicionar(IRequest request)
        {
            if (request is null) AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToString().ToFormat("PedidoProdutoIncluirRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (PedidoProdutoIncluirRequest)request;
            _pedidoProduto = new PedidoProduto(requestClasse);
            AddNotifications(_pedidoProduto);
            if (IsInvalid()) return null;
            _pedidoProduto = _repository.Adicionar(_pedidoProduto);

            return (ResponseBase)_pedidoProduto.Id;
        }


        public IResponse Alterar(IRequest request)
        {
            if (request is null) AddNotification("Alterar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("PedidoProdutoAlterarRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (PedidoProdutoAlterarRequest)request;
            _pedidoProduto = _repository.ObterPorId(requestClasse.id);
            if (_pedidoProduto == null)
            {
                AddNotification("Produto", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _pedidoProduto.Alterar(requestClasse);
            _repository.Editar(_pedidoProduto);

            return new ResponseBase() { Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IResponse Excluir(Guid id)
        {
            _pedidoProduto = _repository.ObterPorId(id);
            if (_pedidoProduto == null)
            {
                AddNotification("PedidoProduto", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repository.Remover(_pedidoProduto);

            return new ResponseBase() { Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IEnumerable<IResponse> Listar()
        {
            return _repository.ListarOrdenadosPor(item => item.DataCriacao).ToList().Select(PedidoProduto => (PedidoProdutoResponse)PedidoProduto);
        }
    }
}
