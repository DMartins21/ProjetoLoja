using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
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
        if (!ModelState.IsValid)
        {
            this.ModelState.AddModelError("Login", $"Falha ao realizar");
        }

        var user = await _userManager.FindByNameAsync(loginVm.UserName);
        if(user == null)
        {
            this.ModelState.AddModelError("Login", "Usuário Não registrado");
            return View(loginVm);
        }
        
        var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);
        if(!result.Succeeded)  this.ModelState.AddModelError("Login", "Falha ao Realizar Login");
        
        if (result.Succeeded)
        {
            return string.IsNullOrEmpty(loginVm.ReturnUrl) ? RedirectToAction("Index", "Home") : Redirect(loginVm.ReturnUrl);
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

        var user = new IdentityUser { UserName = registerVm.UserName};
        var result = await _userManager.CreateAsync(user, registerVm.Password);

        if (!result.Succeeded)
        {
            this.ModelState.AddModelError("Register", $"Falha ao realizar");
        }

        RedirectToAction("Login", "Accont");
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