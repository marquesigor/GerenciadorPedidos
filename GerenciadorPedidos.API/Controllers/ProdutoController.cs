using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using GerenciadorPedidos.Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GerenciadorPedidos.API.Controllers
{
    [Route("Produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IServicoProduto _servicoProduto;

        public ProdutoController(IServicoProduto servicoProduto)
        {
            _servicoProduto = servicoProduto;
        }

        // [HttpGet]
        // public IEnumerable<IResponse> Buscar()
        // {
        //     try
        //     {
        //         var response = _servicoProduto.Listar();
        //         return response;
        //     }
        //     catch (Exception ex)
        //     {
        //         return null;
        //     }
        // }
    }
}
