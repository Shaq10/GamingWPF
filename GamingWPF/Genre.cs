using System;
using System.Collections.Generic;

#nullable disable

namespace GamingWPF
{
    public partial class Genre
    {
        public Genre()
        {
            Games = new HashSet<Game>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
