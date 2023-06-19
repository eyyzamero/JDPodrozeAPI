using AutoMapper;
using JDPodrozeAPI.Core.Contexts.Users;
using JDPodrozeAPI.Core.DTOs.Users;
using JDPodrozeAPI.Core.Services.Cryptography;
using JDPodrozeAPI.Core.Services.JWT;
using JDPodrozeAPI.Services.Account.Contracts.Requests;
using JDPodrozeAPI.Services.Account.Contracts.Responses;

namespace JDPodrozeAPI.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly ICryptographyService _cryptographyService;
        private readonly UsersDbContext _usersDbContext;
        private readonly IJWTService _jwtService;

        public AccountService(IMapper mapper, ICryptographyService cryptographyService, UsersDbContext usersDbContext, IJWTService jwtService)
        {
            _mapper = mapper;
            _cryptographyService = cryptographyService;
            _usersDbContext = usersDbContext;
            _jwtService = jwtService;
        }

        public string? TryToLogin(IAccountServiceLoginReq request)
        {
            string? response = null;
            
            UserDTO? user = _usersDbContext.Users.SingleOrDefault(x => x.Login == request.Login);

            if (user != null)
                if (_cryptographyService.Verify(request.Password, user.Password))
                    response = _CreateToken(user);

            return response;
        }

        public IAccountServiceRegisterRes Register(IAccountServiceRegisterReq request)
        {
            UserDTO user = _mapper.Map<UserDTO>(request);

            user.Password = _cryptographyService.Encrypt(user.Password);

            _usersDbContext.Users.Add(user);
            _usersDbContext.SaveChanges();

            IAccountServiceRegisterRes response = _mapper.Map<AccountServiceRegisterRes>(user);

            if (request.GetToken)
                response.Token = _CreateToken(user);

            return response;
        }

        private string _CreateToken(UserDTO user)
        {
            string response = _jwtService.CreateToken(user);
            return response;
        }
    }
}