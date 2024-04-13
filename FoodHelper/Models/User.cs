using FoodHelper.Data.Models;
using FoodHelper.Data.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace FoodHelper.Models;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<Food>? Foods { get; set; }
}

