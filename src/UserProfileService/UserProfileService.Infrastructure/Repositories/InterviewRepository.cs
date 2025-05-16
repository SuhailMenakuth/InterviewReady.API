using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbcontext _context;
        public InterviewRepository(ApplicationDbcontext context) 
        {
            _context = context;
        }
        public async Task<Guid> AddInterviewerAsync(Interviewer interviewer)
        {
            await _context.Interviewers.AddAsync(interviewer);
            await _context.SaveChangesAsync();
            return interviewer.Id;  

        }

        public async Task DeleteInterviewerAsync(Interviewer interviewer)
        {
            _context.Interviewers.Remove(interviewer);
            await _context.SaveChangesAsync();
        }



        public async Task<IReadOnlyCollection<Interviewer>> GetAllInterviewerAsync()
        {
            return await _context.Interviewers.
                Include(x => x.InterviewerExpertiseAreas).
                ThenInclude(x => x.Area).
                ThenInclude(x => x.Department).
                ToListAsync();
        }

        public async Task<IReadOnlyCollection<Interviewer>> GetInterviewerByAreaAsync(int id)
        {
            
            return await _context.Interviewers.
                Where(i => i.InterviewerExpertiseAreas.
                 Any(ea => ea.ExpertiseAreaId == id)).
                 Include(x => x.InterviewerExpertiseAreas).
                ThenInclude(x => x.Area).
                ThenInclude(x => x.Department)
                  .ToListAsync();

        }

       public async Task<Interviewer> GetInterviewerByIdAsync(Guid id)
        {
            return await _context.Interviewers.
                Include(x => x.InterviewerExpertiseAreas).
                ThenInclude(x => x.Area).
                ThenInclude(x => x.Department).
                FirstOrDefaultAsync(i => i.Id == id);
        }

     
    }
}
