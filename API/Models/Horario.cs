using System.Collections.Generic;

namespace API.Models
{
    public class Horario
    {
        public int IdHorario { get; set; }

        public string DsHorario { get; set; }

        public virtual ICollection<CandidatoHorario> candidatoHorario { get; set; }
    }
}