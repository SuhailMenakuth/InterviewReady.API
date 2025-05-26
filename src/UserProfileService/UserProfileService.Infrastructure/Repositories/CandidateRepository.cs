using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Repository;
using UserProfileService.Domain.Entities.Candidate;
using UserProfileService.Infrastructure.Persistance;

namespace UserProfileService.Infrastructure.Repositories
{
    public class CandidateRepository  : ICandidateRepository
    {
        private readonly ApplicationDbcontext _context;
        public CandidateRepository(ApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
            return candidate.Id;

        }

        public async Task  DeleteAsync(Candidate candidate)
        {
            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Candidate>> GetAllAsync()
        {
           return await _context.Candidates.ToListAsync();
        }

        public async Task<Candidate> GetByIdAsync(Guid id)
        {
           return await  _context.Candidates.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<object> AddAsync(CandidateSkill candidateSkill)
        {
            await _context.CandidateSkills
                 .AddAsync(candidateSkill);
            await _context.SaveChangesAsync();
            return new
            { 
                id = candidateSkill.Id,
                skillName = candidateSkill.SkillName,
            };

        }

        public async Task<Candidate> GetCandidateWithSkillsAsync(Guid id)
        {
            return await _context.Candidates
                 .Include(c => c.Skills)
                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CandidateSkill> GetCanidateSkillByIdAsync(Guid id)
        {
            return await _context.CandidateSkills
                .FindAsync(id);
        }
        public async Task DeleteCanidateSkillByIdAsync(CandidateSkill candidateSkill)
        {
             _context.CandidateSkills
                .Remove(candidateSkill);
            await _context.SaveChangesAsync();   
        }
    }
}
