using CarvedRock.Domain;
using CarvedRock.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarvedRock.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly ILogger<ProductController> _logger;
    private readonly IProductLogic _productLogic;

    public ProductController(IProductLogic productLogic, ILogger<ProductController> logger)
    {
        _productLogic = productLogic;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductModel>> Get(string category = "all")
    {
        _logger.LogInformation("Getting products in API for {category}", category);
        return await _productLogic.GetProductsForCategory(category);
    }
}