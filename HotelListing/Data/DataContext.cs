using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {}
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        // Seeding some data into tha database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                    new Country 
                    { 
                        Id = 1,
                        Name = "Jamaica",
                        ShortName = "JM"
                    },
                    new Country
                    {
                        Id = 2,
                        Name = "Bahamas",
                        ShortName = "BS"
                    },
                    new Country
                    {
                        Id = 3,
                        Name = "Cayman Island",
                        ShortName = "CI"
                    }
                );

            modelBuilder.Entity<Hotel>().HasData(
                    new Hotel
                    {
                        Id = 1,
                        Name = "Sandals Resort & Spa",
                        Address = "Negril",
                        CountryId = 1,
                        Rating = 4.5
                        
                    },
                    new Hotel
                    {
                        Id = 2,
                        Name = "Comfort Suites",
                        Address = "George Town",
                        CountryId = 3,
                        Rating = 4.3
                    },
                    new Hotel
                    {
                        Id = 3,
                        Name = "Grand Palladium",
                        Address = "Nassua",
                        CountryId = 2,
                        Rating = 4.0
                    }
                );
        }

      
    }
}
