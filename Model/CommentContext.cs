using CommentSection;
using Microsoft.EntityFrameworkCore;
using CommentSectionWeb;
using System;

namespace CommentSectionWeb.Model
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options) 
            : base(options)

        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONN_STRING"));
        }

        public DbSet<Comment> Comments { get; set; }

        // another DbSet<Owner> Owners { get; set; }
    }
}
