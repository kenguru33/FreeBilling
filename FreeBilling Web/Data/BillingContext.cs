using FreeBilling.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreeBilling.Data
{
    public class BillingContext : DbContext
    {
        private readonly IConfiguration _config;

        public BillingContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<TimeBill> TimeBills => Set<TimeBill>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = _config["ConnectionStrings:BillingDb"];
            
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Address>().HasData(new Address()
            {
                Id = 1,
                AddressLine1 = "123 Main Avenue",
                StateProvince = "Atlanta",
                PostalCode = "4625378"
            }, new Address()
            {
                Id = 2,
                AddressLine1 = "123 First Avenue",
                StateProvince = "GA",
                PostalCode = "123345"
            });
            
            modelBuilder.Entity<Customer>().HasData(new
                {
                    Id = 1,
                    CompanyName = "Smith Towing",
                    AddressId = 1,
                    Contact = "Jim",
                    PhoneNumer = "555-1212"
                },
                new
                {
                    Id = 2,
                    CompanyName = "Anker AS",
                    AddressId = 2,
                    Conatct = "Bernt",
                    PhoneNumer = "555-121122"
                });

            modelBuilder.Entity<Employee>().HasData(new Employee()
            {
                Id = 1,
                Name = "Kuken Johnson",
                BillingRate = 115f,
                ImageUrl = "/img/kuken.jpg",
                Email = "kuken@Johnson.com"
            }, new Employee()
            {
                Id = 2,
                Name = "Balla Jalla",
                BillingRate = 215f,
                ImageUrl = "/img/balla.jpg",
                Email = "balla@jalla.com"
            },new Employee()
            {
                Id = 3,
                Name = "Pinna Kristiansen",
                BillingRate = 110f,
                ImageUrl = "/img/pinna.jpg",
                Email = "pinna@PinnaK.com"
            }, new Employee()
            {
                Id = 4,
                Name = "Klysa Klausen",
                BillingRate = 234f,
                ImageUrl = "/img/.kkp.jpg",
                Email = "klys@klausen.com"
            });
        }
    }
}
