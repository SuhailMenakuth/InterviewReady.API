using IdentityService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Entities
{
    public class Candidate : User
    {
        public UserTypes UserTypes { get; set; } = UserTypes.Candidate;
        public string? ProfilePhotoUrl {  get; set; }
        public string? CvUrl { get; set; }
        public string? EducationDetails { get; set; }
     
        
    }
}
