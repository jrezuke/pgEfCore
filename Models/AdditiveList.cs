using System;
using System.Collections.Generic;

namespace pgEfCore.Models
{
    public partial class AdditiveList
    {
        public AdditiveList()
        {
            Additive = new HashSet<Additive>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal? KcalUnit { get; set; }
        public int? ProteinOfKcal { get; set; }
        public int? ChoOfKcal { get; set; }
        public int? LipidOfKcal { get; set; }
        public int? Unit { get; set; }

        public ICollection<Additive> Additive { get; set; }
    }
}
