using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileService.Domain.Entities.Admin
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Area> Areas { get; set; }
    }
}
