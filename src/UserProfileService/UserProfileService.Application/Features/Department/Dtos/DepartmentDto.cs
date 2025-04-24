using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Area.Dtos;

namespace UserProfileService.Application.Features.Department.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AreaDto> Areas { get; set; } = new();
    }
}
