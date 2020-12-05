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
                var SelectedOrder = from o in db.Orders where o.CustomerId == "JCRED" select o;
                db.Orders.RemoveRange(SelectedOrder);
                var SelectedCustomer = from u in db.Customers where u.CustomerId == "JCRED" select u;
                
                    db.Customers.RemoveRange(SelectedCustomer);
                
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
                
                    db.Games.RemoveRange(SelectedGame);
                
                db.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new GamingContext())
            {
                var SelectedOrder = from o in db.Orders where o.CustomerId == "JCRED" select o;
                db.Orders.RemoveRange(SelectedOrder);

                var SelectedCustomer = from u in db.Customers where u.CustomerId == "JCRED" select u;
                db.Customers.RemoveRange(SelectedCustomer);
                
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
                db.Games.RemoveRange(SelectedGame);
                
                db.SaveChanges();
            }
        }

        // Tests for Creating

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
        public void CorrectDetailsForNewCustomer() {
            using (var db = new GamingContext())
            {
                _crudManager.CreateCustomer("JCRED", "Justin", "Credible", "JCredible20@hotmail.co.uk", 12, "Crud Street", "Miscellaneous Avenue", "Birmingham",
                    "BC45 RG", "Brazil", "+18575736278", new System.DateTime(05 / 05 / 12), 'M');
                var newCustomer = db.Customers.Where(c => c.CustomerId == "JCRED").FirstOrDefault();
                Assert.AreEqual("Justin", newCustomer.FirstName);
                Assert.AreEqual("Credible", newCustomer.LastName);
                Assert.AreEqual("JCredible20@hotmail.co.uk", newCustomer.Email);
                Assert.AreEqual(12, newCustomer.HouseNum);
                Assert.AreEqual("Crud Street", newCustomer.FirstLineAddress);
                Assert.AreEqual("Miscellaneous Avenue", newCustomer.SecondLineAddress);
                Assert.AreEqual("Birmingham", newCustomer.City);
                Assert.AreEqual("BC45 RG", newCustomer.Postcode);
                Assert.AreEqual("Brazil", newCustomer.Country);
                Assert.AreEqual("+18575736278", newCustomer.Mobile);
                Assert.AreEqual(new System.DateTime(05/05/12), newCustomer.Dob);
                Assert.AreEqual("M", newCustomer.Gender);
            }
        }

        [Test]
        public void WhenANewConsoleIsAddedNumberOfConsolesIncrementsBy1()
        {
            using (var db = new GamingContext())
            {
                var count = db.Consoles.Count();
                _crudManager.CreateConsole("PlayStation5", "Sony", "Y") ;
                Assert.AreEqual(count + 1, db.Consoles.Count());
            }
        }

        [Test]
        public void CorrectDetailsForNewConsole() {
            using (var db = new GamingContext()) {
                _crudManager.CreateConsole("PlayStation5", "Sony", "Y");
                var newConsole = db.Consoles.Where(z => z.ConsoleName == "PlayStation5").FirstOrDefault();
                Assert.AreEqual("PlayStation5", newConsole.ConsoleName);
                Assert.AreEqual("Sony", newConsole.Manufacturer);
                Assert.AreEqual("Y", newConsole.OnlineCompatible);
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
        public void CorrectDetailsForNewGenre() {
            using (var db = new GamingContext())
            {
                _crudManager.CreateGenre("Adventure");
                var newGenre = db.Genres.Where(x => x.GenreName == "Adventure").FirstOrDefault();
                Assert.AreEqual("Adventure", newGenre.GenreName);
            }
        }

        [Test]
        public void WhenANewGameIsAddedNumberOfGamesIncrementsBy1()
        {
            using (var db = new GamingContext())
            {
                var count = db.Games.Count();
                _crudManager.CreateGame("WATCHPS4", 1, 1, "Watchdog", 12, (decimal)27.99, "Ubisoft", new System.DateTime(01/01/2021), 32 );
                Assert.AreEqual(count + 1, db.Games.Count());
            }
        }

        [Test]
        public void CorrectDetailsForNewGame() {
            using (var db = new GamingContext())
            {
                _crudManager.CreateGame("WATCHPS4", 1, 1, "Watchdog", 12, (decimal)27.99, "Ubisoft", new System.DateTime(01 / 01 / 2021), 32);
                var newGame = db.Games.Where(g => g.GameId == "WATCHPS4").FirstOrDefault();
                Assert.AreEqual(1, newGame.ConsoleId);
                Assert.AreEqual(1, newGame.GenreId);
                Assert.AreEqual("Watchdog", newGame.Title);
                Assert.AreEqual(12, newGame.AgeRating);
                Assert.AreEqual(27.99, newGame.Price);
                Assert.AreEqual("Ubisoft", newGame.Publisher);
                Assert.AreEqual(1, newGame.ConsoleId);
                Assert.AreEqual(new System.DateTime(01 / 01 / 2021), newGame.ReleaseDate);
                Assert.AreEqual(32, newGame.Multiplayers);

            }
        }

        [Test]
        public void WhenANewOrderIsCreatedNumberOfOrdersIncrementsBy1()
        {
            using (var db = new GamingContext())
            {
                var count = db.Orders.Count();
                var newCustomer = new Customer() {
                    CustomerId = "JCRED", 
                    FirstName = "Justin", 
                    LastName = "Credible", 
                    Email = "JCredible20@hotmail.co.uk", 
                    HouseNum = 12, 
                    FirstLineAddress = "Crud Street", 
                    SecondLineAddress = "Miscellaneous Avenue", 
                    City = "Birmingham",
                    Postcode = "BC45 RG", 
                    Country = "Brazil", 
                    Mobile = "+18575736278", 
                    Dob = new System.DateTime(05/05/12), 
                    Gender = 'M'.ToString()
                };

                var newGame = new Game() {
                    GameId = "WATCHPS4", 
                    ConsoleId = 1, 
                    GenreId = 1, 
                    Title = "Watchdog", 
                    AgeRating = 12, 
                    Price = (decimal)27.99, 
                    Publisher = "Ubisoft", 
                    ReleaseDate = new System.DateTime(01/01/2021), 
                    Multiplayers = 32
                };

                db.Games.Add(newGame);
                db.Customers.Add(newCustomer);
                db.SaveChanges();

                var first = newCustomer.CustomerId;
                var second = newGame.GameId;

                _crudManager.CreateOrder(first, second, System.DateTime.Now, System.DateTime.Now.AddDays(3), (decimal)24.99);
                Assert.AreEqual(count + 1, db.Orders.Count());
            }
        }

        [Test]
        public void CorrectDetailsForNewOrder()
        {
            using (var db = new GamingContext())
            {
                var newCustomer = new Customer()
                {
                    CustomerId = "JCRED",
                    FirstName = "Justin",
                    LastName = "Credible",
                    Email = "JCredible20@hotmail.co.uk",
                    HouseNum = 12,
                    FirstLineAddress = "Crud Street",
                    SecondLineAddress = "Miscellaneous Avenue",
                    City = "Birmingham",
                    Postcode = "BC45 RG",
                    Country = "Brazil",
                    Mobile = "+18575736278",
                    Dob = new System.DateTime(05 / 05 / 12),
                    Gender = 'M'.ToString()
                };

                var newGame = new Game()
                {
                    GameId = "WATCHPS4",
                    ConsoleId = 1,
                    GenreId = 1,
                    Title = "Watchdog",
                    AgeRating = 12,
                    Price = (decimal)27.99,
                    Publisher = "Ubisoft",
                    ReleaseDate = new System.DateTime(01 / 01 / 2021),
                    Multiplayers = 32
                };

                db.Games.Add(newGame);
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                _crudManager.CreateOrder(newCustomer.CustomerId, newGame.GameId, System.DateTime.Now, System.DateTime.Now.AddDays(3), (decimal)24.99);
                var newOrder = db.Orders.Where(o => o.CustomerId == "JCRED").FirstOrDefault();
                Assert.AreEqual("WATCHPS4", newOrder.GameId);
                Assert.AreEqual(System.DateTime.Now.ToString("dd/MM/yyyy"), newOrder.OrderDate.ToString("dd/MM/yyyy"));
                Assert.AreEqual(System.DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"), newOrder.DeliveryDate.ToString("dd/MM/yyyy"));
                Assert.AreEqual(24.99, newOrder.Cost);
            }
        }

        [Test]
        public void WhenACustomerIsRemoved_TheyAreNoLongerInTheDB()
        {
            using (var db = new GamingContext())
            {
                var newCustomer = new Customer()
                {
                    CustomerId = "JCRED",
                    FirstName = "Justin",
                    LastName = "Credible",
                    Email = "JCredible20@hotmail.co.uk",
                    HouseNum = 12,
                    FirstLineAddress = "Crud Street",
                    SecondLineAddress = "Miscellaneous Avenue",
                    City = "Birmingham",
                    Postcode = "BC45 RG",
                    Country = "Brazil",
                    Mobile = "+18575736278",
                    Dob = new System.DateTime(05 / 05 / 12),
                    Gender = 'M'.ToString()
                };
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                var initial = db.Customers.ToList().Count();
                _crudManager.DeleteCustomer("JCRED");
                var after = db.Customers.ToList().Count();
                Assert.AreEqual(initial - 1, after);
            }
        }

        [Test]
        public void WhenAGameIsRemoved_TheyAreNoLongerInTheDB() {
            using (var db = new GamingContext())
            {
                var newGame = new Game()
                {
                    GameId = "WATCHPS4",
                    ConsoleId = 1,
                    GenreId = 1,
                    Title = "Watchdog",
                    AgeRating = 12,
                    Price = (decimal)27.99,
                    Publisher = "Ubisoft",
                    ReleaseDate = new System.DateTime(01 / 01 / 2021),
                    Multiplayers = 32
                };

                db.Games.Add(newGame);
                db.SaveChanges();
                var initial = db.Games.ToList().Count();
                _crudManager.DeleteGame("WATCHPS4");
                var after = db.Games.ToList().Count();
                Assert.AreEqual(initial - 1, after);
            }
        }

        [Test]
        public void WhenAGenreIsRemoved_TheyAreNoLongerInTheDB() {
            using (var db = new GamingContext()) {
                var newGenre = new Genre()
                {
                    GenreId = 5,
                    GenreName="Adventure"
                };
                db.Genres.Add(newGenre);
                db.SaveChanges();
                var initial = db.Genres.Count();
                _crudManager.DeleteGenre(5);
                var after = db.Genres.ToList().Count();
                Assert.AreEqual(initial - 1, after);
            }
        }

        [Test]
        public void WhenAConsoleIsRemoved_TheyAreNoLongerInTheDB() {
            using (var db = new GamingContext()) {
                var newConsole = new Console() {
                    ConsoleId = 10,
                    ConsoleName = "WiiLite",
                    Manufacturer = "Nintendo",
                    OnlineCompatible = "Y"
                };
                db.Consoles.Add(newConsole);
                db.SaveChanges();
                var initial = db.Consoles.Count();
                _crudManager.DeleteConsole(10);
                var after = db.Consoles.ToList().Count();
                Assert.AreEqual(initial - 1, after);
            }
        }

        [Test]
        public void WhenAnOrderIsRemoved_TheyAreNoLongerInTheDB() {
            using (var db = new GamingContext()) {
                var newCustomer = new Customer()
                {
                    CustomerId = "JCRED",
                    FirstName = "Justin",
                    LastName = "Credible",
                    Email = "JCredible20@hotmail.co.uk",
                    HouseNum = 12,
                    FirstLineAddress = "Crud Street",
                    SecondLineAddress = "Miscellaneous Avenue",
                    City = "Birmingham",
                    Postcode = "BC45 RG",
                    Country = "Brazil",
                    Mobile = "+18575736278",
                    Dob = new System.DateTime(05 / 05 / 12),
                    Gender = 'M'.ToString()
                };

                var newGame = new Game()
                {
                    GameId = "WATCHPS4",
                    ConsoleId = 1,
                    GenreId = 1,
                    Title = "Watchdog",
                    AgeRating = 12,
                    Price = (decimal)27.99,
                    Publisher = "Ubisoft",
                    ReleaseDate = new System.DateTime(01 / 01 / 2021),
                    Multiplayers = 32
                };

                db.Customers.Add(newCustomer);
                db.Games.Add(newGame);
                db.SaveChanges();

                var newOrder = new Order() {
                    OrderId = 4,
                    CustomerId = newCustomer.CustomerId,
                    GameId = newGame.GameId,
                    OrderDate = System.DateTime.Now,
                    DeliveryDate = System.DateTime.Now.AddDays(3),
                    Cost = newGame.Price
                };
                db.Orders.Add(newOrder);
                db.SaveChanges();
                var initial = db.Orders.Count();
                _crudManager.DeleteOrder(4);
                var after = db.Orders.ToList().Count();
                Assert.AreEqual(initial - 1, after);
            }
        }

        // Updating Records
        //[Test]
        //public void CustomerDetailsChanged() {
        //    using (var db = new GamingContext()) {
        //        var newCustomer = new Customer() {
        //            CustomerId = "JCRED",
        //            FirstName = "Justin",
        //            LastName = "Credible",
        //            Email = "JCredible20@hotmail.co.uk",
        //            HouseNum = 12,
        //            FirstLineAddress = "Crud Street",
        //            SecondLineAddress = "Miscellaneous Avenue",
        //            City = "Birmingham",
        //            Postcode = "BC45 RG",
        //            Country = "Brazil",
        //            Mobile = "+18575736278",
        //            Dob = new System.DateTime(05 / 05 / 12),
        //            Gender = 'M'.ToString()
        //        };
        //        db.Customers.Add(newCustomer);
        //        db.SaveChanges();
        //        _crudManager.UpdateCustomer("JCRED", "Justine", "Littlewood", "DCredible23@gmil.com", 10, "Sparta Street", "WPF Avenue", "Birmingham", "Wales", "ADR82 KL", "+774329328", new System.DateTime(06 / 08 / 12), 'F');
        //        var SelectedCustomer = db.Customers.Where(c => c.CustomerId == "JCRED").FirstOrDefault();
        //        Assert.AreEqual("Justine", SelectedCustomer.FirstName);
        //        Assert.AreEqual("Littlewood", SelectedCustomer.LastName);
        //        Assert.AreEqual("DCredible23@gmail.com", SelectedCustomer.Email);
        //        Assert.AreEqual(10, SelectedCustomer.HouseNum);
        //        Assert.AreEqual("Sparta Street", SelectedCustomer.FirstLineAddress);
        //        Assert.AreEqual("WPF Avenue", SelectedCustomer.SecondLineAddress);
        //        Assert.AreEqual("Birmingham", SelectedCustomer.City);
        //        Assert.AreEqual("ADR82 KL", SelectedCustomer.Postcode);
        //        Assert.AreEqual("Wales", SelectedCustomer.Country);
        //        Assert.AreEqual("+774329328", SelectedCustomer.Mobile);
        //        Assert.AreEqual(new System.DateTime(06 / 08 / 12), SelectedCustomer.Dob);
        //        Assert.AreEqual("F", SelectedCustomer.Gender);

        //    }
        //}

        //[Test]
        //public void GameDetailsUpdated() {
        //    using (var db = new GamingContext())
        //    {
        //        var newGame = new Game()
        //        {
        //            GameId = "WATCHPS4",
        //            ConsoleId = 1,
        //            GenreId = 1,
        //            Title = "Watchdog",
        //            AgeRating = 12,
        //            Price = (decimal)27.99,
        //            Publisher = "Ubisoft",
        //            ReleaseDate = new System.DateTime(01 / 01 / 2021),
        //            Multiplayers = 32
        //        };

        //        db.Games.Add(newGame);
        //        db.SaveChanges();
        //        _crudManager.UpdateGame("WATCHPS4", 1,1, "Watchdog 3", 16, (decimal)29.99, "Ubisoft", new System.DateTime(01 / 01 / 2021), 8);
        //        var SelectedGame = db.Games.Where(g => g.GameId == "WATCHPS4").FirstOrDefault();
        //        Assert.AreEqual(1, SelectedGame.ConsoleId);
        //        Assert.AreEqual(1, SelectedGame.GenreId);
        //        Assert.AreEqual("Watchdog 3", SelectedGame.Title);
        //        Assert.AreEqual(16, SelectedGame.AgeRating);
        //        Assert.AreEqual((decimal)29.99, SelectedGame.Price);
        //        Assert.AreEqual("Ubisoft", SelectedGame.Publisher);
        //        Assert.AreEqual(new System.DateTime(01 / 01 / 2021), SelectedGame.ReleaseDate);
        //        Assert.AreEqual(8, SelectedGame.Multiplayers);
        //    }
        //}
    }
}