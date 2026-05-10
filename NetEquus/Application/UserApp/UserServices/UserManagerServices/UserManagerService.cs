using Application.AuthApp.IAuthServices;
using Application.UnitOfWorks;
using Application.UserApp.IUserServices;
using Application.UserApp.IUserServices.IUserValidationServices;
using Application.UserApp.UserServices;
using Domain.DomainRules;
using Shared.Dtos.Responses;
using Shared.Dtos.UserDtos;
using Shared.Mappers.UserMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserApp.UserSevices.UserManagerServices
{
    public class UserManagerService : IUserManagerService
    {
        private readonly IUserCrudService _userCrudService;

        private readonly IPasswordHasherService _passwordHasherService;

        private readonly IValidationManagerService _validationManagerService;

        private readonly IUserInitilizationService _userInitilizationService;
        private readonly IUnitOfWork _unitOfWork;



        public UserManagerService(IUserCrudService userCrudService, IPasswordHasherService passwordHasherService, 
            IValidationManagerService validationManagerService, IUnitOfWork unitOfWork, IUserInitilizationService  userInitilizationService)
        {
            _userCrudService = userCrudService;
            _passwordHasherService = passwordHasherService;
            _validationManagerService = validationManagerService;
            _userInitilizationService = userInitilizationService;
            _unitOfWork = unitOfWork;
          
     
        }

        public async Task<RuleResult> RegisterUserAsync(UserRegistrationDto userRegistrationDto)
        {
            var validationCheck = await _validationManagerService.FinalValidationAsync(userRegistrationDto);

            if (!validationCheck.IsAllowed)
                return validationCheck;


            try
            {
                await _unitOfWork.ExecuteAsync(async () =>
                {
                    var user = UserMapper.ToNewUser(userRegistrationDto);

                    await _userInitilizationService.UserInitilizationAsync(userRegistrationDto);

                    user.Password_Hash = _passwordHasherService.HashPassword(userRegistrationDto.Password);



                    await _userCrudService.CreateUserAsync(user);
                });

                return RuleResult.Success();
            }

            catch (Exception ex)
            {
                return RuleResult.Fail($"Estate creation failed: {ex.Message}");
            }
        }
    }
}
