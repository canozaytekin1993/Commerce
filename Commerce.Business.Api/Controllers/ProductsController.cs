using System.Collections.Generic;
using System.Threading.Tasks;
using Commerce.Contracts.Repository;
using Commerce.Domain.Entities.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Business.Api.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productRepository.GetAllProducts();
        }
    }
}