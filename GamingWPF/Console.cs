using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GamingWPF
{
    public partial class Console
    {
        public Console()
        {
            Games = new HashSet<Game>();
        }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ConsoleId { get; set; }
        public string ConsoleName { get; set; }
        public string Manufacturer { get; set; }
        public string OnlineCompatible { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
