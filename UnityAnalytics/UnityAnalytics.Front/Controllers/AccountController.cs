using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using UnityAnalytics.Front.Models;

namespace UnityAnalytics.Front.Controllers;

public class AccountController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IValidator<UserSignInModel> _userSignInValidator;
    private readonly IValidator<UserSignUpModel> _userSignUpValidator;

    public AccountController(IValidator<UserSignInModel> userSignInValidator, IHttpClientFactory clientFactory,
        IValidator<UserSignUpModel> userSignUpValidator) :
        base(clientFactory)
    {
        _userSignInValidator = userSignInValidator;
        _clientFactory = clientFactory;
        _userSignUpValidator = userSignUpValidator;
    }

    public IActionResult SignIn()
    {
        if (User.Identity is { IsAuthenticated: true })
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(UserSignInModel model)
    {
        var validationResult = await ValidateModelAsync(model, _userSignInValidator, ModelState);

        if (!validationResult)
        {
            return View(model);
        }
    

        var response = await PostAsync("http://localhost:5087/api/auth/login", model);

        if (response.IsSuccessStatusCode)
        {
            var result = await ProcessJwtTokenAsync(response, model, ModelState);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
         
        }

        var errorMessage = await response.Content.ReadAsStringAsync();
        ModelState.AddModelError("", $"An error occurred {errorMessage}");
        return View(model);
    }


    public IActionResult SignUp()
    {
        if (User.Identity is { IsAuthenticated: true })
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(UserSignUpModel model)
    {
        var validationResult = await ValidateModelAsync(model, _userSignUpValidator, ModelState);
        if (!validationResult)
        {
            return View(model);
        }
        
        var response = await PostAsync("http://localhost:5087/api/auth/register", model);
        if (response.IsSuccessStatusCode)
        {
            var result = await ProcessJwtTokenAsync(response, model, ModelState);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        
        return View(model);
    }
}