using GerenciadorPedidos.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace GerenciadorPedidos.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        public Nome(string primerioNome, string ultimoNome)
        {
            PrimeiroNome = primerioNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this).IfNullOrInvalidLength(item => item.PrimeiroNome, 1, 50, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("PrimeiroNome", "1", "50"));
            new AddNotifications<Nome>(this).IfNullOrInvalidLength(item => item.UltimoNome, 1, 100, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("UltimoNome", "1", "100"));
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
    }
}
