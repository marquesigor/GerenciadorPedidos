using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using System;
using System.Collections.Generic;

namespace GerenciadorPedidos.Domain.Interfaces.Servicos.Base
{
    public interface IServicoBase
    {
        IEnumerable<IResponse> Listar();
        IResponse Adicionar(IRequest request);
        IResponse Alterar(IRequest request);
        IResponse Excluir(Guid id);
    }
}
