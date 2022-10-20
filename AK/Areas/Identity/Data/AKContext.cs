using AK.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AK.Data;

public class AKContext : IdentityDbContext<AKUser>
{
    public AKContext(DbContextOptions<AKContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationAKDatabase());
    }
}

public class ApplicationAKDatabase : IEntityTypeConfiguration<AKUser>
{
    public void Configure(EntityTypeBuilder<AKUser> builder)
    {
        builder.Property(u => u.Name).HasMaxLength(200);
        
    }
}
