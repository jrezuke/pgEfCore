using System;
using System.Collections.Generic;

namespace pgEfCore.Models
{
    public partial class Subject
    {
        public Subject()
        {
            CalEntry = new HashSet<CalEntry>();
        }

        public int Id { get; set; }
        public int SiteId { get; set; }
        public string SubjectId { get; set; }
        public DateTime StartDate { get; set; }

        public ICollection<CalEntry> CalEntry { get; set; }
        public Site Site { get; set; }
    }
}
