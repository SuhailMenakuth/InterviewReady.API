using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.Entities.Interviewer;

namespace UserProfileService.Application.Interfaces.Repository
{
    public interface IInterviewRepository
    {
        Task<Guid> AddInterviewerAsync(Interviewer interviewer);
        Task<Interviewer> GetInterviewerByIdAsync(Guid id);
        Task<IReadOnlyCollection<Interviewer>> GetAllInterviewerAsync();
        Task DeleteInterviewerAsync(Interviewer interviewer);
        Task<IReadOnlyCollection<Interviewer>> GetInterviewerByAreaAsync(int id);
    }
}
