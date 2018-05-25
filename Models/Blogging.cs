using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace aspnetcoreapp.Models
{
    public class BloggingContext:DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options){}

        public DbSet<Blog> Blogs{get;set;}
        public DbSet<Post> Posts{get;set;}
    }

    public class Blog
    {
        public Guid Id {get;set;}
        public string Url {get;set;}
        public List<Post> Posts {get;set;}
    }

    public class Post
    {
        public Guid Id {get;set;}

        [Required]
        [MaxLength(512)]
        public string Title {get; set;}
        public string Content {get;set;}

        [ForeignKey("Blog")]
        public Guid BlogId {get;set;}
    }
}
