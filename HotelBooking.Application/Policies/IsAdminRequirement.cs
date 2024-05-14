using Microsoft.AspNetCore.Authorization;

namespace HotelBooking.Application.Policies
{
    public class IsAdminRequirement : IAuthorizationRequirement { }

    public class IsAdminHandler : AuthorizationHandler<IsAdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminRequirement requirement)
        {
            if (context.User.Identity != null && context.User.IsInRole("Admin"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
