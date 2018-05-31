using System.Collections.Generic;

namespace API.Models
{
    public class Periodo
    {
        public int IdPeriodo { get; set; }

        public string DsPeriodo { get; set; }

        public virtual ICollection<CandidatoPeriodo> candidatoPeriodo { get; set; }
    }
}