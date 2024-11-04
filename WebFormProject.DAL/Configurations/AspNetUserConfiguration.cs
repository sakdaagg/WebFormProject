using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebFromProject.Entities.Entities;

namespace WebFormProject.DAL.Configurations;

public class AspNetUserConfiguration : IEntityTypeConfiguration<AspNetUser>
{
    public void Configure(EntityTypeBuilder<AspNetUser> builder)
    {

        builder.HasKey(k => k.Id);

        builder.HasMany(k => k.Forms)
            .WithOne(k => k.CreatedBy).HasForeignKey(k => k.CreatedById)
            .HasPrincipalKey(k => k.Id).OnDelete(DeleteBehavior.Cascade);
    }
}
