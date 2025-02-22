using Microsoft.EntityFrameworkCore;
using BookManagementApi.Models;
using System.Collections.Generic;
using BookManagementApi.Handlers;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BookManagementApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            _ = modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "Daviti",
                    PasswordHash = PasswordHashHandler.HashPassword("daviti123")
                }
                );
        }
    }
}
