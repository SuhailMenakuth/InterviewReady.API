using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Interfaces.Services
{
    public interface IAccessTokenGenerator
    {
        string GenerateToken(User usr);
    }
}
