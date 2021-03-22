﻿using Microsoft.EntityFrameworkCore;
using NewsWebsiteAPI.DataAccess.Context.Generic;
using NewsWebsiteAPI.Infrastructure.Models.Entities;

namespace NewsWebsiteAPI.DataAccess.Context
{
    public class PostContext : BaseContext, IPostContext
    {
        public DbSet<Post> Posts { get; set; }

        public PostContext(DbContextOptions<PostContext> options) : base(options)
        {
        }
    }
}