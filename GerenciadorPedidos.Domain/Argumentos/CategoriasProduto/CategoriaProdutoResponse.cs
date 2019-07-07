using GerenciadorPedidos.Domain.Entidades;
using GerenciadorPedidos.Domain.Interfaces.Argumentos;
using System;

namespace GerenciadorPedidos.Domain.Argumentos.CategoriasProduto
{
    public class CategoriaProdutoResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public static explicit operator CategoriaProdutoResponse(CategoriaProduto model)
        {
            return new CategoriaProdutoResponse()
            {
                Id = model.Id,
                Descricao = model.Descricao,
            };
        }
    }
}
