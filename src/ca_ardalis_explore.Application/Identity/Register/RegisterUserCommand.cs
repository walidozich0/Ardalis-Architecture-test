using Ardalis.Result;
using ca_ardalis_explore.Core.Identity;

using MediatR;

namespace ca_ardalis_explore.Application.Identity;

public record RegisterUserCommand(RegisterUserDto Dto) : IRequest<Result<string>>;
