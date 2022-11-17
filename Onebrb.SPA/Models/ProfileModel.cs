namespace Onebrb.SPA.Models;

public class UserProfileModel
{
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public bool IsEmailVisible { get; set; }

    public string Phone { get; set; }

    public bool IsPhoneVisible { get; set; }

    public string About { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public bool IsDeleted { get; set; }

    public double? Rating { get; set; }

    public string? OccupationName { get; set; }
}

