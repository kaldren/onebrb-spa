namespace Onebrb.SPA.Models;

public class ProfileModel
{
    public long Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string About { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }
}

