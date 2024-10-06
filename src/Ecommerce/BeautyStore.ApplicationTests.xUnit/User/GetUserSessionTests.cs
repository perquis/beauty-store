using FluentAssertions;
using Xunit;

namespace BeautyStore.Application.User.Tests
{
    public class GetUserSessionTests
    {
        [Fact()]
        public void IsInRoleTest_ShouldReturnTrue_WhenTheUserHasAdminOrUserRole()
        {
            var userSession = new GetUserSession()
            {
                Id = "1",
                Email = "example@gmail.com",
                Role = new List<string> { "Admin", "User" }
            };

            var isAdminRole = userSession.IsInRole("Admin");
            var isUserRole = userSession.IsInRole("User");

            isAdminRole.Should().BeTrue();
            isUserRole.Should().BeTrue();
        }

        [Fact()]
        public void IsInRoleTest_ShouldReturnFalse_WhenTheUserDoesNotHaveAdminOrUserRole()
        {
            var userSession = new GetUserSession()
            {
                Id = "1",
                Email = "example@gmail.com",
                Role = new List<string> { }
            };

            var isAdminRole = userSession.IsInRole("Admin");
            var isUserRole = userSession.IsInRole("User");

            isAdminRole.Should().BeFalse();
            isUserRole.Should().BeFalse();
        }
    }
}