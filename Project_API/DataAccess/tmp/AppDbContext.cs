using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataContext
{
    internal class AppDbContext : DbContext
    {
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-5JC2MA4\\SQLEXPRESS;Initial Catalog=FinalRealEstateDb;Integrated Security=True;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Restrict delete on UserId to avoid multiple cascade paths
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict on UserId

            // Cascade delete on PropertyId to remove Favorites when a Property is deleted
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Property)
                .WithMany(p => p.Favorites)
                .HasForeignKey(f => f.PropertyId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade on PropertyId

            // Repeat similar logic for Inquiries if needed
            modelBuilder.Entity<Inquiry>()
                .HasOne(i => i.User)
                .WithMany(u => u.Inquiries)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict on UserId

            modelBuilder.Entity<Inquiry>()
                .HasOne(i => i.Property)
                .WithMany(p => p.Inquiries)
                .HasForeignKey(i => i.PropertyId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade on PropertyId

            base.OnModelCreating(modelBuilder);

            //start
            List<Amenities> amenities = new List<Amenities>();
            for (int i = 1; i <= Math.Pow(2, 10); i++)
            {
                Amenities amenity = new Amenities();
                int number = i - 1;
                string binaryString = Convert.ToString(number, 2);
                string binaryStringPaded = binaryString.PadLeft(10, '0');
                //1 = 00-0000-0001
                amenity.Id = i;
                amenity.HasGarage = binaryStringPaded[9] == '1';
                amenity.Two_Stories = binaryStringPaded[8] == '1';
                amenity.Laundry_Room = binaryStringPaded[7] == '1';
                amenity.HasPool = binaryStringPaded[6] == '1';
                amenity.HasGarden = binaryStringPaded[5] == '1';
                amenity.HasElevator = binaryStringPaded[4] == '1';
                amenity.HasBalcony = binaryStringPaded[3] == '1';
                amenity.HasParking = binaryStringPaded[2] == '1';
                amenity.HasCentralHeating = binaryStringPaded[1] == '1';
                amenity.IsFurnished = binaryStringPaded[0] == '1';

                amenities.Add(amenity);
            }
            modelBuilder.Entity<Amenities>().HasData(amenities);
            //end
            modelBuilder.Entity<User>()
               .HasIndex(d => d.PhoneNumber)
               .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.FullName)
                .HasComputedColumnSql("[F_Name] + ' ' + [L_Name]");
        }
    }
}
