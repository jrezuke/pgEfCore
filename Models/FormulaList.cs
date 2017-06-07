using System;
using System.Collections.Generic;

namespace pgEfCore.Models
{
    public partial class FormulaList
    {
        public FormulaList()
        {
            Enteral = new HashSet<Enteral>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal KcalML { get; set; }
        public decimal? KcalOz { get; set; }
        public int Protein { get; set; }
        public int Cho { get; set; }
        public int Lipid { get; set; }

        public ICollection<Enteral> Enteral { get; set; }
    }
}
