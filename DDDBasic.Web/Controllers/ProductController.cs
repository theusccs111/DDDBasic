using DDDBasic.Application.Resource.Request;
using DDDBasic.Application.Resource.Response;
using DDDBasic.Application.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DDDBasic.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var resultado = await _productService.Get();
            return Ok(resultado);
        }

        [HttpPost("GetByAnyFilter")]
        public async Task<IActionResult> GetByAnyFilter(ProductGetRequest request)
        {
            var resultado = await _productService.GetByAnyFilter(request);
            return Ok(resultado);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var resultado = await _productService.GetById(Id);
            return Ok(resultado);
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post(ProductResource request)
        {
            await _productService.Add(request.ResourceToEntity());
            return Ok();
        }

        [HttpPost("PostMany")]
        public async Task<IActionResult> PostMany(ProductResource[] request)
        {
            var productsToSave = request.Select(product => product.ResourceToEntity()).ToArray();
            await _productService.AddMany(productsToSave);
            return Ok();
        }

        [HttpPut("Put")]
        public async Task<IActionResult> Put(ProductResource request)
        {
            await _productService.Update(request.ResourceToEntity());
            return Ok();
        }

        [HttpPut("PutMany")]
        public async Task<IActionResult> PutMany(ProductResource[] request)
        {
            var productsToSave = request.Select(product => product.ResourceToEntity()).ToArray();
            await _productService.UpdateMany(productsToSave);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(ProductResource request)
        {
            await _productService.Delete(request.ResourceToEntity());
            return Ok();
        }

        [HttpDelete("DeleteMany")]
        public async Task<IActionResult> DeleteMany(ProductResource[] request)
        {
            var productsToDelete = request.Select(product => product.ResourceToEntity()).ToArray();
            await _productService.DeleteMany(productsToDelete);
            return Ok();
        }
    }
}