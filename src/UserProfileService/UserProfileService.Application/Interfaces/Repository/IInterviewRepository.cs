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
    }
}
