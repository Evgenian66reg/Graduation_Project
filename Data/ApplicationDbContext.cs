using AgricultDetailMarket.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;

namespace AgricultDetailMarket.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }

        


        //Создание администратора и модератора
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.HasData(new User[]
                {
                    new User()
                    {
                        Id = 1,
                        Email = "admin@mail.ru",
                        Password = Crypto.HashPassword("12345"),
                        Role = Role.Admin,
                    },
                    new User()
                    {
                        Id = 2,
                        Email = "moder@mail.ru",
                        Password = Crypto.HashPassword("54321"),
                        Role = Role.Moderator,
                    }
                    
                });

                builder.ToTable("Users").HasKey(x => x.Id);
                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x =>x.Email).HasMaxLength(100).IsRequired();
                builder.Property(x => x.Password).IsRequired();


                builder.HasOne(x => x.Basket).WithOne(x => x.User)
                .HasPrincipalKey<User>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Basket>(builder =>
            {
                builder.ToTable("Baskets").HasKey(x => x.Id);

                builder.HasData(new Basket()
                {
                    Id = 1,
                    UserId = 1,
                });
            });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.ToTable("Orders").HasKey(x => x.Id);

                builder.HasOne(b => b.Basket).WithMany(o => o.Orders)
                .HasForeignKey(f => f.BasketId);
            });
        }

        //Создание подключения к базе данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
