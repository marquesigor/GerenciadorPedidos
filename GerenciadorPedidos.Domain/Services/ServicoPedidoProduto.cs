﻿using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using GerenciadorPedidos.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace GerenciadorPedidos.Domain.Services
{
    public class ServicoPedidoProduto : IServicoPedidoProduto
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