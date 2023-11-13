using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewRepo.DTO;
using NewRepo.Entity;
using NewRepo.IService;

namespace NewRepo.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet("get/{productId}")]
        public async Task<ActionResult> getProductById(long productId)
        {
            var product = await _productService.GetById(productId);
            return Ok(_mapper.Map<ProductDTO>(product));
        }
        [HttpPost("insert")]
        public async Task<ActionResult> createProduct([FromBody] ProductDTO product)
        {
            await _productService.Insert(_mapper.Map<Product>(product));
            return Ok("Product has been inserted");
        }
        [HttpPut("update/{productId}")]
        public async Task<ActionResult> updateProduct([FromRoute] long productId, [FromBody] ProductDTO product)
        {
            await _productService.Update(productId, _mapper.Map<Product>(product));
            return Ok("Product has been updated");
        }
        [HttpDelete("delete/{productId}")]
        public async Task<ActionResult> deleteProduct([FromRoute] long productId)
        {
            await _productService.Delete(productId);
            return Ok("Product has been deleted");
        }
        [HttpGet("get_all")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> getProducts()
        {
            var products = _mapper.Map<IEnumerable<ProductDTO>>(await _productService.GetAll());
            return Ok(products);
        }
        //TO-DO : get products by choosen categories
        /*     [HttpGet]
             public ActionResult<IEnumerable<ProductDTO>> getProductsByProductType()
             {
                 var products = _mapper.Map<IEnumerable<ProductDTO>>(_service.getProductsByCategory());
                 return Ok();
             }*/


    }
}
