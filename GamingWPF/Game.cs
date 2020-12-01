using System;
using System.Collections.Generic;

#nullable disable

namespace GamingWPF
{
    public partial class Game
    {
        public Game()
        {
            Orders = new HashSet<Order>();
        }

        public string GameId { get; set; }
        public int ConsoleId { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }
        public int AgeRating { get; set; }
        public decimal Price { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Multiplayers { get; set; }

        public virtual Console Console { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
