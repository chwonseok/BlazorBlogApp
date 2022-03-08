using Microsoft.Azure.Cosmos;
using BlazorBlogApp.Server.Services.Foundation;
using BlazorBlogApp.Shared;

namespace BlazorBlogApp.Server.Practice.BlazorBlogPost.Services
{
    public class BlogPostService
    {
        private readonly CosmosDbService cosmosDbService;
        private readonly Container container;

        public BlogPostService(CosmosDbService cosmosDbService)
        {
            this.cosmosDbService = cosmosDbService;
            container = cosmosDbService.GetContainer();
        }

        public async Task CreateNewBlogPost(BlogPost post)
        {
            post.Id = Guid.NewGuid().ToString();
            await container.AddModel<BlogPost>(post);
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            return await container.GetModelLinqQueryable<BlogPost>().GetListFromFeedIteratorAsync();
        }

        //public async Task EditBlogPost(BlogPost blogPost)
        //{
        //    await container.EditModel<BlogPost>(blogPost);
        //}
    }
}
