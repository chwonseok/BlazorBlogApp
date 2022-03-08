using BlazorBlogApp.Shared.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace BlazorBlogApp.Shared
{
    public class BlogPost : CosmosModelBase
    {
        // public int Id { get; set; }
        [Required, StringLength(10, ErrorMessage = "Plese use only 10 characters")]
        public string? Url { get; set; } = string.Empty;

        [Required]
        public string? Title { get; set; } = string.Empty;

        public string? Content { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public string? Author { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsPublised { get; set; } = true;

        public override string ClassType => "BlogPost";
    }
}
