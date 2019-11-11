using DDDBasic.Application.Resource.Request;
using DDDBasic.Application.Resource.Response;
using DDDBasic.Application.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public IActionResult Get()
        {
            var resultado = _productService.Get();
            return Ok(resultado);
        }

        [HttpPost("GetByAnyFilter")]
        public IActionResult GetByAnyFilter(ProductGetRequest request)
        {
            var resultado = _productService.GetByAnyFilter(request);
            return Ok(resultado);
        }

        [HttpGet("GetById/{Id}")]
        public IActionResult GetById(int Id)
        {
            var resultado = _productService.GetById(Id);
            return Ok(resultado);
        }

        [HttpPost("Post")]
        public IActionResult Post(ProductResource request)
        {
            var resultado = _productService.Add(request.ResourceToEntity());
            return Ok(resultado);
        }

        [HttpPost("PostMany")]
        public IActionResult PostMany(ProductResource[] request)
        {
            var productsToSave = request.Select(product => product.ResourceToEntity()).ToArray();
            var resultado = _productService.AddMany(productsToSave);
            return Ok(resultado);
        }

        [HttpPut("Put")]
        public IActionResult Put(ProductResource request)
        {
            var resultado = _productService.Update(request.ResourceToEntity());
            return Ok(resultado);
        }

        [HttpPut("PutMany")]
        public IActionResult PutMany(ProductResource[] request)
        {
            var productsToSave = request.Select(product => product.ResourceToEntity()).ToArray();
            var resultado = _productService.UpdateMany(productsToSave);
            return Ok(resultado);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(ProductResource request)
        {
            var resultado = _productService.Delete(request.ResourceToEntity());
            return Ok(resultado);
        }

        [HttpDelete("DeleteMany")]
        public IActionResult DeleteMany(ProductResource[] request)
        {
            var productsToDelete = request.Select(product => product.ResourceToEntity()).ToArray();
            var resultado = _productService.DeleteMany(productsToDelete);
            return Ok(resultado);
        }
    }
}