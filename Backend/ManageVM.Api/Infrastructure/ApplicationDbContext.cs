using Microsoft.EntityFrameworkCore;
using ManageVM.Api.Core.Entities;
using ManageVM.Api.Core.Enums;

namespace ManageVM.Api.Infrastructure
{
    public class ApplicationDbContext: DbContext     {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public  DbSet<VM> VM { get; set; }
        public  DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Configuración de la entidad VM
            modelBuilder.Entity<VM>(entity =>
            {
                entity.HasKey(vm => vm.Id);
                entity.Property(vm => vm.Name).IsRequired().HasMaxLength(100);
                entity.Property(vm => vm.Cores).IsRequired();
                entity.Property(vm => vm.RAM).IsRequired();
                entity.Property(vm => vm.Disk).IsRequired();
                entity.Property(vm => vm.OperatingSystem).IsRequired();
                entity.Property(vm => vm.OwnerId).IsRequired();

                entity.Property(vm => vm.CreatedAt)
                      .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(vm => vm.UpdatedAt)
                      .HasDefaultValueSql("GETUTCDATE()");
            });

            // Configuración básica para la entidad User
            modelBuilder.Entity<User>(entity =>
            {
              //  entity.HasKey(u => u.Id);
                entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Password).IsRequired();
                entity.Property(u => u.Role).IsRequired(); // "Admin" o "User"
            });

            var adminId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    Username = "UserAdmin",
                    Password = "12345",//BCrypt.Net.BCrypt.HashPassword("Admin123!"), // usa BCrypt o tu método de hash
                    Role = Role.Admin
                },
                new User
                {
                    Id = userId,
                    Username = "UserCliente",
                    Password = "12345",//BCrypt.Net.BCrypt.HashPassword("User123!"),
                    Role = Role.User
                }
            );

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<VM>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                    entry.Entity.UpdatedAt = now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
 
}
