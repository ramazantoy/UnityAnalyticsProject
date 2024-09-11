using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UnityAnalytics.Front.Models;

namespace UnityAnalytics.Front.Controllers;

public class AccountController : Controller
{
    private readonly IValidator<UserSignInModel> _userSignInValidator;

    public AccountController(IValidator<UserSignInModel> userSignInValidator)
    {
        _userSignInValidator = userSignInValidator;
    }

    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(UserSignInModel model)
    {
        var result = await _userSignInValidator.ValidateAsync(model);
        if (result.IsValid)
        {
            
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
        
        
        return View(model);
    }

    public IActionResult SignUp()
    {
        return View();
    }
}