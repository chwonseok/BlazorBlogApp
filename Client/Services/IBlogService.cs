using BlazorBlogApp.Shared;

namespace BlazorBlogApp.Client.Services
{
    public interface IBlogService
    {
        List<BlogPost> GetBlogPosts(); // 모든 블로그포스트 가져옴
        BlogPost GetBlogPostByUrl(string url); // 하나의 블로그포스트를 url을 통해 가져옴
    }
}
