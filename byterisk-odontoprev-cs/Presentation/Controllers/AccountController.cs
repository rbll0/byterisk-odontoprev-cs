using byterisk_odontoprev_cs.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace byterisk_odontoprev_cs.Presentation.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    [SwaggerOperation(Summary = "Exibe a tela de login", Description = "Este endpoint exibe a tela de login.")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Processa o login", Description = "Este endpoint processa o login com base nas credenciais fornecidas.")]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Validação simples para o login (exemplo)
        var loginSucesso = model.Email == "admin@byrisk.com" && model.Password == "password";

        if (loginSucesso)
        {
            return RedirectToAction("Index", "Dashboard");
        }

        ModelState.AddModelError(string.Empty, "Credenciais inválidas");
        return View(model);
    }
}
