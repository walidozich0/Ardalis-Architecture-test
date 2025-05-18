using ca_ardalis_explore.Core.Identity;

namespace ca_ardalis_explore.Api.Features.IdentityManagement.Users.Register;

public class RegisterUserRequest
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }

    public RegisterUserDto ToRegisterUserDto() => new()
    {
      Email = this.Email,
      Password = this.Password,
      UserName = this.UserName,
      FirstName = this.FirstName,
      LastName = this.LastName,
      PhoneNumber = this.PhoneNumber
    };
}
