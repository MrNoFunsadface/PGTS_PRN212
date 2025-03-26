using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class FetusDataConfig : IEntityTypeConfiguration<FetusData>
    {
        public void Configure(EntityTypeBuilder<FetusData> builder)
        {
            builder.Property(fg => fg.PregnancyId)
                .IsRequired();

            builder.Property(fg => fg.Date)
                .IsRequired();

            builder.Property(fg => fg.Weight)
                .IsRequired();

            builder.Property(fg => fg.Height)
                .IsRequired();

            builder.HasOne(fg => fg.Pregnancy)
                .WithMany(p => p.FetusDatas)
                .HasForeignKey(fg => fg.PregnancyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new FetusData
                {
                    Id = 1,
                    PregnancyId = 1,
                    Weight = 3.5m,
                    Height = 50.0m,
                    HeadCircumference = 30.0m,
                    Date = new DateTime(2021, 1, 1)
                },
                new FetusData
                {
                    Id = 2,
                    PregnancyId = 1,
                    Weight = 4.0m,
                    Height = 55.0m,
                    HeadCircumference = 32.0m,
                    Date = new DateTime(2021, 2, 1)
                },
                new FetusData
                {
                    Id = 3,
                    PregnancyId = 2,
                    Weight = 3.0m,
                    Height = 45.0m,
                    HeadCircumference = 28.0m,
                    Date = new DateTime(2021, 1, 1)
                },
                new FetusData
                {
                    Id = 4,
                    PregnancyId = 2,
                    Weight = 3.5m,
                    Height = 50.0m,
                    HeadCircumference = 30.0m,
                    Date = new DateTime(2021, 2, 1)
                }
            );
        }
    }
}
