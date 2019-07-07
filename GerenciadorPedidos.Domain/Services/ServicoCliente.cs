using GerenciadorPedidos.Domain.Argumentos.Base;
using GerenciadorPedidos.Domain.Argumentos.Clientes;
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

namespace GerenciadorClientes.Domain.Services
{
    public class ServicoCliente : Notifiable, IServicoCliente
    {
        private Cliente _Cliente;
        private IRepositorioCliente _repository;

        public ServicoCliente(IRepositorioCliente repositoryCliente)
        {
            _repository = repositoryCliente;
        }

        public IResponse Adicionar(IRequest request)
        {
            if (request is null) AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToString().ToFormat("ClienteIncluirRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (ClienteIncluirRequest)request;
            _Cliente = new Cliente(requestClasse);
            AddNotifications(_Cliente);
            if (IsInvalid()) return null;
            _Cliente = _repository.Adicionar(_Cliente);

            return (ResponseBase)_Cliente.Id;
        }


        public IResponse Alterar(IRequest request)
        {
            if (request is null) AddNotification("Alterar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("ClienteAlterarRequest"));
            if (IsInvalid()) return null;

            var requestClasse = (ClienteAlterarRequest)request;
            _Cliente = _repository.ObterPorId(requestClasse.id);
            if (_Cliente == null)
            {
                AddNotification("Cliente", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _Cliente.Alterar(requestClasse);
            _repository.Editar(_Cliente);

            return new ResponseBase() { Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IResponse Excluir(Guid id)
        {
            _Cliente = _repository.ObterPorId(id);
            if (_Cliente == null)
            {
                AddNotification("Cliente", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repository.Remover(_Cliente);

            return new ResponseBase() { Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IEnumerable<IResponse> Listar()
        {
            return _repository.ListarOrdenadosPor(item => item.Nome.PrimeiroNome).ToList().Select(Cliente => (ClienteResponse)Cliente);
        }
    }
}
