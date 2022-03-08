using BlazorBlogApp.Shared;

namespace BlazorBlogApp.Client.Services
{
    public interface IBlogService
    {
        Task<List<BlogPost>> GetBlogPosts();
        Task<BlogPost> GetBlogPostByUrl(string url);
        Task<BlogPost> CreateNewBlogPost(BlogPost request);
    }
}
