using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class MilestoneConfig : IEntityTypeConfiguration<Milestone>
    {
        public void Configure(EntityTypeBuilder<Milestone> builder)
        {
            builder.Property(m => m.Descriptions)
                .IsRequired();

            builder.Property(m => m.Date)
                .IsRequired();

            builder.HasOne(m => m.Pregnancy)
                .WithMany(p => p.Milestones)
                .HasForeignKey(m => m.PregnancyId);
        }
    }
}
