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
        //Task<bool> IsDepartmentAlreadyExist(string name);
        //Task AddAsync(Department department);
        //Task DeleteAsync(Department department);
        //Task UpdateAsync(Department department);
        //Task<IReadOnlyList<Department>> GetAllAsync();
        //Task<Department?> GetByIdAsync(int id);


        Task<bool> IsAreaAlreadyExist(int departmentId , string area);
        Task AddAsync(Area area);
        Task DeleteAsync(Area area);
        Task UpdateAsync(Area area);
        Task<ICollection<Area>> GetAllAsync();
        Task<Area> GetByIdAsync(int id);

    }
}
