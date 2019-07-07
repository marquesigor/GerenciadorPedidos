namespace GerenciadorPedidos.Infra.Transacoes
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
