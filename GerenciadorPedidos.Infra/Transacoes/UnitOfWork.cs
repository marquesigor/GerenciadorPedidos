using GerenciadorPedidos.Infra.Data.Context;

namespace GerenciadorPedidos.Infra.Transacoes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GerenciadorPedidosContext _context;

        public UnitOfWork(GerenciadorPedidosContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
