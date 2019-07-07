using GerenciadorPedidos.Domain.Argumentos.Base;
using GerenciadorPedidos.Domain.Argumentos.Pedidos;
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
    public class ServicoPedido : Notifiable, IServicoPedido
    {
        private Pedido _pedido;
        private IRepositorioPedido _repository;

        public ServicoPedido(IRepositorioPedido repositoryPedido)
        {
            _repository = repositoryPedido;
        }

        public IResponse Adicionar(IRequest request)
        {
            if (request is null) AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToString().ToFormat("PedidoIncluirRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (PedidoIncluirRequest)request;
            _pedido = new Pedido(requestClasse);
            AddNotifications(_pedido);
            if (IsInvalid()) return null;
            _pedido = _repository.Adicionar(_pedido);

            return (ResponseBase)_pedido.Id;
        }


        public IResponse Alterar(IRequest request)
        {
            if (request is null) AddNotification("Alterar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("PedidoAlterarRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (PedidoAlterarRequest)request;
            _pedido = _repository.ObterPorId(requestClasse.id);
            if (_pedido == null)
            {
                AddNotification("Pedido", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _pedido.Alterar(requestClasse);
            _repository.Editar(_pedido);

            return new ResponseBase() { Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IResponse Excluir(Guid id)
        {
            _pedido = _repository.ObterPorId(id);
            if (_pedido == null)
            {
                AddNotification("Pedido", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repository.Remover(_pedido);

            return new ResponseBase() { Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IEnumerable<IResponse> Listar()
        {
            return _repository.ListarOrdenadosPor(item => item.Data).ToList().Select(Pedido => (PedidoResponse)Pedido);
        }
    }
}
