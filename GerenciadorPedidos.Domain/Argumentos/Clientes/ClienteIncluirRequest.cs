using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using System;

namespace GerenciadorPedidos.Domain.Argumentos.Clientes
{
    public class ClienteAlterarRequest : IRequest
    {
        public Guid id { get; set; }
        public string primeiroNome { get; set; }
        public string ultimoNome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
    }
}
