using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Product_Management_System.Application.Services;
using Product_Management_System.Application.Validator;
using Product_Management_System.Dtos.Product;
using Product_Management_System.Dtos.ViewResult;

namespace Product_Management_System.Controllers
{
    [Route("api/[controller]/")]
    public class ProductController : Controller
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        [HttpGet]
        [Route("GetAllWithPaging")]
        public async Task<IActionResult> GetAllAsync(int items =10, int pageNumber = 1, string sortColumn = "id", string sortOrder = "asc")
        {
            ResultDataList<ProductDto> model = await _ProductService.GetAllPagination(items, pageNumber ,sortColumn, sortOrder);
            if (model == null)
            {
                return BadRequest("Empty ");
            }
            return Ok(model);
        }
        [HttpGet]
        [Route("GetProductByID/{ID}")]
        public async Task<IActionResult> GetProductAsync(int ID)
        {
            var model = await _ProductService.GetProductByID(ID);
            if (model == null)
            {
                return BadRequest(" not found");
            }
            return Ok(model);
        }
        [HttpGet]
        [Route("GetProductByName/{Name}")]
        public async Task<IActionResult> GetProductAsync(string Name)
        {
            var model = await _ProductService.GetProductByName(Name);
            if (model == null)
            {
                return BadRequest(" not found");
            }
            return Ok(model);
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProductAsync([FromBody] AddOrUpdateProductDto Product)
        {
            var validator = new AddOrUpdateProductDtoValidator();
            var validationResult = await validator.ValidateAsync(Product);
            if (!validationResult.IsValid)
            {
                
                return BadRequest(validationResult.Errors);
            }
            var result = await _ProductService.CreateProduct(Product);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] AddOrUpdateProductDto Product)
        {
            var validator = new AddOrUpdateProductDtoValidator();
            var validationResult = await validator.ValidateAsync(Product);
            if (!validationResult.IsValid)
            {

                return BadRequest(validationResult.Errors);
            }
            var result = await _ProductService.UpdateProduct(id, Product);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpDelete]
        [Route("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id) 
        {
            var result = await _ProductService.SoftDelete(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpDelete]
        [Route("HardDelete/{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var result = await _ProductService.HardDelete(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

        [HttpGet]
        [Route("Test/Error")]
        public async Task<IActionResult> error(int id)
        {
            throw new Exception("testing errors");
        }
    }
}
