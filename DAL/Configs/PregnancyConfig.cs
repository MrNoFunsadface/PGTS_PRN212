using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class PregnancyConfig : IEntityTypeConfiguration<Pregnancy>
    {
        public void Configure(EntityTypeBuilder<Pregnancy> builder)
        {
            builder.Property(p => p.ConceptionDate)
                .IsRequired();

            builder.Property(p => p.DueDate)
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(u => u.Pregnancies)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.FetusDatas)
                .WithOne(fd => fd.Pregnancy)
                .HasForeignKey(fd => fd.PregnancyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Milestones)
                .WithOne(m => m.Pregnancy)
                .HasForeignKey(m => m.PregnancyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Pregnancy
                {
                    Id = 1,
                    ConceptionDate = new DateTime(2021, 1, 1),
                    DueDate = new DateTime(2021, 9, 1),
                    UserId = 2,
                },
                new Pregnancy
                {
                    Id = 2,
                    ConceptionDate = new DateTime(2021, 2, 1),
                    DueDate = new DateTime(2021, 10, 1),
                    UserId = 3,
                }
            );
        }
    }
}
