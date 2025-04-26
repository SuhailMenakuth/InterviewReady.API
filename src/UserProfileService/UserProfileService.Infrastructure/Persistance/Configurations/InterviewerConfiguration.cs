using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.Entities.Interviewer;

namespace UserProfileService.Infrastructure.Persistance.Configurations
{
    public class InterviewerConfiguration : IEntityTypeConfiguration<Interviewer>
    {
        public void Configure(EntityTypeBuilder<Interviewer> builder)
        {
         

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(i => i.About)
                   .HasMaxLength(1000);

            builder.Property(i => i.Photo)
                   .HasMaxLength(255);


            builder.Property(i => i.CreatedOn)
                   .HasDefaultValueSql("GETDATE()")
                   .IsRequired();

            builder.Property(i => i.UpdatedOn)
                   .HasDefaultValueSql("GETDATE()")
                   .IsRequired();

            builder.Property(i => i.IsDeleted)
                   .HasDefaultValue(false);

            builder.HasMany(i => i.InterviewerExpertiseAreas)
                   .WithOne(ea => ea.Interviewer)
                   .HasForeignKey(ea => ea.InterviewerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
