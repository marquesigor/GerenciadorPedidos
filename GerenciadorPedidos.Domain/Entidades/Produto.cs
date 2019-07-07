using System;
using GerenciadorPedidos.Domain.Entidades.Base;

namespace GerenciadorPedidos.Domain.Entidades
{
    public class Produto : EntidadeBase
    {
        public string Descricao { get;private set; }
        public CategoriaProduto CategoriaProduto { get; private set; }
        public Guid CategoriaProdutoId { get; private set; }
        public double ValorVenda { get;private set; }
        public int Quantidade { get;private set; }

        public void Incluir()
        {

        }
    }
}