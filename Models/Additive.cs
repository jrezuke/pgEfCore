using System;
using System.Collections.Generic;

namespace pgEfCore.Models
{
    public partial class Additive
    {
        public int Id { get; set; }
        public int CalEntryId { get; set; }
        public int AdditiveListId { get; set; }
        public int Volume { get; set; }

        public AdditiveList AdditiveList { get; set; }
        public CalEntry CalEntry { get; set; }
    }
}
