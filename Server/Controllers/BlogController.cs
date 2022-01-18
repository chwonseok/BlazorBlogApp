using BlazorBlogApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBlogApp.Server.Controllers
{
    [Route("api/[controller]")] // 이를 알아야 어떤 url로 이 컨트롤러에 액세스할 수 있는지 알 수 있음
    [ApiController]
    public class BlogController : ControllerBase
    {
        public List<BlogPost> Posts { get; set; } = new List<BlogPost>
        {
            new BlogPost { Url = "new-tutorial", Title = "It's tutorial for Blazor 에이피아이", Description = "This is tutorial showing you how to build a blog with Blazor", Content = "simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."},
            new BlogPost { Url = "first-post", Title = "My first ever blog post 에이피아이", Description = "Hey it's my blog app with Blazor!", Content = "It's short blog post which is beeeeautiful"}
        };

        // ActionResult를 통해 특정 action을 리턴할 수 있음
        // 여기는 서버에서 다루는 모든 Posts를 리턴하는 곳
        [HttpGet]
        public ActionResult<List<BlogPost>> GetAllBlogPosts()
        {
            return Ok(Posts); // response로 Posts를 리턴함 (status code 200)
        }


        [HttpGet]
        [Route("{url}")] // == [HttpGet("{url}")]
        // 여기는 하나의 Post만 리턴하는 곳
        public ActionResult<BlogPost> GetSinglePost(string url)
        {
            // 조건에 만족하는 첫번째 요소(post)나 default값을 리턴하거나, null일 경우 404 not found 리턴
            var post = Posts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            if (post == null) return NotFound("This post does not exist");

            return Ok(post);
        }
    }
}
