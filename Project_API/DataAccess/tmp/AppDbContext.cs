using Microsoft.EntityFrameworkCore;
using application.DataAccess.Models;
using API_Project.DataAccess.Models;
using System.ComponentModel.DataAnnotations;
//using static System.Runtime.InteropServices.JavaScript.JSType;



namespace application.DataAccess
{



    public class AppDbContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<PropertyImage> propertyImages { get; set; }



        
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                    => optionsBuilder.UseSqlServer("Data Source=DESKTOP-5JC2MA4\\SQLEXPRESS;Initial Catalog=Real_Estate_Db;Integrated Security=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //start
            base.OnModelCreating(modelBuilder);
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
            //modelBuilder.Entity<Property>()
            //    .HasOne(p => p.User)
            //    .WithMany(u => u.Properties)
            //    .HasForeignKey(p => p.UserId);

            //modelBuilder.Entity<Inquiry>()
            //    .HasOne(i => i.Property)
            //    .WithMany(p => p.Inquiries)
            //    .HasForeignKey(i => i.PropertyId);

            //modelBuilder.Entity<Inquiry>()
            //    .HasOne(i => i.User)
            //    .WithMany(u => u.Inquiries)
            //    .HasForeignKey(i => i.UserId);

            modelBuilder.Entity<User>()
                .Property(u => u.FullName)
                .HasComputedColumnSql("[F_Name] + ' ' + [L_Name]");

            modelBuilder.Entity<User>()
                .HasIndex(d => d.PhoneNumber)
                .IsUnique();           
        }
        //public override int SaveChanges()
        //{

        //    var Entities = from e in ChangeTracker.Entries()
        //                   where e.State == EntityState.Modified ||
        //                   e.State == EntityState.Added
        //                   select e.Entity;

        //    foreach (var Entity in Entities)
        //    {
        //        ValidationContext validationContext = new ValidationContext(Entity);
        //        Validator.ValidateObject(Entity, validationContext, true);
        //    }

        //    return base.SaveChanges();
        //}
    }

}
