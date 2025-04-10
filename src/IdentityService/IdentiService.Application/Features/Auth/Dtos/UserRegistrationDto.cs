﻿using IdentityService.Domain.Enums;
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


//public Guid Id { get; set; }
//public string FullName { get; set; }
//public string Email { get; set; }
//public string PhoneNumber { get; set; }
//public string Password { get; set; }
//public UserTypes UserType { get; }