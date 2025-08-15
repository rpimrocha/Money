using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Money.Api.Data.Mappings.Identity
{
    public class IdentityUserLoginMapping : IEntityTypeConfiguration<IdentityUserLogin<long>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<long>> builder)
        {
            builder.ToTable("IdentityUserLogin");
            builder.HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });
            builder.Property(ul => ul.LoginProvider).HasMaxLength(255);
            builder.Property(ul => ul.ProviderKey).HasMaxLength(255);
            builder.Property(ul => ul.ProviderDisplayName).HasMaxLength(255);
        }
    }
}
