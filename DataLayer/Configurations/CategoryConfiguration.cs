using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataLayer.Entities;

namespace DataLayer.Configurations;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.Type)
               .IsRequired();

        builder.HasMany(c => c.Incomes)
               .WithOne(i => i.Category)
               .HasForeignKey(i => i.CategoryId);

        builder.HasMany(c => c.Expenses)
               .WithOne(e => e.Category)
               .HasForeignKey(e => e.CategoryId);
    }
}
