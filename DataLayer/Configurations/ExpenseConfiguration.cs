using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataLayer.Entities;

namespace DataLayer.Configurations;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("Expenses");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Amount)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(e => e.Date)
               .IsRequired();

        builder.HasOne(e => e.User)
               .WithMany(u => u.ExpenseList)
               .HasForeignKey(e => e.UserId);

        builder.HasOne(e => e.Category)
               .WithMany(c => c.Expenses)
               .HasForeignKey(e => e.CategoryId);
    }
}