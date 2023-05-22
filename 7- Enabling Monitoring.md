
# Enabling Monitoring

## Intro

![](images/98.png)

## Defining Monitoring And APM

![](images/99.png)

![](images/100.png)

---
## Demo: Query-based alerts with Application Insight

![](images/101.png)

## Query-based Monitoring Examples

![](images/102.png)

## Healthchecks

![](images/103.png)

![](images/104.png)

![](images/105.png)

Healthcheck for DBContext

![](images/106.png)

![](images/107.png)

### Custom Healthcheck

![](images/108.png)

>For IDP healthcheck

```csharp
<PackageReference Include="AspNetCore.HealthChecks.OpenIdConnectServer" Version="6.0.1" />
```

```csharp
builder.Services.AddHealthChecks()
    .AddIdentityServer(new Uri("https://demo.duendesoftware.com"), failureStatus: HealthStatus.Degraded);
```

### Monitoring HC AppInsight

![](images/109.png)

host.docker.internal special dns for docker dns (seq)
![](images/110.png)

## Liveness and REadiness

![](images/111.png)

More on HC
![](images/112.png)

## Summary

![](images/113.png)







