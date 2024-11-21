using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TroyWebConsultingApplication.Entities;
using TroyWebConsultingApplication.Requests;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;
using IdentityUser = Microsoft.AspNetCore.Identity.IdentityUser;

namespace TroyWebConsultingApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorizationController(
    UserManager<IdentityUser> userManager,
    RoleManager<IdentityRole> roleManager,
    SignInManager<IdentityUser> signInManager
    )
{
    [HttpPost("user/register", Name = "RegisterUser")]
    public async Task RegisterUser(RegisterUserRequest request)
    {
        var identityUser = new IdentityUser(request.Username);
        await userManager.CreateAsync(identityUser, request.Password); //TODO handle when password validation fails
        
        //TODO handle when role does not exist
        if (!request.RoleName.IsNullOrEmpty() && roleManager.RoleExistsAsync(request.RoleName).Result)
        {
            await userManager.AddToRoleAsync(identityUser, request.RoleName);
        }
    }
    
    [HttpPost("user/login", Name = "Login")]
    public async Task Login(string username, string password)
    {
        await signInManager.PasswordSignInAsync(username, password, false, false);
    }

    [HttpPost("user/logout", Name = "Logout")]
    public async Task Logout()
    {
        await signInManager.SignOutAsync();
    }
}