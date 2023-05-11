using DB_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace DB_CRUD.Contexts
{
    public class CrudDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public CrudDbContext(DbContextOptions<CrudDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Initialize(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void Initialize(ModelBuilder modelBuilder)
        {

            User user1 = new User
            {
                UserID = 1,
                FirstName = "Test1",
                LastName = "test1",
                DateOfBirth = new DateTime(2002, 12, 11),
                Login="redredred",
                Password="redredred",
                Gender="M"
            };

            User user2 = new User
            {
                UserID = 2,
                FirstName = "Test2",
                LastName = "test2",
                DateOfBirth = new DateTime(2000, 9, 15),
                Login = "blueblueblue",
                Password = "blueblueblue",
                Gender = "F"
            };

            User user3 = new User
            {
                UserID = 3,
                FirstName = "Test3",
                LastName = "test3",
                DateOfBirth = new DateTime(1998, 4, 15),
                Login = "blueblue",
                Password = "blueblue",
                Gender = "F"
            };


            modelBuilder.Entity<User>().HasData(new User[] { user1, user2, user3 });

            Order order1 = new Order
            {
                OrderID = 1,
                UserID = 1,
                OrderDate = DateTime.Now,
                OrderCost = 1,
                ItemsDescription = "red",
                ShippingAddress = "Lviv"
            };
            modelBuilder.Entity<Order>().HasData(new Order[] { order1 });
        }
    }
}

