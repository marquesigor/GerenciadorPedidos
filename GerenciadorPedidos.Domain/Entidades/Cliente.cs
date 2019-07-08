using GerenciadorPedidos.Domain.ValueObjects;
using GerenciadorPedidos.Domain.Entidades.Base;
using GerenciadorPedidos.Domain.Argumentos.Clientes;
using GerenciadorPedidos.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace GerenciadorPedidos.Domain.Entidades
{
    public class Cliente : EntidadeBase
    {
        public Cliente() { }
        public Cliente(ClienteIncluirRequest request)
        {
            Nome = new Nome(request.primeiroNome, request.ultimoNome);
            Email = new Email(request.email);
            Telefone = request.telefone;
            Endereco = request.endereco;

            new AddNotifications<Cliente>(this).IfNullOrInvalidLength(item => item.Telefone, 1, 20, Message.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Telefone"));
            new AddNotifications<Cliente>(this).IfNullOrInvalidLength(item => item.Endereco, 1, 200, Message.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Endereço"));
        }

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Telefone { get; private set; }
        public string Endereco { get; private set; }

        public void Alterar(ClienteAlterarRequest request)
        {
            Id = request.id;
            Nome = new Nome(request.primeiroNome, request.ultimoNome);
            Email = new Email(request.email);
            Telefone = request.telefone;
            Endereco = request.endereco;

            new AddNotifications<Cliente>(this).IfNullOrInvalidLength(item => item.Telefone, 1, 20, Message.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Telefone"));
            new AddNotifications<Cliente>(this).IfNullOrInvalidLength(item => item.Endereco, 1, 200, Message.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Endereço"));
        }
    }
}
