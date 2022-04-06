using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Practical_16.Configuration.Entities
{
    internal class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId= "8e7214b3-23c6-4171-98ce-0910174f0482",
                    UserId= "ea4283d3-e8ec-4f23-ad9f-8629f31bd79e"
                },
                  new IdentityUserRole<string>
                  {
                      RoleId = "d60900d1-4f53-4f00-9f3e-530a7b5772ac",
                      UserId = "6d44dff0-acdf-444a-b255-6c3565f89c3a"
                  }
            );
        }
    }
}