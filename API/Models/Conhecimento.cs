using System.Collections.Generic;

namespace API.Models
{
    public class Conhecimento
    {
        public int IdConhecimento { get; set; }

        public string DsConhecimento { get; set; }
       
        public virtual ICollection<CandidatoConhecimento> candidatoConhecimentos { get; set; }
    }
}