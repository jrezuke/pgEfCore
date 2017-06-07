using System;
using System.Collections.Generic;

namespace pgEfCore.Models
{
    public partial class CalEntry
    {
        public CalEntry()
        {
            Additive = new HashSet<Additive>();
            Enteral = new HashSet<Enteral>();
            FluidInfusion = new HashSet<FluidInfusion>();
            Parenteral = new HashSet<Parenteral>();
        }

        public int Id { get; set; }
        public int SubjectId { get; set; }
        public decimal Weight { get; set; }
        public decimal Hours { get; set; }
        public DateTime EntryDate { get; set; }

        public ICollection<Additive> Additive { get; set; }
        public ICollection<Enteral> Enteral { get; set; }
        public ICollection<FluidInfusion> FluidInfusion { get; set; }
        public ICollection<Parenteral> Parenteral { get; set; }
        public Subject Subject { get; set; }
    }
}
