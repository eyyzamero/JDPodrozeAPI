using JDPodrozeAPI.Core.Contexts;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.Enums;
using System.Net;

namespace JDPodrozeAPI.Services
{
    public class VisitsService : IVisitsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly VisitsDbContext _visitsDbContext;

        public VisitsService(IHttpContextAccessor httpContextAccessor, VisitsDbContext visitsDbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _visitsDbContext = visitsDbContext;
        }

        public async Task Register(VisitType type, string description)
        {
            IPAddress? ip = _GetClientIpAddress();

            if (ip != null && !IPAddress.IsLoopback(ip))
            {
                var user = _GetCurrentUser();
                VisitDTO visit = new VisitDTO()
                {
                    Id = Guid.NewGuid(),
                    TypeId = (int) type,
                    Description = user.id != null ? $"Użytkownik \"{user.login}\" (Id: {user.id}) - {description}" : description,
                    IP = ip!.ToString(),
                    DateAndTime = DateTime.Now
                };
                _visitsDbContext.Add(visit);
                await _visitsDbContext.SaveChangesAsync();
            }
        }

        private IPAddress? _GetClientIpAddress()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var ipAddress = httpContext.Connection.RemoteIpAddress;
                return ipAddress;
            }

            return null;
        }

        private (string? id, string? login) _GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user?.Identity?.IsAuthenticated ?? false)
            {
                var userId = user.FindFirst("Id")?.Value;
                var userName = user.FindFirst("Login")?.Value;
                return (userId, userName);
            }
            return (null, null);
        }
    }
}