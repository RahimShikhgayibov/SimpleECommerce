namespace SimpleECommerce.Domain.Enums;
using System.ComponentModel;


public enum UserSessionType
{
    [Description("Giriş")] 
    SingIn = 1,

    [Description("Token yenilənməsi")] 
    RefreshSignIn = 2,

    [Description("Çıxış")] 
    SignOut = 3
}
