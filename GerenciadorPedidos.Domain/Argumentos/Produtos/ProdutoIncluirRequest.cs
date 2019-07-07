using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using System;

namespace GerenciadorPedidos.Domain.Argumentos.Produtos
{
    public class ProdutoIncluirRequest : IRequest
    {
        public string descricao { get; set; }
        public Guid categoriaProdutoId { get; set; }
        public decimal valorVenda { get;  set; }
        public int quantidade { get; set; }
    }
}
