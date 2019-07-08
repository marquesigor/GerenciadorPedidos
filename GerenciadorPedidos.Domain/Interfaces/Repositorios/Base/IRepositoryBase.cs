using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GerenciadorPedidos.Domain.Interfaces.Repositorios.Base
{
    public interface IRepositoryBase<TEntidade, TId>
       where TEntidade : class
       where TId : struct
    {
        IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] incluirPropriedades);

        IQueryable<TEntidade> ListarEOrdenadosPor<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] incluirPropriedades);

        TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] incluirPropriedades);

        bool Existe(Func<TEntidade, bool> where);

        IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] incluirPropriedades);

        IQueryable<TEntidade> ListarOrdenadosPor<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] incluirPropriedades);

        TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] incluirPropriedades);

        TEntidade Adicionar(TEntidade entidade);

        TEntidade Editar(TEntidade entidade);

        TEntidade EditarRemovendoProperties(TEntidade entidade, params Expression<Func<TEntidade, object>>[] incluirPropriedades);

        void Remover(TEntidade entidade);

        IEnumerable<TEntidade> AdicionarLista(IEnumerable<TEntidade> entidades);
    }
}