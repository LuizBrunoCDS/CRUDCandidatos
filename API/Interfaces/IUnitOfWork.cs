using API.Models;
using System;

namespace API.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositorio<Candidato> CandidatoRepositorio { get; }
        IRepositorio<Horario> HorarioRepositorio { get; }
        IRepositorio<Periodo> PeriodoRepositorio { get; }
        IRepositorio<Conhecimento> ConhecimentoRepositorio { get; }
        IRepositorio<CandidatoConhecimento> CandidatoConhecimentoRepositorio { get; }
        IRepositorio<CandidatoHorario> CandidatoHorarioRepositorio { get; }
        IRepositorio<CandidatoPeriodo> CandidatoPeriodoRepositorio { get; }
        void Commit();
    }
}
