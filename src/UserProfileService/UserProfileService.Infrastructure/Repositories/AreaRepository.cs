using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Repository;
using UserProfileService.Domain.Entities.Admin;
using UserProfileService.Infrastructure.Persistance;

namespace UserProfileService.Infrastructure.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly ApplicationDbcontext _context;

        public AreaRepository(ApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<bool> IsAreaAlreadyExist(int departmentId, string area)
        {
            return await _context.Areas
                .AnyAsync(a => a.DepartmentId == departmentId && a.Name.ToLower() == area.ToLower());
        }

        public async Task AddAsync(Area area)
        {
            await _context.Areas.AddAsync(area);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Area area)
        {
            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Area area)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Area>> GetAllAsync()
        {
            return await _context.Areas
                .Include(a => a.Department)
                .Include(a => a.InterviewerExpertiseAreas)
                .ToListAsync();
        }

        public async Task<Area> GetByIdAsync(int id)
        {
            return await _context.Areas
                .Include(a => a.Department)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Area>> GetAreasByIdsAsync(List<int> areaIds, CancellationToken cancellationToken)
        {
            return await _context.Areas
                .Where(a => areaIds.Contains(a.Id))
                .ToListAsync(cancellationToken);
        }
    }
}
