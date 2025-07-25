﻿
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.Entities.Admin;
using UserProfileService.Domain.Entities.Candidate;
using UserProfileService.Domain.Entities.Interviewer;

namespace UserProfileService.Infrastructure.Persistance
{
    public class ApplicationDbcontext : DbContext
    {
       public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options) { }

       public DbSet<Department> Departments { get; set; }
       public DbSet<Area> Areas { get; set; }
       public DbSet<Interviewer> Interviewers { get; set; }
       public DbSet<InterviewerExpertiseArea> InterviewerExpertiseAreas { get; set; }
       public DbSet<Candidate> Candidates { get; set; }
       public DbSet<CandidateSkill> CandidateSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbcontext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
