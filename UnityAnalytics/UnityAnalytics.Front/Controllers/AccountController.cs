using Microsoft.AspNetCore.Mvc;
using UnityAnalytics.Front.Models;

namespace UnityAnalytics.Front.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignIn(UserSignInModel model)
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }
}