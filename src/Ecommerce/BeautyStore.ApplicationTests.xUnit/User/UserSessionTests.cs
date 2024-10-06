using Xunit;
using FluentAssertions;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BeautyStore.Application.User.Tests
{
    public class UserSessionTests
    {
        [Fact()]
        public void GetSession_WithAuthenticatedUser_ShouldReturnCurrentUser()
        {
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Email, "example@gmail.com"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User")
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
            {
                User = user
            });

            var userSession = new UserSession(httpContextAccessorMock.Object);

            var session = userSession.GetSession();

            session.Should().NotBeNull();
            session!.Id.Should().Be("1");
            session.Email.Should().Be("example@gmail.com");
            session.Role.Should().Contain("Admin");
            session.Role.Should().Contain("User");
        }

        [Fact()]
        public void GetSession_WithUnauthenticatedUser_ShouldReturnNull()
        {
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

            httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            });

            var userSession = new UserSession(httpContextAccessorMock.Object);

            var session = userSession.GetSession();

            session.Should().BeNull();
        }
    }
}