using System.ComponentModel.DataAnnotations;

namespace UnityAnalytics.Front.Models;

public class UserSignInModel
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;


}