using System.Collections.Generic;

namespace API.Models
{
    public class Candidato
    {
        public int IdCandidato { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Skype { get; set; }

        public string Telefone { get; set; }

        public string Linkedin { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Portfolio { get; set; }

        public float PretensaoSalarial { get; set; }

        public string NomeBanco { get; set; }

        public string NomeBeneficiarioBanco { get; set; }

        public string CpfBeneficiarioBanco { get; set; }

        public string TipoConta { get; set; }

        public string AgenciaBanco { get; set; }

        public string ContaBanco { get; set; }

        public string LinkCrud { get; set; }

        public virtual ICollection<CandidatoConhecimento> candidatoConhecimentos { get; set; }

        public virtual ICollection<CandidatoHorario> candidatoHorarios { get; set; }

        public virtual ICollection<CandidatoPeriodo> candidatoPeriodos { get; set; }
    }
}