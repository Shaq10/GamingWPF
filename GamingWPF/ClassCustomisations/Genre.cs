using System;
using System.Collections.Generic;
using System.Text;

namespace GamingWPF
{
    public partial class Genre
    {
        public override string ToString()
        {
            return $"{GenreId} - {GenreName}";
        }
    }
}
