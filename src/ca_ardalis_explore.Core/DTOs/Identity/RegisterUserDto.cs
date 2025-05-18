﻿namespace ca_ardalis_explore.Core.Identity;

public class RegisterUserDto
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }


    public ApplicationUser ToApplicationUser()
    => new()
    {
      UserName = this.UserName,
      Email = this.Email,
      PhoneNumber = this.PhoneNumber,
      EmailConfirmed = true
    };
}
