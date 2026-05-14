using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.ViewModel;

namespace ProjetoLoja.Controllers;

public class AccontController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    
    public AccontController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Login(string returnUrl)
    {
        return View(new LoginViewModel()
        {
            ReturnUrl = returnUrl
        });
    }

    public async Task<IActionResult> Login(LoginViewModel loginVm)
    {
        if (ModelState.IsValid)
        {
            return View(loginVm);
        }

        var user = await _userManager.FindByEmailAsync(loginVm.UserName);

        if (user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);
            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(loginVm.ReturnUrl))
                {
                    return Redirect(loginVm.ReturnUrl);
                }
                return  Redirect(loginVm.ReturnUrl);
            }
        }
        ModelState.AddModelError("", "Falha ao Realizar Login");
        return View(loginVm);
    }
}