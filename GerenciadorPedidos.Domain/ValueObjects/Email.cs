using GerenciadorPedidos.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace GerenciadorPedidos.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email() { }
        public Email(string enderecoEletronico)
        {
            EnderecoEletronico = enderecoEletronico;

            new AddNotifications<Email>(this).IfNotEmail(item => item.EnderecoEletronico, Message.X0_INVALIDA.ToFormat("E-mail"));
            new AddNotifications<Email>(this).IfNullOrInvalidLength(item => item.EnderecoEletronico, 1, 200, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("EnderecoEletronico", "1", "200"));
        }

        public string EnderecoEletronico { get; private set; }
    }
}
