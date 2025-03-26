using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.isAdmin)
                .IsRequired();

            builder.HasMany(u => u.Pregnancies)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@example.com",
                    Password = "Admin@123",
                    isAdmin = true,
                },
                new User
                {
                    Id = 2,
                    Name = "Elizabeth Taylor",
                    Email = "user1@example.org",
                    Password = "User1@123",
                    isAdmin = false,
                },
                new User
                {
                    Id = 3,
                    Name = "Victoria Beckham",
                    Email = "user2@example.org",
                    Password = "User2@123",
                    isAdmin = false,
                }
            );
        }
    }
}
