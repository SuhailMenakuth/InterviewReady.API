using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Repository.Repository;
using UserProfileService.Domain.Entities.Admin;

namespace UserProfileService.Application.Features.Department.Commands
{
    //public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    //{
    //    private readonly IAuthRepository _authRepository;
    //    private readonly IPasswordHasher _passwordHasher;
    //    private readonly IAccessTokenGenerator _accessTokenGenerator;
    //    public LoginUserHandler(IAuthRepository authRepository, IPasswordHasher passwordHasher, IAccessTokenGenerator accessTokenGenerator)
    //    {
    //        _authRepository = authRepository;
    //        _passwordHasher = passwordHasher;
    //        _accessTokenGenerator = accessTokenGenerator;
    //    }
    //    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    //    {
    //        var user = await _authRepository.GetVerifiedUserByEmailAsync(request.userLoginDto.email) ?? throw new NotFoundException("user not found");
    //        if (!_passwordHasher.VerifyPassword(request.userLoginDto.password, user.Password))
    //        {
    //            throw new ApplicationException("Invalid username or password");
    //        }

    //        return _accessTokenGenerator.GenerateToken(user);
    //    }

    //}
    public class DepartmentCreateCommandHnadler  : IRequestHandler<DepartmentCreateCommand , string >
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentCreateCommandHnadler(IDepartmentRepository departmentRepository , IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DepartmentCreateCommand request , CancellationToken cancellationToken)
        {
            if( await _departmentRepository.IsDepartmentAlreadyExist(request.dto.name))
            {
                throw new ApplicationException(" Department already exist with this name ");
            }
            var department = _mapper.Map<UserProfileService.Domain.Entities.Admin.Department>(request.dto);
            await _departmentRepository.AddAsync(department);
            return "Department created successfully.";

        }
    }
}
