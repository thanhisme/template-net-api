using Microsoft.AspNetCore.Authorization;

namespace HotelBooking.Application.Policies
{
    public class AnonymousOnlyRequirement : IAuthorizationRequirement { }

    public class AnonymousOnlyHandler : AuthorizationHandler<AnonymousOnlyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AnonymousOnlyRequirement requirement)
        {
            if (context.User.Identity == null || !context.User.Identity.IsAuthenticated)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
