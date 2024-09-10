using Microsoft.EntityFrameworkCore;
using application.DataAccess.Models;
using API_Project.DataAccess.Models;
using System.ComponentModel.DataAnnotations;



namespace application.DataAccess
{
    


    public class AppDbContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<Favorite> Favorites { get; set; }



        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                    => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Real_Estate_Db;Integrated Security=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>()
                .HasOne(p => p.Owner)
                .WithMany(u => u.Properties)
                .HasForeignKey(p => p.OwnerId);

            modelBuilder.Entity<Inquiry>()
                .HasOne(i => i.Property)
                .WithMany(p => p.Inquiries)
                .HasForeignKey(i => i.PropertyId);

            modelBuilder.Entity<Inquiry>()
                .HasOne(i => i.User)
                .WithMany(u => u.Inquiries)
                .HasForeignKey(i => i.UserId);

            modelBuilder.Entity<User>()
               .HasIndex(d => d.PhoneNumber)
               .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.FullName)
                .HasComputedColumnSql("[F_Name] + ' ' + [L_Name]");

            modelBuilder.Entity<User>()
                .HasIndex(d => d.PhoneNumber)
                .IsUnique();

        }
        public override int SaveChanges()
        {

            var Entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Modified ||
                           e.State == EntityState.Added 
                           select e.Entity;

            foreach (var Entity in Entities)
            {
                ValidationContext validationContext = new ValidationContext(Entity);
                Validator.ValidateObject(Entity, validationContext, true);
            }

            return base.SaveChanges();
        }
    }

}
