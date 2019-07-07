using System;

namespace GerenciadorPedidos.Domain.Argumentos.Produtos
{
    public class ProdutoAlterarRequest
    {
        public Guid id { get; set; }
        public string descricao { get; set; }
        public Guid categoriaProdutoId { get; set; }
        public decimal valorVenda { get; set; }
        public int quantidade { get; set; }
    }
}
