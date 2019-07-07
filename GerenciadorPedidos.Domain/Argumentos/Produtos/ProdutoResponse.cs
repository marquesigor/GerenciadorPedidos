using GerenciadorPedidos.Domain.Entidades;
using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using System;

namespace GerenciadorPedidos.Domain.Argumentos.Produtos
{
    public class ProdutoResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public CategoriaProduto CategoriaProduto { get; set; }
        public Guid CategoriaProdutoId { get; set; }
        public decimal ValorVenda { get; set; }
        public int Quantidade { get; set; }

        public static explicit operator ProdutoResponse(Produto model)
        {
            return new ProdutoResponse()
            {
                Id = model.Id,
                Descricao = model.Descricao,
                CategoriaProduto = model.CategoriaProduto,
                CategoriaProdutoId = model.CategoriaProdutoId,
                ValorVenda = model.ValorVenda,
                Quantidade  = model.Quantidade
            };
        }
    }
}
