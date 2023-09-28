using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentsTracker.Data;
using StudentsTracker.Models;

namespace StudentsTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductContoller : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public ProductContoller(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Product? product = await _appDbContext.Products.FindAsync(id);

            if (product != null)
            {
                return Ok(await _appDbContext.Products.FindAsync(id));
            }

            return NotFound("error");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Product field, int id)
        {
            Product? product = await _appDbContext.Products.FindAsync(id);

            if (product != null)
            {
                product.Name = field.Name;
                product.Type = field.Type;
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product? product = await _appDbContext.Products.FindAsync(id);

            if (product != null)
            {
                _appDbContext.Products.Remove(product);
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(product);
        }
    }
}
