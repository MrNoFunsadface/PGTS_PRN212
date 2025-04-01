using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

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

            var milestones = LoadMilestoneSeedData();
            builder.HasData(milestones);
        }

        private List<Milestone> LoadMilestoneSeedData()
        {
            var jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "SeedData", "MilestoneSeedData.json");
            var jsonData = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<List<Milestone>>(jsonData);
        }
    }
}
