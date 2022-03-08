using Microsoft.AspNetCore.Mvc;
using BlazorBlogApp.Server.Practice.BlazorBlogPost.Services;
using BlazorBlogApp.Shared;

namespace BlazorBlogApp.Server.Practice.BlazorBlogPost.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly BlogPostService blogPostService;

        public BlogPostController(BlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }


        [HttpPost]
        public async Task<ActionResult<BlogPost>> CreateNewBlogPost(BlogPost post)
        {
            await blogPostService.CreateNewBlogPost(post);

            return Ok(post);
        }

        [HttpGet]
        public async Task<List<BlogPost>> GetBlogPosts()
        {
            return await blogPostService.GetBlogPosts();
        }

        //[HttpPost]
        //public async Task EditPost(BlogPost blogPost)
        //{
        //    blogPost.Title = "바꿔버림";
        //    await blogPostService.EditBlogPost(blogPost);
        //}
    }
}
