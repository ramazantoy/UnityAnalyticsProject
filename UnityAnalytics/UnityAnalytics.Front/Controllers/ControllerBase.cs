using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UnityAnalytics.Front.Models;

namespace UnityAnalytics.Front.Controllers;

public abstract class ControllerBase : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    protected ControllerBase(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    private HttpClient CreateClient()
    {
        return _clientFactory.CreateClient();
    }

    protected async Task<HttpResponseMessage> PostAsync<T>(string url, T model)
    {
        var client = CreateClient();
        var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
        Console.WriteLine("W" + await content.ReadAsStringAsync());
        var response = await client.PostAsync(url, content);
        return response;
    }

    protected async Task<T?> DeserializeResponseAsync<T>(HttpResponseMessage response)
    {
        var jsonData = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(jsonData))
        {
            return default;
        }

        try
        {
            return JsonSerializer.Deserialize<T>(jsonData, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
        catch (JsonException ex)
        {
            return default;
        }
    }

    protected async Task<bool> ValidateModelAsync<T>(T model, IValidator<T> validator, ModelStateDictionary modelState)
    {
        var validationResult = await validator.ValidateAsync(model);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return false;
        }

        return true;
    }

    protected async Task<bool> ProcessJwtTokenAsync<TModel>(HttpResponseMessage response, TModel model,
        ModelStateDictionary modelState) where TModel : class
    {
        var responseModel = await DeserializeResponseAsync<JwtTokenResponseModel>(response);
        if (responseModel == null)
        {
            modelState.AddModelError("", "Response model is null");
            return false;
        }

        if (string.IsNullOrEmpty(responseModel.Token))
        {
            modelState.AddModelError("", "Token is missing in the response");
            return false;
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

            return true;
        }
        catch (Exception ex)
        {
            modelState.AddModelError("", $"An error occurred while processing the token: {ex.Message}");
            return false;
        }
    }
}