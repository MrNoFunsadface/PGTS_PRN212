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

            builder.HasData(
                new Milestone
                {
                    Id = 1,
                    PregnancyId = 1,
                    Descriptions = "First Trimester",
                    Date = new DateTime(2021, 1, 1)
                },
                new Milestone
                {
                    Id = 2,
                    PregnancyId = 1,
                    Descriptions = "Second Trimester",
                    Date = new DateTime(2021, 4, 1)
                },
                new Milestone
                {
                    Id = 3,
                    PregnancyId = 1,
                    Descriptions = "Third Trimester",
                    Date = new DateTime(2021, 7, 1)
                }
            );
        }
    }
}
