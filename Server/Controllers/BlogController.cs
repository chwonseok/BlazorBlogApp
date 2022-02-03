using BlazorBlogApp.Server.Data;
using BlazorBlogApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBlogApp.Server.Controllers
{
    [Route("api/[controller]")] // 여길 통해 어떤 url로 이 컨트롤러에 액세스할 수 있는지 알 수 있음
    [ApiController]
    public class BlogController : ControllerBase
    {
        public readonly DataContext _context;
        // contructor to use data from our SQLite DB
        public BlogController(DataContext context)
        {
            _context = context;
        }

        // ActionResult를 통해 특정 action을 리턴할 수 있음
        // 여기는 서버에서 다루는 "모든 Posts"를 리턴하는 곳
        [HttpGet]
        public ActionResult<List<BlogPost>> GetAllBlogPosts()
        {
            return Ok(_context.BlogPosts); // response로 Posts를 리턴함 (status code 200 경우)
        }

        [HttpGet]
        [Route("{url}")] // == [HttpGet("{url}")]
        // 여기는 "하나의 Post"만 리턴하는 곳
        public ActionResult<BlogPost> GetSinglePost(string url)
        {
            // 조건에 만족하는 첫번째 요소(post)나 default값을 리턴하거나, null일 경우 404 not found 리턴
            var post = _context.BlogPosts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            if (post == null) return NotFound("This post does not exist");

            return Ok(post);
        }
    }
}
