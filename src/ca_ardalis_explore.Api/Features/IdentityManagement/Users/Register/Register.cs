using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using ca_ardalis_explore.Application.Identity;
using ca_ardalis_explore.Core.Identity;
using ca_ardalis_explore.Infrastructure;
using FastEndpoints;
using MediatR;
using ProblemDetails = FastEndpoints.ProblemDetails;
using ca_ardalis_explore.Api.Extensions;

namespace ca_ardalis_explore.Api.Features.IdentityManagement.Users.Register;

public class Register : Endpoint<RegisterUserRequest, RegisterUserResponse>
{
    private readonly IMediator _mediator;

    public Register(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post("/users/register");
        AllowAnonymous();
        Summary(s => s.Summary = "Register a new user.");
    }

    public override async Task HandleAsync(RegisterUserRequest req, CancellationToken ct)
    {
      var dto = req.ToRegisterUserDto();
      var result = await _mediator.Send(new RegisterUserCommand(dto), ct);

    //await SendResultAsync(result.ToMinimalApiResult());

    if (result.IsSuccess)
    {
      // await SendResultAsync(result.ToMinimalApiResult());
      await SendOkAsync(new RegisterUserResponse { UserId = result.Value! });
    }
    else
    {
      //var pd = result.ToProblemDetails(HttpContext);
      //await SendAsync(pd, pd.Status);
      var pd = result.ToProblemDetails(HttpContext);
      HttpContext.Response.StatusCode = pd.Status;
      await HttpContext.Response.WriteAsJsonAsync(pd);
    }
  }
}
