using System;
using System.Collections.Generic;

namespace pgEfCore.Models
{
    public partial class Enteral
    {
        public int Id { get; set; }
        public int CalEntryId { get; set; }
        public int FormulaListId { get; set; }
        public int Volume { get; set; }

        public CalEntry CalEntry { get; set; }
        public FormulaList FormulaList { get; set; }
    }
}
