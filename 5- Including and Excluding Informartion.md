
# Including and Excluding Information

## Intro

![](images/61.png)

## Log Method Arguments

![](images/62.png)

> There is a Log method we can pass also the LogLevel

### EventID

EventId not required, used under thoughts
![](images/63.png)

### Message and MEssage Args

![](images/64.png)

## Demo: Add UserInfo to log entry

![](images/65.png)

For Authentication use the package :  
  
```csharp
<PackageReference Include="Microsoft.AspNetCore.Authentication.OpenIdConnect" Version="6.0.1" />
```

the code for auth in UI project:

```csharp
var builder = WebApplication.CreateBuilder(args);

JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
.AddCookie("Cookies")
.AddOpenIdConnect("oidc", options =>
{
    options.Authority = "https://demo.duendesoftware.com";
    options.ClientId = "interactive.confidential";
    options.ClientSecret = "secret";
    options.ResponseType = "code";
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("email");
    options.Scope.Add("api");
    options.Scope.Add("offline_access");
    options.GetClaimsFromUserInfoEndpoint = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = "email"
    };
    options.SaveTokens = true;
});
builder.Services.AddHttpContextAccessor();
```

the code for auth in API project:

packages:
```csharp
<PackageReference Include="IdentityModel" Version="6.0.0" />
 <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="6.0.1" />
```

code to auth API
```csharp
JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://demo.duendesoftware.com";
        options.Audience = "api";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = "email"
        };
    });
```

![](images/66.png)

---

## Semantic Logging

![](images/67.png)

## Log Scopes

![](images/68.png)

![](images/69.png)

Change the formatter name for console from "simple" to "json"

![](images/70.png)
Scope Info in the controller:
![](images/71.png)

![](images/72.png)

Info about user better to be put in a superior level , like middleware to be shared with every component. ScopeUser must be moved.
![](images/73.png)

So it gets like this:
![](images/74.png)

### User Scope Midleware 

```csharp
public class UserScopeMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<UserScopeMiddleware> _logger;

    public UserScopeMiddleware(RequestDelegate next, ILogger<UserScopeMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity is { IsAuthenticated: true })
        {
            var user = context.User;
            var pattern = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
            var maskedUsername = Regex.Replace(user.Identity.Name??"", pattern, m => new string('*', m.Length));

            var subjectId = user.Claims.First(c=> c.Type == "sub")?.Value;
                        
            using (_logger.BeginScope("User:{user}, SubjectId:{subject}", maskedUsername, subjectId))
            {
                await _next(context);    
            }
        }
        else
        {
            await _next(context);
        }
    }
}
```

![](images/75.png)

## Hidding Sensitive Information

![](images/76.png)

Demo:
![](images/77.png)

To mask an email see below code:
![](images/78.png)

The masked val
ue looks like below:
![](images/79.png)


## Demo Using LoggerMessage Source Generator
![](images/80.png)

Using the [LoggerMessage] source generator in the controller:
![](images/81.png)

In the UI with arguments for the scope
![](images/82.png)

Actually params must match:
![](images/83.png)

## Summary

![](images/84.png)
























