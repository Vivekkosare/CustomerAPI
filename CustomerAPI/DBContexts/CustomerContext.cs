using CustomerAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CustomerAPI.DBContexts
{
    public class CustomerContext : DbContext
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

            modelBuilder.Entity<Address>().HasData(new Address { CountryId = Guid.Parse("991e0c2f-a768-40b9-9eaa-b7c31eb3fcc4"), ZipCode = 15132, AddressId = Guid.Parse("78cebe6c-6dac-403e-82bd-43f3142ea805"), CustomerId = Guid.Parse("e2c46906-2ea4-4672-a81f-bd69890c9b16") },
                new Address { CountryId = Guid.Parse("ba2dc307-32bf-4d24-8cd2-45f070975889"), ZipCode = 04268, AddressId = Guid.Parse("a02b03b7-36cb-4839-911c-f782bb3009e9"), CustomerId = Guid.Parse("21d937d1-f020-4e4f-9f26-add9801b6e75") },
                new Address { CountryId = Guid.Parse("0f72123d-6095-490e-a051-6bb7fbcbc010"), ZipCode = 30415, AddressId = Guid.Parse("5c3ac12f-ec83-449e-a37e-de7442cde7da"), CustomerId = Guid.Parse("5cee819a-f78d-49a9-866e-b69aba44c4f4") },
                new Address { CountryId = Guid.Parse("01d942ed-522e-4e5f-908b-cae029c820d7"), ZipCode = 55603, AddressId = Guid.Parse("b84178a0-b0ff-4721-96cc-5d271d93f6b9"), CustomerId = Guid.Parse("fbf6dc01-93f9-4772-891f-46e5a79d6e2a") });

            modelBuilder.Entity<PhoneNumber>().HasData(new PhoneNumber { CountryId = Guid.Parse("991e0c2f-a768-40b9-9eaa-b7c31eb3fcc4"), Phone = "7455535", PhoneId = Guid.Parse("540c9172-2391-4990-8503-985083ae34e8"), CustomerId = Guid.Parse("e2c46906-2ea4-4672-a81f-bd69890c9b16") },
                new PhoneNumber { CountryId = Guid.Parse("ba2dc307-32bf-4d24-8cd2-45f070975889"), Phone = "60555269", PhoneId = Guid.Parse("bdbcc5c5-1b8f-45b1-be22-6f6bad98308e"), CustomerId = Guid.Parse("21d937d1-f020-4e4f-9f26-add9801b6e75") },
                new PhoneNumber { CountryId = Guid.Parse("0f72123d-6095-490e-a051-6bb7fbcbc010"), Phone = "95552843", PhoneId = Guid.Parse("1c8f1f5d-9d68-4019-98e3-87a9c5b9a55b"), CustomerId = Guid.Parse("5cee819a-f78d-49a9-866e-b69aba44c4f4") },
                new PhoneNumber { CountryId = Guid.Parse("01d942ed-522e-4e5f-908b-cae029c820d7"), Phone = "5005557352", PhoneId = Guid.Parse("173c9951-a374-4ba4-b5fe-29a894e48279"), CustomerId = Guid.Parse("fbf6dc01-93f9-4772-891f-46e5a79d6e2a") });

            //var converter = new ValueConverter<BigInteger, long>(
            //                                        model => (long)model,
            //                                        provider => new BigInteger(provider));

            //modelBuilder
            //    .Entity<Customer>()
            //    .Property(e => e.PersonalNumber)
            //    .HasConversion(converter);

            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = Guid.Parse("e2c46906-2ea4-4672-a81f-bd69890c9b16"), PersonalNumber = "199205251045", Email = "user1@domain.com" },
                new Customer { CustomerId = Guid.Parse("21d937d1-f020-4e4f-9f26-add9801b6e75"), PersonalNumber = "199307121428", Email = "user2@domain.com" },
                new Customer { CustomerId = Guid.Parse("5cee819a-f78d-49a9-866e-b69aba44c4f4"), PersonalNumber = "198904208493", Email = "user3@domain.com" },
                new Customer { CustomerId = Guid.Parse("fbf6dc01-93f9-4772-891f-46e5a79d6e2a"), PersonalNumber = "198602182748", Email = "user4@domain.com" });


            base.OnModelCreating(modelBuilder);
        }
    }
}
