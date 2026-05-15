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

    [HttpGet]
    public IActionResult Login(string? returnUrl)
    {
        return View(new LoginViewModel()
        {
            ReturnUrl = returnUrl
        });
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginVm)
    {
        if (ModelState.IsValid)
        {
            return View(loginVm);
        }

        var user = await _userManager.FindByEmailAsync(loginVm.UserName);
        
        if(user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, 
                false, false);
            
            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(loginVm.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return  RedirectToAction(loginVm.ReturnUrl);
            }
            ModelState.AddModelError("", "Falha ao Realizar Login");
        }
        return View(loginVm);
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(LoginViewModel registerVm)
    {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registerVm.UserName };
                var result = await _userManager.CreateAsync(user, registerVm.UserName);

                if (!result.Succeeded)
                {
                    this.ModelState.AddModelError("Register", "Falha ao registrar");
                }

                return RedirectToAction("Login", "Accont");
            }

            return View(registerVm);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        HttpContext.Session.Clear();
        HttpContext.User = null;
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}