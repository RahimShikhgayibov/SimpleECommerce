using Microsoft.AspNetCore.Http;

namespace SimpleECommerce.Application.Extensions;

public static class HttpClientExtensions
{
    public static void AddAuthorizationTokenToHeader(this HttpClient client, IHttpContextAccessor httpContextAccessor)
    {
        string token = httpContextAccessor.HttpContext?.Request.Headers.Authorization;
        client.DefaultRequestHeaders.Add("Authorization", token);
    }
}