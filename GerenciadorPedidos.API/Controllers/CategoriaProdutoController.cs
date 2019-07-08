using GerenciadorPedidos.API.Controllers.Base;
using GerenciadorPedidos.Domain.Interfaces.Servicos;
using GerenciadorPedidos.Infra.Transacoes;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GerenciadorPedidos.API.Controllers
{
    [Route("produtos/categorias")]
    public class CategoriaProdutoController : ControllerApiBase
    {
        private readonly IServicoCategoriaProduto _servicoCategoriaProduto;

        public CategoriaProdutoController(IUnitOfWork unityOfWork, IServicoCategoriaProduto servicoCategoriaProduto) : base(unityOfWork)
        {
            _servicoCategoriaProduto = servicoCategoriaProduto;
        }
       
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var response = _servicoCategoriaProduto.Listar();

                return ResponseAsync(response, _servicoCategoriaProduto);
            }
            catch (Exception ex)
            {
                return ResponseExceptionAsync(ex);
                
            }
        }

    }
}
