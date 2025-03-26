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
        }
    }
}
