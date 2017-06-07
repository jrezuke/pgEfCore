using System;
using System.Collections.Generic;

namespace pgEfCore.Models
{
    public partial class Site
    {
        public Site()
        {
            Subject = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }

        public ICollection<Subject> Subject { get; set; }
    }
}
