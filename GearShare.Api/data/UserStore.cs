using GearShare.Api.Models;

namespace GearShare.Api.Data;

public static class UserStore
{
    public static List<User> Users =
    [        
        new()
        {
            Id = 1,
            Name = "Admin",
            Email = "admin@example.com",
            PasswordHash = "password",
            Role = UserRoles.Admin
        },


        new()
        {
            Id = 2,
            Name = "Bob",
            Email = "bob@example.com",
            PasswordHash = "password",
            Role = UserRoles.Member
        },

        new()
        {
            Id = 3,
            Name = "Alice",
            Email = "alice@example.com",
            PasswordHash = "password",
            Role = UserRoles.Member
        }
    ];
}