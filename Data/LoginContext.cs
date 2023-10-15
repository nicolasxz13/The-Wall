using The_Wall.Models;
using Microsoft.EntityFrameworkCore;

namespace The_Wall.Data
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages{get;set;}
        public DbSet<Comment> Comments{get;set;}
    }
}
