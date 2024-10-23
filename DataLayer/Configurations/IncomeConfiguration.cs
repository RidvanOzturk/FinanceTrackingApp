using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations;

public class IncomeConfiguration : IEntityTypeConfiguration<Income>
{
    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.ToTable("Incomes");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Amount)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(i => i.Date)
               .IsRequired();

        builder.HasOne(i => i.User)
               .WithMany(u => u.IncomeList)
               .HasForeignKey(i => i.UserId);

        builder.HasOne(i => i.Category)
               .WithMany(c => c.Incomes)
               .HasForeignKey(i => i.CategoryId);
    }
}