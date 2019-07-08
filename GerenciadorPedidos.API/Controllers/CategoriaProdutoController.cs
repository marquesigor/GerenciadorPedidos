using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using GerenciadorPedidos.Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GerenciadorPedidos.API.Controllers
{
    [ApiController]
    [Route("produtos/categorias")]
    public class CategoriaProdutoController : ControllerBase
    {
        private readonly IServicoCategoriaProduto _servicoCategoriaProduto;

        public CategoriaProdutoController(IServicoCategoriaProduto servicoCategoriaProduto)
        {
            _servicoCategoriaProduto = servicoCategoriaProduto;
        }

        [HttpGet]
        public IEnumerable<IResponse> Buscar()
        {
            try
            {
                var response = _servicoCategoriaProduto.Listar();
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
