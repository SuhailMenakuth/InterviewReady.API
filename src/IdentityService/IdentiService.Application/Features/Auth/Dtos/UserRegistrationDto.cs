using IdentityService.Domain.Enums;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Features.Auth.Dtos
{
    public record UserRegistrationDto(
        string fullName,
        string email,
        string phoneNumber,
        string password
        );
}

