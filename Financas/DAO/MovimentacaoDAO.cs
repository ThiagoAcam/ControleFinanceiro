using Financas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financas.DAO
{
    public class MovimentacaoDAO
    {
        private FinancasContext context;

        public MovimentacaoDAO( FinancasContext contex)
        {
            this.context = contex;
        }

        public void Adiciona(Movimentacao movimentacao)
        {
            context.Movimentacoes.Add(movimentacao);
            context.SaveChanges();
        }

        public IList<Movimentacao> Lista()
        {
            return context.Movimentacoes.ToList();
        }

        public IList<Movimentacao> BuscaPorUsuario(int? usuarioID)
        {
            return context.Movimentacoes.Where(x => x.UsuarioId == usuarioID).ToList();
        }


        public IList<Movimentacao> Busca(decimal? ValorMinimo, 
                                         decimal? ValorMaximo, 
                                         DateTime? DataMinima, 
                                         DateTime? DataMaxima, 
                                         Tipo? Tipo, 
                                         int? usuarioID)
        {
            IQueryable<Movimentacao> busca = context.Movimentacoes;

            if(ValorMinimo.HasValue)
            {
                busca = busca.Where(x => x.Valor >= ValorMinimo);
            }

            if (ValorMaximo.HasValue)
            {
                busca = busca.Where(x => x.Valor <= ValorMaximo);
            }

            if (DataMinima.HasValue)
            {
                busca = busca.Where(x => x.Data >= DataMinima);
            }

            if (DataMaxima.HasValue)
            {
                busca = busca.Where(x => x.Data <= DataMaxima);
            }

            if (Tipo.HasValue)
            {
                busca = busca.Where(x => x.Tipo == Tipo);
            }

            if (usuarioID.HasValue)
            {
                busca = busca.Where(x => x.UsuarioId >= usuarioID);
            }

            return busca.ToList();
        }
    }
}