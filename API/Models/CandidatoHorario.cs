namespace API.Models
{
    public class CandidatoHorario
    {
        public int IdCandidato { get; set; }

        public virtual Candidato candidato { get; set; }

        public int IdHorario { get; set; }

        public virtual Horario horario { get; set; }
    }
}