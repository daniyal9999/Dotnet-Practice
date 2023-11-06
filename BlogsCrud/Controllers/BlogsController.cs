using BlogsCrud.Data;
using BlogsCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogsCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        private readonly BlogsApiDbContext dbContext;

        public BlogsController(BlogsApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Get All 
        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            return Ok(await dbContext.Blogs.ToListAsync());
        }

        //Get Single
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetBlog([FromRoute] Guid id)
        {
            var blog = await dbContext.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        //Create
        [HttpPost]
        public async Task<IActionResult> AddBlog(AddBlogRequest addBlogRequest)
        {
            var blog = new Blog()
            {
                Id = Guid.NewGuid(),
                Name = addBlogRequest.Name,
                Description = addBlogRequest.Description,
                Author = addBlogRequest.Author,
            };

            await dbContext.Blogs.AddAsync(blog);
            await dbContext.SaveChangesAsync();

            return Ok(blog);
        }

        //Update
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateBlog([FromRoute] Guid id, UpdateBlogRequest updateBlogRequest)
        {
            var blog = await dbContext.Blogs.FindAsync(id);

            if(blog != null)
            {
                blog.Name = updateBlogRequest.Name;
                blog.Description = updateBlogRequest.Description;
                blog.Author = updateBlogRequest.Author;

                await dbContext.SaveChangesAsync();

                return Ok(blog);
            }
            return NotFound();
        }

        //Delete
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteBlog([FromRoute] Guid id)
        {
            var blog = await dbContext.Blogs.FindAsync(id);

            if (blog != null)
            {
                dbContext.Remove(blog);
                await dbContext.SaveChangesAsync();
                return Ok(blog);
            }
            return NotFound();
        }
    }
}
