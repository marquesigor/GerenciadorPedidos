using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using System;

namespace GerenciadorPedidos.Domain.Argumentos.Base
{
    public class ResponseBase  : IResponse
    {
        public Guid? Id { get; set; }
        public string Mensagem { get; set; }

        public static explicit operator ResponseBase(Guid id)
        {
            return new ResponseBase()
            {
                Id = id,
                Mensagem = Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
