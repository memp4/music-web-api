namespace UserSpace.Models;

public class UserModel
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? EmailAddres { get; set; }
    public string? Role { get; set; }
    public string? Surename { get; set; }
    public string? GivenName { get; set; }
    public string[]? PlaylistIds { get; set; }
}