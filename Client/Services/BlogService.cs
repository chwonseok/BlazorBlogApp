using System.Linq;
using System.Collections.Generic;
using BlazorBlogApp.Shared;
using System.Net.Http.Json;

// 여기는 implementation class임
namespace BlazorBlogApp.Client.Services
{
    public class BlogService : IBlogService
    {
        // constructor
        private readonly HttpClient _http;
        public BlogService(HttpClient http)
        {
            _http = http;
        }

        public HttpClient Http { get; }

        public async Task<BlogPost> GetBlogPostByUrl(string url)
        {
            var post = await _http.GetFromJsonAsync<BlogPost>($"api/blog/{url}");
            return post;
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            return await _http.GetFromJsonAsync<List<BlogPost>>("api/blog");
        }
    }
}

// 서버사이드로 목업데이터를 옮긴 후 HttpClient를 inject하기 위한 Constructor가 필요 (단축키: ctor탭탭)