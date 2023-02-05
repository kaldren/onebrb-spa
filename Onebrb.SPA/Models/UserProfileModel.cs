namespace Onebrb.SPA.Models;

public class UserProfileModel
{
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public bool IsEmailVisible { get; set; }

    public string? About { get; set; }

    public string? Photo { get; set; }

    public string? Country { get; set; }

    public string? CountryId { get; set; }

    public string? City { get; set; }

    public double? Rating { get; set; }

    public string? OccupationName { get; set; }

    public string? OccupationId { get; set; }

    public string? LinkedInProfile { get; set; }

    public string? FacebookProfile { get; set; }

    public string? InstagramProfile { get; set; }
}

