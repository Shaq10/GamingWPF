using NUnit.Framework;
using System.Linq;
using GamingWPF;
using GamingWPFBusiness;

namespace GamingWPFTests
{
    public class CRUDTests
    {
        CRUDManager _crudManager = new CRUDManager();
        [SetUp]
        public void Setup()
        {
            using (var db = new GamingContext()) {
                var SelectedCustomer = from u in db.Customers where u.CustomerId == "JCRED" select u;
                foreach (var u in SelectedCustomer) {
                    db.Customers.Remove(u);
                }
                var SelectedConsole = from c in db.Consoles where c.ConsoleName == "PlayStation5" select c;
                foreach (var c in SelectedConsole) {
                    db.Consoles.Remove(c);
                }
                var SelectedGenre = from g in db.Genres where g.GenreName == "Adventure" select g;
                foreach (var g in SelectedGenre)
                {
                    db.Genres.Remove(g);
                }
                var SelectedGame = from s in db.Games where s.GameId == "WATCHPS4" select s;
                foreach (var s in SelectedGame)
                {
                    db.Games.Remove(s);
                }
                db.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new GamingContext())
            {
                var SelectedCustomer = from u in db.Customers where u.CustomerId == "JCRED" select u;
                foreach (var u in SelectedCustomer)
                {
                    db.Customers.Remove(u);
                }
                var SelectedConsole = from c in db.Consoles where c.ConsoleName == "PlayStation5" select c;
                foreach (var c in SelectedConsole)
                {
                    db.Consoles.Remove(c);
                }
                var SelectedGenre = from g in db.Genres where g.GenreName == "Adventure" select g;
                foreach (var g in SelectedGenre)
                {
                    db.Genres.Remove(g);
                }
                var SelectedGame = from s in db.Games where s.GameId == "WATCHPS4" select s;
                foreach (var s in SelectedGame)
                {
                    db.Games.Remove(s);
                }
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewCustomerIsAddedNumberOfCustomersIncrementsBy1()
        {
            using (var db = new GamingContext()) {
                var count = db.Customers.Count();
                _crudManager.CreateCustomer("JCRED", "Justin", "Credible", "JCredible20@hotmail.co.uk", 12, "Crud Street", "Miscellaneous Avenue", "Birmingham", 
                    "BC45 RG", "Brazil", "+18575736278", new System.DateTime(05/05/12), 'M');
                Assert.AreEqual(count + 1, db.Customers.Count());
            }
        }

        [Test]
        public void WhenANewConsoleIsAddedNumberOfConsolesIncrementsBy1()
        {
            using (var db = new GamingContext())
            {
                var count = db.Consoles.Count();
                _crudManager.CreateConsole("PlayStation5", "Sony", 'Y') ;
                Assert.AreEqual(count + 1, db.Consoles.Count());
            }
        }

        [Test]
        public void WhenANewGenreIsAddedNumberOfGenresIncrementsBy1()
        {
            using (var db = new GamingContext())
            {
                var count = db.Genres.Count();
                _crudManager.CreateGenre("Adventure");
                Assert.AreEqual(count + 1, db.Genres.Count());
            }
        }

        [Test]
        public void WhenANewGameIsAddedNumberOfGamesIncrementsBy1()
        {
            using (var db = new GamingContext())
            {
                var count = db.Games.Count();
                _crudManager.CreateGame("WATCHPS4", 1, 1, "Watchdog", 12, (decimal)27.99, "Ubisoft", new System.DateTime(01/01/21), 32 );
                Assert.AreEqual(count + 1, db.Games.Count());
            }
        }
    }
}