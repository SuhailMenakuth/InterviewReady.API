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
    public class InterviewerExpertiseAreaConfiguration : IEntityTypeConfiguration<InterviewerExpertiseArea>
    {
        public void Configure(EntityTypeBuilder<InterviewerExpertiseArea> builder)
        {
           
            builder.HasKey(ea => new { ea.InterviewerId, ea.ExpertiseAreaId });

            builder.HasOne(ea => ea.Interviewer)
                   .WithMany(i => i.InterviewerExpertiseAreas)
                   .HasForeignKey(ea => ea.InterviewerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ea => ea.Area)
                   .WithMany(a => a.InterviewerExpertiseAreas)
                   .HasForeignKey(ea => ea.ExpertiseAreaId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
