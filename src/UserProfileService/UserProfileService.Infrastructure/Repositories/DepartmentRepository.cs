using Microsoft.EntityFrameworkCore;
using UserProfileService.Application.Interfaces.Repository;
using UserProfileService.Domain.Entities.Admin;
using UserProfileService.Domain.Entities.Interviewer;
using UserProfileService.Infrastructure.Persistance;

namespace UserProfileService.Infrastructure.Repositories
{

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbcontext _context;

        public DepartmentRepository(ApplicationDbcontext context)
        {
            _context = context;
        }
        public async Task<bool> IsDepartmentAlreadyExist(string name)
        {
            return await _context.Departments.AnyAsync(x => x.Name == name);
        }
        public async Task AddAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Department department)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Department department)
        {
            //_context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Department>> GetAllAsync()
        {
            return await _context.Departments
                .Include(d => d.Areas) 
                .ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments
                .Include(d => d.Areas) 
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        //public async Task<IReadOnlyCollection<Interviewer>> GetInterviewersByDepartmentAsync(int id)
        //{
        //    await _context.Departments.Include(i => i.)
        //        .Include(i => i.)
        //}



    }


}
