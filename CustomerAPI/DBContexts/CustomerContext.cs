using CustomerAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAPI.DBContexts
{
    class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = Guid.Parse("991e0c2f-a768-40b9-9eaa-b7c31eb3fcc4"), CountryName = "Sweden", CountryCode = "+46" },
                new Country { CountryId = Guid.Parse("ba2dc307-32bf-4d24-8cd2-45f070975889"), CountryName = "Denmark", CountryCode = "+45" },
                new Country { CountryId = Guid.Parse("0f72123d-6095-490e-a051-6bb7fbcbc010"), CountryName = "Norway", CountryCode = "+47" },
                new Country { CountryId = Guid.Parse("01d942ed-522e-4e5f-908b-cae029c820d7"), CountryName = "Finland", CountryCode = "+358" });

            modelBuilder.Entity<Address>().HasData(new Address { CountryId = Guid.Parse("991e0c2f-a768-40b9-9eaa-b7c31eb3fcc4"), ZipCode = 15132, AddressId = Guid.Parse("78cebe6c-6dac-403e-82bd-43f3142ea805") },
                new Address { CountryId = Guid.Parse("ba2dc307-32bf-4d24-8cd2-45f070975889"), ZipCode = 04268, AddressId = Guid.Parse("a02b03b7-36cb-4839-911c-f782bb3009e9") },
                new Address { CountryId = Guid.Parse("0f72123d-6095-490e-a051-6bb7fbcbc010"), ZipCode = 30415, AddressId = Guid.Parse("5c3ac12f-ec83-449e-a37e-de7442cde7da") },
                new Address { CountryId = Guid.Parse("01d942ed-522e-4e5f-908b-cae029c820d7"), ZipCode = 55603, AddressId = Guid.Parse("b84178a0-b0ff-4721-96cc-5d271d93f6b9") });

            modelBuilder.Entity<PhoneNumber>().HasData(new PhoneNumber { CountryId = Guid.Parse("991e0c2f-a768-40b9-9eaa-b7c31eb3fcc4"), Phone = "7455535", PhoneId = Guid.Parse("540c9172-2391-4990-8503-985083ae34e8") },
                new PhoneNumber { CountryId = Guid.Parse("ba2dc307-32bf-4d24-8cd2-45f070975889"), Phone = "60555269", PhoneId = Guid.Parse("bdbcc5c5-1b8f-45b1-be22-6f6bad98308e") },
                new PhoneNumber { CountryId = Guid.Parse("0f72123d-6095-490e-a051-6bb7fbcbc010"), Phone = "95552843", PhoneId = Guid.Parse("1c8f1f5d-9d68-4019-98e3-87a9c5b9a55b") },
                new PhoneNumber { CountryId = Guid.Parse("01d942ed-522e-4e5f-908b-cae029c820d7"), Phone = "5005557352", PhoneId = Guid.Parse("173c9951-a374-4ba4-b5fe-29a894e48279") });

            modelBuilder.Entity<Customer>().HasData(new Customer { PersonalNumber = 199205251045, Email = "user1@domain.com", PhoneId = Guid.Parse("540c9172-2391-4990-8503-985083ae34e8"), AddressId = Guid.Parse("78cebe6c-6dac-403e-82bd-43f3142ea805") },
                new Customer { PersonalNumber = 199307121428, Email = "user2@domain.com", PhoneId = Guid.Parse("bdbcc5c5-1b8f-45b1-be22-6f6bad98308e"), AddressId = Guid.Parse("a02b03b7-36cb-4839-911c-f782bb3009e9") },
                new Customer { PersonalNumber = 198904208493, Email = "user3@domain.com", PhoneId = Guid.Parse("1c8f1f5d-9d68-4019-98e3-87a9c5b9a55b"), AddressId = Guid.Parse("5c3ac12f-ec83-449e-a37e-de7442cde7da") },
                new Customer { PersonalNumber = 198602182748, Email = "user4@domain.com", PhoneId = Guid.Parse("173c9951-a374-4ba4-b5fe-29a894e48279"), AddressId = Guid.Parse("b84178a0-b0ff-4721-96cc-5d271d93f6b9") });

            base.OnModelCreating(modelBuilder);
        }
    }
}
