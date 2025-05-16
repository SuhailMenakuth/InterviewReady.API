using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserProfileService.Domain.Entities.Candidate;

namespace UserProfileService.Infrastructure.Persistance.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
       

        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
           
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.PhotoUrl)
                       .HasMaxLength(300);

            builder.Property(c => c.CvUrl)
                       .HasMaxLength(300);

            builder.Property(c => c.HighestEducation)
                       .HasMaxLength(150);

            builder.Property(c => c.CreatedOn)
                       .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(c => c.UpdatedOn)
                       .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(c => c.IsDeleted)
                       .HasDefaultValue(false);
        }
    }
}