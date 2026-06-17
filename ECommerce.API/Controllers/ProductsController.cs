using ECommerce.Application.Contracts;
using ECommerce.Application.DTOs.Product;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    public class ProductsController(IProductService productService) : ApiBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAllProducts(CancellationToken cancellationToken)
        {
            var products = await productService.GetAllProductsAsync(cancellationToken);
            return ToActionResult(products);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id, CancellationToken cancellationToken)
        {
            var product = await productService.GetProductAsync(id, cancellationToken);
            return ToActionResult(product);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<TypeDto>>> GetAllTypes(CancellationToken cancellationToken)
            => ToActionResult(await productService.GetAllTypesAsync(cancellationToken));

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<BrandDto>>> GetAllBrands(CancellationToken cancellationToken)
            => ToActionResult(await productService.GetAllBrandsAsync(cancellationToken));

    }
}
