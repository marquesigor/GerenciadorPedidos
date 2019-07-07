using GerenciadorPedidos.Domain.ValueObjects;
using GerenciadorPedidos.Domain.Entidades.Base;

namespace GerenciadorPedidos.Domain.Entidades
{
    public class Cliente : EntidadeBase
    {
        public Nome Nome { get;private set; }
        public Email Email { get;private set; }
        public string Telefone { get; private set; }
        public string Endereco { get;private set; }

        public void Incluir()
        {
            
        }
    }
}
