using AutoMapper;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.Repositories;
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
        private readonly IUsersRepository _usersRepository;
        private readonly IJWTService _jwtService;

        public AccountService(IMapper mapper, ICryptographyService cryptographyService, IUsersRepository usersRepository, IJWTService jwtService)
        {
            _mapper = mapper;
            _cryptographyService = cryptographyService;
            _usersRepository = usersRepository;
            _jwtService = jwtService;
        }

        public async Task<string?> TryToLoginAsync(IAccountServiceLoginReq request)
        {
            UserDTO? user = await _usersRepository.GetUserByLoginAsync(request.Login);

            if (user is not null && await _cryptographyService.VerifyAsync(request.Password, user.Password))
                return await _jwtService.CreateToken(user);

            return null;
        }

        public async Task<IAccountServiceRegisterRes> RegisterAsync(IAccountServiceRegisterReq request)
        {
            UserDTO user = _mapper.Map<UserDTO>(request);

            user.Password = await _cryptographyService.EncryptAsync(user.Password);

            await _usersRepository.AddUserAsync(user);
            await _usersRepository.SaveChangesAsync();

            IAccountServiceRegisterRes response = _mapper.Map<IAccountServiceRegisterRes>(user);

            if (request.GetToken)
                response.Token = await _jwtService.CreateToken(user);

            return response;
        }

        public async Task<bool> IsLoginAvailable(string login)
        {
            return await _usersRepository.IsLoginAvailable(login);
        }
    }
}