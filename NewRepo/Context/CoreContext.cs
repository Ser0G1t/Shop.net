using Microsoft.EntityFrameworkCore;
using NewRepo.Entity;

namespace NewRepo.Context
{
    public class CoreContext : DbContext
    {
        private readonly static string CONNECTION_STRING = "Server=(localdb)\\mssqllocaldb;Database=MyBoardsDb;Trusted_Connection=True;";
        public DbSet<Product> products { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<Invoice> invoice { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>();
            modelBuilder.Entity<Invoice>();

            modelBuilder.Entity<Order>()
                .HasMany(el => el.products).WithMany(el => el.orders);
            //.OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>()
                .HasOne(el => el.Invoice).WithOne(el => el.order)
                .HasForeignKey<Order>(el => el.InvoiceId);
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().Property(el => el.email).IsRequired();
            modelBuilder.Entity<Role>().Property(el => el.roleName).IsRequired();


        }
    }
}
