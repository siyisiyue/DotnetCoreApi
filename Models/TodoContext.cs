﻿using Microsoft.EntityFrameworkCore;
namespace DotnetCoreApi.Models
{
    public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
           : base(options)
        {
        }
        public DbSet<TodoItems> TodoItems { get; set; }
    }
}