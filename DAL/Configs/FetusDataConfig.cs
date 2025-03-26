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
        }
    }
}
