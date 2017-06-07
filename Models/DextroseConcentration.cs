using System;
using System.Collections.Generic;

namespace pgEfCore.Models
{
    public partial class DextroseConcentration
    {
        public DextroseConcentration()
        {
            FluidInfusion = new HashSet<FluidInfusion>();
        }

        public int Id { get; set; }
        public string Concentration { get; set; }
        public decimal KcalMl { get; set; }

        public ICollection<FluidInfusion> FluidInfusion { get; set; }
    }
}
