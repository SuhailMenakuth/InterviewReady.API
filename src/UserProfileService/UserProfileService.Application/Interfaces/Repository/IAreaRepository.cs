using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.Entities.Admin;

namespace UserProfileService.Application.Interfaces.Repository
{
    public interface IAreaRepository
    {
      


        Task<bool> IsAreaAlreadyExist(int departmentId , string area);
        Task AddAsync(Area area);
        Task DeleteAsync(Area area);
        Task UpdateAsync(Area area);
        Task<ICollection<Area>> GetAllAsync();
        Task<Area> GetByIdAsync(int id);
        Task<List<Area>> GetAreasByIdsAsync(List<int> areaIds, CancellationToken cancellationToken);

    }
}
