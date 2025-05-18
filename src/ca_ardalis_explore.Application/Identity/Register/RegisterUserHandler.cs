using Ardalis.Result;
using ca_ardalis_explore.Core.Identity;
using MediatR;
using System.Threading;


namespace ca_ardalis_explore.Application.Identity;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<string>>
{
    private readonly IUserManagementService _userService;

    public RegisterUserHandler(IUserManagementService userService)
    {
        _userService = userService;
    }

    public async Task<Result<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
      return await _userService.RegisterUserAsync(request.Dto);
      
    }
}
