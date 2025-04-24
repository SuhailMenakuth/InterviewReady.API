using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.Entities.Admin;

namespace UserProfileService.Application.Interfaces.Repository
{
    public interface IDepartmentRepository
    {
        Task<bool> IsDepartmentAlreadyExist(string name);
        Task AddAsync(Department department);
        Task DeleteAsync(Department department);
        Task UpdateAsync(Department department);
        Task<IReadOnlyList<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);

    }
}
