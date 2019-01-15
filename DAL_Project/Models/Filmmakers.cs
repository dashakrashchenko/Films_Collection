using System;
using System.Collections.Generic;

namespace DAL_Project.Models
{
    public partial class Filmmakers
    {
        public Filmmakers()
        {
            Films = new HashSet<Films>();
        }

        public int IdFilmmaker { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<Films> Films { get; set; }
    }
}
