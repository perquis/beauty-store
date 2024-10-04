namespace BeautyStore.Application.User
{
    public class GetUserSession
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<string> Role { get; set; } = new List<string>();

        public bool IsInRole(string role) => Role.Contains(role);
    }
}
