using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Classes
{
    internal class Context : DbContext
    {
        public Context() : base("database_gallery")
        {
        }
        
        public DbSet<Person> People { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Move_history> Move_Histories { get; set; }
        public DbSet<Position> Posiitions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("People");
            modelBuilder.Entity<Exhibition>().ToTable("Exhibitions");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Position>().ToTable("Positions");
            modelBuilder.Entity<Move_history>().ToTable("Move_histories");
            modelBuilder.Entity<Location>().ToTable("Locations");

            base.OnModelCreating(modelBuilder);
        }
    }
}