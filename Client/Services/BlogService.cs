using System.Linq;
using System.Collections.Generic;
using BlazorBlogApp.Shared;

// 여기는 implementation class임
namespace BlazorBlogApp.Client.Services
{
    public class BlogService : IBlogService
    {
        public List<BlogPost> Posts { get; set; } = new List<BlogPost>
        {
            new BlogPost { Url = "new-tutorial", Title = "It's tutorial for Blazor", Description = "This is tutorial showing you how to build a blog with Blazor", Content = "simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."},
            new BlogPost { Url = "first-post", Title = "My first ever blog post", Description = "Hey it's my blog app with Blazor!", Content = "It's short blog post which is beeeeautiful"}
        };

        public BlogPost GetBlogPostByUrl(string url)
        {
            return Posts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
        }

        public List<BlogPost> GetBlogPosts()
        {
            return Posts;
        }
    }
}
