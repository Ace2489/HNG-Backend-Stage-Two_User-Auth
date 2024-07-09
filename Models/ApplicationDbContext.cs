using Microsoft.EntityFrameworkCore;

namespace HNG_Backend_Stage_Two_User_Auth.Models;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : DbContext(contextOptions)
{
    public DbSet<User> Users { get; set; }

    public DbSet<Organisation> Organisations { get; set; }
    
    public DbSet<UserOrganisation> UserOrganisations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("'U' || LPAD(NEXTVAL('user_id_seq')::TEXT, 5, '0')");
            entity.HasKey(e => e.UserId);
            entity.HasIndex(e => e.Email).IsUnique();
        });

        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.Property(e => e.OrgId)
                .HasDefaultValueSql("'ORG' || LPAD(NEXTVAL('organisation_id_seq')::TEXT, 5, '0')");
            entity.HasKey(e => e.OrgId);
        });

        modelBuilder.Entity<UserOrganisation>(entity =>
        {
            entity.HasKey(uc => new { uc.UserId, uc.OrgId });
            entity.ToTable("UserOrganisations");
            
            entity.HasOne(uc => uc.User)
                .WithMany(u => u.UserOrganisations)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(uc => uc.Organisation)
                .WithMany(c => c.UserOrganisations)
                .HasForeignKey(uc => uc.OrgId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }


}


