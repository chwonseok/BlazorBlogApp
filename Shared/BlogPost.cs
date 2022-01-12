﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlogApp.Shared
{
    public class BlogPost
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }
        
        public string Author { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.Now;

        public bool IsPublised { get; set; } = true;

        public bool IsDeleted { get; set; } = false;
    }
}
