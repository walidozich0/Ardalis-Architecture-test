using Ardalis.Result;

using Microsoft.AspNetCore.Identity;
using ca_ardalis_explore.Core.Identity;

namespace ca_ardalis_explore.Infrastructure.Services.Identity;

public class UserManagementService(UserManager<ApplicationUser> userManager) : IUserManagementService
{
  public async Task<Result<string>> RegisterUserAsync(RegisterUserDto dto)
    {
        var user = dto.ToApplicationUser();

        var result = await userManager.CreateAsync(user, dto.Password);

        return result.ToSmartResult<string>(user.Id);
    }
}
