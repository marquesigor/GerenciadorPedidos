using GerenciadorPedidos.Domain.Entidades;
using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using System;

namespace GerenciadorPedidos.Domain.Argumentos.Clientes
{
    public class ClienteResponse : IResponse
    {
        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public static explicit operator ClienteResponse(Cliente model)
        {
            return new ClienteResponse()
            {
                Id = model.Id,
                PrimeiroNome = model.Nome.PrimeiroNome,
                UltimoNome = model.Nome.UltimoNome,
                Email = model.Email.EnderecoEletronico,
                Telefone = model.Telefone,
                Endereco = model.Endereco
            };
        }
    }
}
