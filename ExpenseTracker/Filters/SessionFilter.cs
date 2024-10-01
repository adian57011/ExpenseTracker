using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class SessionFilterAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var sessionId = context.HttpContext.Session.GetString("UserId");

        if (string.IsNullOrEmpty(sessionId))
        {
            context.Result = new RedirectToActionResult("Index", "Auth", null);
        }
    }
}
