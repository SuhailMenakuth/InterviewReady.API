using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.Entities.Candidate;

namespace UserProfileService.Infrastructure.Persistance.Configurations
{
    public  class CandidateSkillConfiguration : IEntityTypeConfiguration<CandidateSkill>
    {
        public void Configure(EntityTypeBuilder<CandidateSkill> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(cs => cs.SkillName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(cs => cs.Candidate)
                .WithMany(c => c.Skills)
                .HasForeignKey(cs => cs.CandidateId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(cs => cs.SkillName);

        }

     
    }
}
