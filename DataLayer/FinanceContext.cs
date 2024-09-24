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
             new Category { Id = Guid.NewGuid(), Name = "Maaş", Type = "Gelir" },
             new Category { Id = Guid.NewGuid(), Name = "Kira Geliri", Type = "Gelir" },
             new Category { Id = Guid.NewGuid(), Name = "Yatırım Geliri", Type = "Gelir" },
             new Category { Id = Guid.NewGuid(), Name = "Diğer Gelirler", Type = "Gelir" },


             new Category { Id = Guid.NewGuid(), Name = "Kira Gideri", Type = "Gider" },
             new Category { Id = Guid.NewGuid(), Name = "Eğitim Gideri", Type = "Gider" },
             new Category { Id = Guid.NewGuid(), Name = "Eğlence Gideri", Type = "Gider" },
             new Category { Id = Guid.NewGuid(), Name = "Araba Gideri", Type = "Gider" },
             new Category { Id = Guid.NewGuid(), Name = "Diğer Giderler", Type = "Gider" }
            );
            base.OnModelCreating(modelBuilder);

        }
    }

}
