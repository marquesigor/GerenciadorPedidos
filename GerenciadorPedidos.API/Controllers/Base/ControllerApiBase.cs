using GerenciadorPedidos.Domain.Interfaces.Servicos.Base;
using GerenciadorPedidos.Infra.Transacoes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorPedidos.API.Controllers.Base
{
    public class ControllerApiBase : Controller
    {
            private readonly IUnitOfWork _unitOfWork;
            private IServicoBase _serviceBase;

            public ControllerApiBase(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IActionResult> ResponseAsync(object result, IServicoBase serviceBase)
            {
                _serviceBase = serviceBase;

                if (!serviceBase.Notifications.Any())
                {
                    try
                    {
                        _unitOfWork.SaveChanges();

                        return Ok(result);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                    }
                }
                else
                {
                    return BadRequest(new { errors = serviceBase.Notifications });
                }
            }

            public async Task<IActionResult> ResponseExceptionAsync(Exception ex)
            {
                return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
            }

            protected override void Dispose(bool disposing)
            {
                if (_serviceBase != null)
                {
                    _serviceBase.Dispose();
                }

                base.Dispose(disposing);
            }
        }
    }