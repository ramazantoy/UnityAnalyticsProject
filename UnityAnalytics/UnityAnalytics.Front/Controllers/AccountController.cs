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

    public AccountController(IValidator<UserSignInModel> userSignInValidator, IHttpClientFactory clientFactory) :
        base(clientFactory)
    {
        _userSignInValidator = userSignInValidator;
        _clientFactory = clientFactory;
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
        var validationResult = await _userSignInValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(model);
        }

        var response = await PostAsync("http://localhost:5087/api/auth/login", model);

        if (response.IsSuccessStatusCode)
        {
            var responseModel = await DeserializeResponseAsync<JwtTokenResponseModel>(response);
            if (responseModel == null)
            {
                ModelState.AddModelError("", "Response model is null");
                return View(model);
            }

            if (string.IsNullOrEmpty(responseModel.Token))
            {
                ModelState.AddModelError("", "Token is missing in the response");
                return View(model);
            }

            try
            {
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var token = jwtSecurityTokenHandler.ReadJwtToken(responseModel.Token);
                var claims = token.Claims.ToList();

                claims.Add(new Claim("accessToken", responseModel.Token));

                var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                var authProps = new AuthenticationProperties
                {
                    ExpiresUtc = responseModel.ExpireDate,
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProps);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred while processing the token: {ex.Message}");
                return View(model);
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
}