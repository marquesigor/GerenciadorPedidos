using GerenciadorPedidos.Domain.Entidades;
using GerenciadorPedidos.Domain.ValueObjects;
using GerenciadorPedidos.Infra.Data.Mapeamento;
using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;

namespace GerenciadorPedidos.Infra.Data.Context
{
    public class GerenciadorPedidosContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CategoriaProduto> CategoriasProduto { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }

        public static string ConnectionString = @"Server=NET02\IGORPC;Database=GerenciadorPedidos;User ID=sa;Password=!!igor123;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Nome>();
            modelBuilder.Ignore<Email>();

            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaProdutoMap());
            modelBuilder.ApplyConfiguration(new PedidoProdutoMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}


