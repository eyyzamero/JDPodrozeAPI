using AutoMapper;
using JDPodrozeAPI.Controllers.Account.Contracts.Requests;
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

        public async Task<bool> IsLoginAvailable(string login, string? currentLogin)
        {
            return await _usersRepository.IsLoginAvailable(login, currentLogin);
        }

        public async Task<int?> AddOrEditAsync(IAccountAddOrEditReq request)
        {
            UserDTO user = _mapper.Map<UserDTO>(request);

            if (request.Password != null)
            {
                user.Password = await _cryptographyService.EncryptAsync(user.Password);
            }

            if (request.Id != null)
            {
                await _usersRepository.UpdateUserAsync(user);
            }
            else
            {
                _usersRepository.AddUser(user);
            }
            await _usersRepository.SaveChangesAsync();
            return request.Id == null ? user.Id : null;
        }

        public async Task DeleteAsync(int id)
        {
            await _usersRepository.DeleteAsync(id);
            await _usersRepository.SaveChangesAsync();
        }
    }
}