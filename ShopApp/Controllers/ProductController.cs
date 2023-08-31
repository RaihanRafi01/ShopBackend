using BLL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private BLL.Services.ProductService _BLL;
        public ProductController()
        {
            _BLL = new BLL.Services.ProductService();

        }
        ///////
        ///
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProduct()
        {
            return _BLL.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetProduct(int id)
        {
            var data = _BLL.GetById(id);
            if (data == null)
            {
                return NotFound("Invalid Id");
            }
            return Ok(data);
        }
        [HttpPost]
        public void PostProduct(ProductDTO productDTO)
        {
            _BLL.post(productDTO);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            _BLL.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO productDTO)
        {
            var data = _BLL.Update(id, productDTO);

            if (data == null)
            {
                return NotFound("Invalid Id");
            }
            return Ok(data);
        }
    }
}
