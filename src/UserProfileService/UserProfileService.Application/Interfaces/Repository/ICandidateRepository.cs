using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.Entities.Candidate;


namespace UserProfileService.Application.Interfaces.Repository
{
    public interface ICandidateRepository
    {

        Task<Guid> AddAsync(Candidate candidate);
        Task<Candidate> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<Candidate>> GetAllAsync();
        Task DeleteAsync(Candidate candidate);
        Task UpdateAsync();
        Task<object> AddAsync(CandidateSkill candidateSkill);
        Task<Candidate> GetCandidateWithSkillsAsync(Guid id);
        Task<CandidateSkill> GetCanidateSkillByIdAsync(Guid id);
        Task DeleteCanidateSkillByIdAsync(CandidateSkill candidateSkill);
    }
}
