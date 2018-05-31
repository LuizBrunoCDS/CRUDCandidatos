using API.Models;
using API.Repository;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Net;

namespace API.Controllers
{
    public class CandidatoController : ApiController
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Candidato    
        [Route("Candidato/Get")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var candidatos = unitOfWork.CandidatoRepositorio.SelectAll(orderBy: a => a.OrderBy(b => b.Nome));
            if (candidatos == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, candidatos);
        }

        // GET: Candidato/5
        [Route("Candidato/Get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var candidato = unitOfWork.CandidatoRepositorio.SelectByID(filter: a => a.IdCandidato == id, includeProperties: "candidatoHorarios,candidatoConhecimentos,candidatoPeriodos");
            if (candidato == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, candidato);
        }

        // POST: Candidato/Insert
        [Route("Candidato/Insert")]
        [HttpPost]
        public HttpResponseMessage Post(Candidato candidato)
        {
            try
            {
                if (candidato == null)
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                unitOfWork.CandidatoRepositorio.Insert(candidato);
                unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK, "Inserido");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT: Candidato/Update
        [Route("Candidato/Update")]
        [HttpPut]
        public HttpResponseMessage Put(Candidato candidato)
        {
            try
            {
                if (candidato == null)
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                var entity = unitOfWork.CandidatoRepositorio.SelectByID(filter: a => a.IdCandidato == candidato.IdCandidato, includeProperties: "candidatoHorarios,candidatoConhecimentos,candidatoPeriodos");
                unitOfWork.CandidatoRepositorio.Update(entity, candidato);
                #region update horarios
                foreach (var horario in entity.candidatoHorarios.ToList())
                {
                    if (!candidato.candidatoHorarios.Any(a => a.IdHorario == horario.IdHorario))
                        unitOfWork.CandidatoHorarioRepositorio.Delete(horario);
                }

                foreach (var horario in candidato.candidatoHorarios)
                {
                    var exist = entity.candidatoHorarios.SingleOrDefault(a => a.IdHorario == horario.IdHorario);
                    if (exist != null)
                        unitOfWork.CandidatoHorarioRepositorio.Update(exist, horario);
                    else
                        unitOfWork.CandidatoHorarioRepositorio.Insert(horario);
                }
                #endregion
                #region update periodos
                foreach (var periodo in entity.candidatoPeriodos.ToList())
                {
                    if (!candidato.candidatoPeriodos.Any(a => a.IdPeriodo == periodo.IdPeriodo))
                        unitOfWork.CandidatoPeriodoRepositorio.Delete(periodo);
                }

                foreach (var periodo in candidato.candidatoPeriodos)
                {
                    var exist = entity.candidatoPeriodos.SingleOrDefault(a => a.IdPeriodo == periodo.IdPeriodo);
                    if (exist != null)
                        unitOfWork.CandidatoPeriodoRepositorio.Update(exist, periodo);
                    else
                        unitOfWork.CandidatoPeriodoRepositorio.Insert(periodo);
                }
                #endregion
                #region update conhecimentos
                foreach (var conhecimento in entity.candidatoConhecimentos.ToList())
                {
                    if (!candidato.candidatoConhecimentos.Any(a => a.IdConhecimento == conhecimento.IdConhecimento))
                        unitOfWork.CandidatoConhecimentoRepositorio.Delete(conhecimento);
                }

                foreach (var conhecimento in candidato.candidatoConhecimentos)
                {
                    var exist = entity.candidatoConhecimentos.SingleOrDefault(a => a.IdConhecimento == conhecimento.IdConhecimento);
                    if (exist != null)
                        unitOfWork.CandidatoConhecimentoRepositorio.Update(exist, conhecimento);
                    else
                        unitOfWork.CandidatoConhecimentoRepositorio.Insert(conhecimento);
                }
                #endregion
                unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK, "Alterado");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE: Candidato/Delete/5
        [Route("Candidato/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var candidato = unitOfWork.CandidatoRepositorio.SelectByID(filter: a => a.IdCandidato == id, includeProperties: "candidatoHorarios,candidatoConhecimentos,candidatoPeriodos");
                if (candidato == null)
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                unitOfWork.CandidatoRepositorio.Delete(candidato);
                unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK, "Removido");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
