using AutoMapper;
using IdentiService.Application.Exceptions;
using IdentiService.Application.Features.Auth.Dtos;
using IdentiService.Application.Interfaces.Repository;
using IdentityService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Features.Auth.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery , UserReadDto>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IAuthRepository authRepository , IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }

        public async Task<UserReadDto> Handle(GetUserByIdQuery request , CancellationToken cancellationToken)
        {
            var user = await _authRepository.GetUserByIdAsync(request.id) ?? throw new NotFoundException("user not found");
           return  _mapper.Map<UserReadDto>(user);
           
        }
    }
}
