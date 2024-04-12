using Microsoft.AspNetCore.Identity;

namespace FoodHelper.Areas.Identity.Data;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

