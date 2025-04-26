using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Repository;
using UserProfileService.Domain.Entities.Interviewer;
using UserProfileService.Infrastructure.Persistance;

namespace UserProfileService.Infrastructure.Repositories
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly ApplicationDbcontext _dbcontext;
        public InterviewRepository(ApplicationDbcontext dbcontext) 
        {
            _dbcontext = dbcontext;
        }
        public async Task<Guid> AddInterviewerAsync(Interviewer interviewer)
        {
            await _dbcontext.Interviewers.AddAsync(interviewer);
            await _dbcontext.SaveChangesAsync();
            return interviewer.Id;  

        }
    }
}
