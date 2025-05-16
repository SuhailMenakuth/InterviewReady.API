using IdentityService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Features.Auth.Dtos
{
    public class UserReadDto
    {
     
        public Guid id { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public UserType userType { get; set; }
    }
}
