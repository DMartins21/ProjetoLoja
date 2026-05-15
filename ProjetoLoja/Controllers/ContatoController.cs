using Microsoft.AspNetCore.Mvc;

namespace ProjetoLoja.Controllers;

public class ContatoController : Controller
{
    public IActionResult Index()
    {
        if(!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Accont");
        return View();
    }
}