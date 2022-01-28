using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3DB.Models
{
    public partial class Personal
    {
        public int PersonalId { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Befattning { get; set; }
    }
}
