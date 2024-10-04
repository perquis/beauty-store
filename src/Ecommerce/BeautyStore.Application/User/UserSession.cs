using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace BeautyStore.Application.User
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public GetUserSession? GetSession()
        {
            var user = _httpContextAccessor.HttpContext!.User;

            if (user == null)
            {
                return null;
            }

            if (user.Identity == null || !user.Identity!.IsAuthenticated)
            {
                return null;
            }

            var session = new GetUserSession
            {
                Id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value,
                Email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value,
                Role = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value)
            };

            return session;
        }
    }
}
