using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3DB.Models
{
    public partial class Betyg
    {
        public int? BetygsId { get; set; }
        public string Kurs { get; set; }
        public string Betyg1 { get; set; }
        public DateTime? Datum { get; set; }
        public int? PersonalId { get; set; }
        public string Personnummer { get; set; }

        public virtual Personal Personal { get; set; }
        public virtual Elever PersonnummerNavigation { get; set; }
    }
}
