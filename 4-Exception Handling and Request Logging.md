
# Exception Handling and Request Logging

## Intro

![](images/26.png)

## Application Updates and Problem statements

![](images/27.png)

## Exception Handling

![](images/28.png)

Specific situations to add a Try/Catch
![](images/29.png)

or swallowing the exception and continuing
![](images/30.png)

## Demo: Using the Error Page in a User Interface

![](images/31.png)

![](images/32.png)

> Commenting above code condition (when not development) to execute in all environment

and removing the **appsetting.Development.json** 

![](images/33.png)

For requestId
```csharp
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string? RequestId { get; set; }
        public Activity? CurrentActivity { get; set; }
        public string TraceId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            CurrentActivity = Activity.Current;
            TraceId = HttpContext.TraceIdentifier;
        }
    }
}
```

![](images/34.png)

We include Scopes = true stating we should include previos IDs in the logs

![](images/35.png)

Then we can see the values :

![](images/36.png)

Then we can see on the scopes :
![](images/37.png)

---

## Api Error Handling 

![](images/38.png)

![](images/39.png)

Demo:

![](images/40.png)

Using the Hellang PD Middleware :
![](images/41.png)

To hide exception details , maybe good on Dev Environments:
![](images/42.png)

Trying the console provider:

![](images/43.png)

then we get :

![](images/44.png)

We can customize :

![](images/45.png)

Then we get:
![](images/46.png)

TraceId:

![](images/47.png)

> There are situations to handle speicific critic errors , we can do:

![](images/48.png)

We can have :

```csharp
using Microsoft.Data.Sqlite;

namespace CarvedRock.Api;
public class CriticalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CriticalExceptionMiddleware> _logger;

    public CriticalExceptionMiddleware(RequestDelegate next, ILogger<CriticalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (SqliteException sqlex)
        {
            if (sqlex.SqliteErrorCode == 551)
            {
                _logger.LogCritical(sqlex, "Fatal error occurred in database!!");
            }            
        }       
    }
}
```
![](images/49.png)

Then we have 2 errors been logged :

![](images/50.png)

and the general Middleware:

![](images/51.png)

## Reading API error on the user interface

![](images/52.png)

Changing Log configs
![](images/53.png)

> TraceId is equal for the API and UI side, but the SpanId different:

![](images/54.png)

---

## Request Logging
> This allows to create a Log entry at the conclusion of every Http Request

![](images/55.png)

### Demo- Using Http and W3C Logging

For HttpLogging:

![](images/56.png)

We need to be specific:
![](images/59.png)

For W3C

![](images/57.png)

![](images/58.png)

---

## Summary

![](images/60.png)










