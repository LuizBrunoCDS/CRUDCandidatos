namespace API.Models
{
    public class CandidatoConhecimento
    {
        public int IdCandidato { get; set; }

        public virtual Candidato candidato { get; set; }

        public int IdConhecimento { get; set; }

        public virtual Conhecimento conhecimento { get; set; }

        public string DsOutros { get; set; }

        public int Nivel { get; set; }
    }
}