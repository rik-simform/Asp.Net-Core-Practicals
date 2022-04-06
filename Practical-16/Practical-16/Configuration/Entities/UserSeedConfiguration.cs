using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practical_16.Models;
using System.Text;

namespace Practical_16.Configuration.Entities
{
    internal class UserSeedConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            var hasher = new PasswordHasher<Users>();
            builder.HasData(
               new Users
               {
                   Id = "ea4283d3-e8ec-4f23-ad9f-8629f31bd79e",
                   Email = "Admin@email.com",
                   NormalizedEmail = "ADMIN@EMAIL.COM",
                   firstname = "system",
                   lastname = "admin",
                   PasswordHash = hasher.HashPassword(null, "Admin@123")
               },
                   new Users
                   {
                       Id = "6d44dff0-acdf-444a-b255-6c3565f89c3a",
                       Email = "Admin@email.com",
                       NormalizedEmail = "ADMIN@EMAIL.COM",
                       firstname = "system",
                       lastname = "admin",
                       PasswordHash = hasher.HashPassword(null, "Admin@123")
                   }

               ) ;
        }
    }
}