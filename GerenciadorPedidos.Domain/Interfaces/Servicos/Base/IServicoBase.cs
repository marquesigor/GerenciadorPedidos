using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;

namespace GerenciadorPedidos.Domain.Interfaces.Servicos.Base
{
    public interface IServicoBase : INotifiable
    {
        IEnumerable<IResponse> Listar();
        IResponse Adicionar(IRequest request);
        IResponse Alterar(IRequest request);
        IResponse Excluir(Guid id);
    }
}
