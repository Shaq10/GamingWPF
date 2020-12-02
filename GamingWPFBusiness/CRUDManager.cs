using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GamingWPF;

namespace GamingWPFBusiness
{
    public class CRUDManager
    {
        static void Main(string[] args)
        {
            
        }

        // Selecting Entities
        public GamingWPF.Console SelectedConsole { get; set; }
        public Genre SelectedGenre { get; set; }
        public Game SelectedGame { get; set; }
        public Customer SelectedCustomer { get; set; }
        public Order SelectedOrder { get; set; }

        public void SetSelectedConsole(object selectedConsole) {
            SelectedConsole = (GamingWPF.Console)selectedConsole;
        }

        public void SetSelectedGenre(object selectedGenre)
        {
            SelectedGenre = (Genre)selectedGenre;
        }

        public void SetSelectedGame(object selectedGame)
        {
            SelectedGame = (Game)selectedGame;
        }

        public void SetSelectedCustomer(object selectedCustomer)
        {
            SelectedCustomer = (Customer)selectedCustomer;
        }

        public void SetSelectedOrder(object selectedOrder)
        {
            SelectedOrder = (Order)selectedOrder;
        }

        // Retrieving Entities

        public List<GamingWPF.Console> RetrieveAllConsoles() {
            using (var db = new GamingContext()) {
                return db.Consoles.ToList();
            }
        }
        public List<Genre> RetrieveAllGenres()
        {
            using (var db = new GamingContext())
            {
                return db.Genres.ToList();
            }
        }
        public List<Game> RetrieveAllGames()
        {
            using (var db = new GamingContext())
            {
                return db.Games.ToList();
            }
        }

        public List<Customer> RetrieveAllCustomers()
        {
            using (var db = new GamingContext())
            {
                return db.Customers.ToList();
            }
        }
        public List<Order> RetrieveAllOrders()
        {
            using (var db = new GamingContext())
            {
                return db.Orders.ToList();
            }
        }

        // Creating Entities

        public void CreateConsole(string consoleName, string manufacturer, char online) {
            using (var db = new GamingContext()) {
                var newConsole = new GamingWPF.Console() {
                    ConsoleName = consoleName.Trim(),
                    Manufacturer = manufacturer.Trim(),
                    OnlineCompatible = online.ToString()
                };

                db.Add(newConsole);
                db.SaveChanges();
            }
        }

        public void CreateGenre(string genreName)
        {
            using (var db = new GamingContext())
            {
                var newGenre = new Genre()
                {
                    GenreName = genreName.Trim()
                };
                db.Add(newGenre);
                db.SaveChanges();
            }
        }

        public void CreateGame(string gameID, int consoleID, int genreID, string title, int age, 
            decimal price, string publisher, DateTime release, int multi) {
            using (var db = new GamingContext()) {
                var newGame = new Game()
                {
                    GameId = gameID.Trim(),
                    ConsoleId = consoleID,
                    GenreId = genreID,
                    Title = title.Trim(),
                    AgeRating = age,
                    Price = price,
                    Publisher = publisher.Trim(),
                    ReleaseDate = release,
                    Multiplayers = multi
                };
                db.Add(newGame);
                db.SaveChanges();
            }
        }

        public void CreateCustomer(string customerID, string firstName, string lastName, string email, int houseNum, string firstLineAddress, 
            string secondLineAddress, string city, string postcode, string country, string mobile, DateTime dob, char gender) {
            using (var db = new GamingContext()) {
                var newCustomer = new Customer()
                {
                    CustomerId = customerID.Trim(),
                    FirstName = firstName.Trim(),
                    LastName = lastName.Trim(),
                    Email = email.Trim(),
                    HouseNum = houseNum,
                    FirstLineAddress = firstLineAddress.Trim(),
                    SecondLineAddress = secondLineAddress.Trim(),
                    City = city.Trim(),
                    Postcode = postcode.Trim(),
                    Country = country.Trim(),
                    Mobile = mobile.Trim(),
                    Dob = dob,
                    Gender = gender.ToString()
                };

                db.Add(newCustomer);
                db.SaveChanges();
            }
        }

        public void CreateOrder(string customerID, string gameID, DateTime orderDate, DateTime deliveryDate, decimal cost) {
            using (var db = new GamingContext()){
                var newOrder = new Order() {
                    CustomerId = customerID.Trim(),
                    GameId = gameID.Trim(),
                    OrderDate = orderDate,
                    DeliveryDate = deliveryDate,
                    Cost = cost
                };
                db.Add(newOrder);
                db.SaveChanges();
            }
        }



    }
}
