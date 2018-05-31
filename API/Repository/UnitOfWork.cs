using System;
using API.Context;
using API.Interfaces;
using API.Models;

namespace API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CRUDContext context;
        private Repositorio<Candidato> candidatoRepositorio;
        private Repositorio<Conhecimento> conhecimentoRepositorio;
        private Repositorio<Horario> horarioRepositorio;
        private Repositorio<Periodo> periodoRepositorio;
        private Repositorio<CandidatoConhecimento> candidatoConhecimentoRepositorio;
        private Repositorio<CandidatoHorario> candidatoHorarioRepositorio;
        private Repositorio<CandidatoPeriodo> candidatoPeriodoRepositorio;

        public UnitOfWork()
        {
            context = new CRUDContext();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public IRepositorio<Candidato> CandidatoRepositorio => candidatoRepositorio ?? (candidatoRepositorio = new Repositorio<Candidato>(context));

        public IRepositorio<Conhecimento> ConhecimentoRepositorio => conhecimentoRepositorio ?? (conhecimentoRepositorio = new Repositorio<Conhecimento>(context));

        public IRepositorio<Horario> HorarioRepositorio => horarioRepositorio ?? (horarioRepositorio = new Repositorio<Horario>(context));

        public IRepositorio<Periodo> PeriodoRepositorio => periodoRepositorio ?? (periodoRepositorio = new Repositorio<Periodo>(context));

        public IRepositorio<CandidatoConhecimento> CandidatoConhecimentoRepositorio => candidatoConhecimentoRepositorio ?? (candidatoConhecimentoRepositorio = new Repositorio<CandidatoConhecimento>(context));

        public IRepositorio<CandidatoHorario> CandidatoHorarioRepositorio => candidatoHorarioRepositorio ?? (candidatoHorarioRepositorio = new Repositorio<CandidatoHorario>(context));

        public IRepositorio<CandidatoPeriodo> CandidatoPeriodoRepositorio => candidatoPeriodoRepositorio ?? (candidatoPeriodoRepositorio = new Repositorio<CandidatoPeriodo>(context));

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
                context.Dispose();
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}