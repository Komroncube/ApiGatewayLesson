using CategoryBookMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CategoryBookMVC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BulkyBooksMvcContext dbContext;

        public CategoryController(BulkyBooksMvcContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllCategories()
        {
            var categories = await dbContext.Categories.ToListAsync();
            return Ok(categories);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCategory(CategoryDto categoryDto)
        {
            try
            {
                var category = new Category();
                category.Name = categoryDto.Name;
                category.DisplayOrder = categoryDto.DisplayOrder;
                category.CreatedDateTime = DateTime.UtcNow;
                await dbContext.AddAsync(category);
                int res = await dbContext.SaveChangesAsync();
                if(res>0)
                {
                    return CreatedAtAction("CreateCategory",category);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCateogry(int id)
        {
            try
            {
                var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
                dbContext.Remove(category);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
