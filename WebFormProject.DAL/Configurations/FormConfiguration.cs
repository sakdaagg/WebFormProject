using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebFromProject.Entities.Entities;

namespace WebFormProject.DAL.Configurations;

public class FormConfiguration : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(k => k.Name).IsRequired().HasMaxLength(200);

        builder.HasMany(k => k.Fields)
           .WithOne(k => k.Form).HasForeignKey(k => k.FormId)
           .HasPrincipalKey(k => k.Id).OnDelete(DeleteBehavior.Cascade);
    }
}
