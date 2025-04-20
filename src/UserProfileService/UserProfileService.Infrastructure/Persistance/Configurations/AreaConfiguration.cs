using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading.Tasks;
using UserProfileService.Domain.Entities.Admin;

namespace UserProfileService.Infrastructure.Persistance.Configurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(a => a.Id);
            
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasOne(a => a.Department)
                .WithMany(d => d.Areas)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.InterviewerExpertiseAreas)
                .WithOne(ea => ea.Area)
                .HasForeignKey(ea => ea.ExpertiseAreaId);

        }
    }
}
