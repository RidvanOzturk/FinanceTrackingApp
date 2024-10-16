using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class FinanceContext(DbContextOptions<FinanceContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.IncomeList)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ExpenseList)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Category>().HasData(
              new Category { Id = Guid.NewGuid(), Name = "Salary", Type = "Income" },
              new Category { Id = Guid.NewGuid(), Name = "Rental Income", Type = "Income" },
              new Category { Id = Guid.NewGuid(), Name = "Investment Income", Type = "Income" },
              new Category { Id = Guid.NewGuid(), Name = "Other Income", Type = "Income" },

              new Category { Id = Guid.NewGuid(), Name = "Rent Expense", Type = "Expense" },
              new Category { Id = Guid.NewGuid(), Name = "Education Expense", Type = "Expense" },
              new Category { Id = Guid.NewGuid(), Name = "Entertainment Expense", Type = "Expense" },
              new Category { Id = Guid.NewGuid(), Name = "Car Expense", Type = "Expense" },
              new Category { Id = Guid.NewGuid(), Name = "Other Expenses", Type = "Expense" });

            base.OnModelCreating(modelBuilder);

        }
    }

}
