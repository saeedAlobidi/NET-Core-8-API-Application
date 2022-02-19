using ReservationProject.Application.Interfaces.Shared;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ReservationProject.Infrastructure.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
           
        }

        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier) == null ? null : _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
        public string Username => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name) == null ? null : _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name).Value;
    }
}