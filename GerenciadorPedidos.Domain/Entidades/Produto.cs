using System;
using GerenciadorPedidos.Domain.Argumentos.Produtos;
using GerenciadorPedidos.Domain.Entidades.Base;
using GerenciadorPedidos.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace GerenciadorPedidos.Domain.Entidades
{
    public class Produto : EntidadeBase
    {
        public Produto() { }
        public Produto(ProdutoIncluirRequest request)
        {
            Descricao = request.descricao;
            CategoriaProdutoId = request.categoriaProdutoId;
            ValorVenda = request.valorVenda;
            Quantidade = request.quantidade;

            ValidarDominio();
        }

        public string Descricao { get; private set; }
        public CategoriaProduto CategoriaProduto { get; private set; }
        public Guid CategoriaProdutoId { get; private set; }
        public decimal ValorVenda { get; private set; }
        public int Quantidade { get; private set; }

        public void Alterar(ProdutoAlterarRequest request)
        {
            Id = request.id;
            Descricao = request.descricao;
            CategoriaProdutoId = request.categoriaProdutoId;
            ValorVenda = request.valorVenda;
            Quantidade = request.quantidade;

            new AddNotifications<Produto>(this).IfNull(item => item.Id.ToString(), Message.X0_INVALIDO.ToFormat("Id"));
            ValidarDominio();
        }

        public void ValidarDominio()
        {
            new AddNotifications<Produto>(this).IfNotGuid(item => item.CategoriaProdutoId.ToString(), Message.X0_INVALIDA.ToFormat("Categoria do produto"));
            new AddNotifications<Produto>(this).IfNullOrInvalidLength(item => item.Descricao, 1, 200, Message.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Descrição"));
        }
    }
}