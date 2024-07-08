using Microsoft.EntityFrameworkCore;

namespace HNG_Backend_Stage_Two_User_Auth.Models;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : DbContext(contextOptions)
{
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
        .Property(e => e.UserId)
        .HasDefaultValueSql("'U' || LPAD(NEXTVAL('user_id_seq')::TEXT, 5, '0')");


        modelBuilder.Entity<User>()
        .HasKey(e => e.UserId);


        modelBuilder.Entity<User>()
        .HasIndex(e => e.Email)
        .IsUnique();
    }
}


