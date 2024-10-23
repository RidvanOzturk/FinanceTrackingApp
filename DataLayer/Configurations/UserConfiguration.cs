using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataLayer.Entities;

namespace DataLayer.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(u => u.PasswordHash)
               .IsRequired();

        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasMany(u => u.IncomeList)
               .WithOne(i => i.User)
               .HasForeignKey(i => i.UserId);

        builder.HasMany(u => u.ExpenseList)
               .WithOne(e => e.User)
               .HasForeignKey(e => e.UserId);
    }
}
