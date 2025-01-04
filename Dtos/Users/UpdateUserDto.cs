namespace BlogWeb.Dtos.Users
{
    public class UpdateUserDto
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }

    }
}
