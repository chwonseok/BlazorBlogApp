using Microsoft.AspNetCore.Mvc;

namespace BlazorBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlazorBlogApp.Server.Data.DataContext _context;

        // Inject data context
        public BlogController(BlazorBlogApp.Server.Data.DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<BlazorBlogApp.Shared.BlogPost>> GiveMeAllTheBlogPosts()
        {
            return Ok(_context.BlogPosts);
        }

        [HttpGet("{url}")]
        public ActionResult<BlazorBlogApp.Shared.BlogPost> GiveMeThatSingleBlogPost(string url)
        {
            var post = _context.BlogPosts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            if (post is null)
            {
                return NotFound("This post does not exist.");
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<BlazorBlogApp.Shared.BlogPost>> CreateNewBlogPost(BlazorBlogApp.Shared.BlogPost request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();

            return request;
        }
    }
}