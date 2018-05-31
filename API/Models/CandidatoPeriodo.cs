namespace API.Models
{
    public class CandidatoPeriodo
    {
        public int IdCandidato { get; set; }

        public virtual Candidato candidato { get; set; }

        public int IdPeriodo { get; set; }

        public virtual Periodo periodo { get; set; }
    }
}