using Ardalis.Result;
using ca_ardalis_explore.Core.Identity;

namespace ca_ardalis_explore.Core.Identity;

public interface IUserManagementService
{
    Task<Result<string>> RegisterUserAsync(RegisterUserDto dto);
}
