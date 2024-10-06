using Microsoft.EntityFrameworkCore;
using PennyWise.Data.Models;

namespace PennyWise.Data;

public partial class PennyWiseDbContext:DbContext
{
    public PennyWiseDbContext() 
    {
    }

    public PennyWiseDbContext(DbContextOptions<PennyWiseDbContext> options) : base(options) { }

    //insert dbset for models here
    public virtual DbSet<Expense> Expenses { get; set; }

    //insert rules / properties for your models here
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>(entity =>
        {
            entity.ToTable("Expense");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.ExpenseTitle)
                .IsRequired()  
                .HasMaxLength(100); 

            entity.Property(e => e.Category)
                .IsRequired()  
                .HasMaxLength(50); 

            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .IsRequired(); 

            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("GETDATE()"); 
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
