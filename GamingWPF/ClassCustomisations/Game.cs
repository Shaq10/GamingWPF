using System;
using System.Collections.Generic;
using System.Text;

namespace GamingWPF
{
    public partial class Game
    {
        public override string ToString()
        {
            return $"{GameId} - {Title} - {Publisher}";
        }
    }
}
