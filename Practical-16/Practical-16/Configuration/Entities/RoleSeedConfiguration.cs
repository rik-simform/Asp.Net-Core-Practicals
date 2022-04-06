using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practical_16.Models;

namespace Practical_16.Configuration.Entities
{
    internal class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "8e7214b3-23c6-4171-98ce-0910174f0482",
                    Name = Roles.Admin,
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "d60900d1-4f53-4f00-9f3e-530a7b5772ac",
                    Name = Roles.User,
                    NormalizedName = "USER"
                }
             );

          
        }
    }
}