using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Persistence.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser,AppRole,string>(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<ContactInfo>  ContactInfos { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Social> Socials { get; set; }
}