using System.ComponentModel.DataAnnotations;

namespace UnityAnalytics.Front.Models;

public class UserSignInModel
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public string ReturnUrl { get; set; }
        
    public bool RememberMe { get; set; }


}