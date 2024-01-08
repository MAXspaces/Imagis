using Imagist_Library.Model;
using Microsoft.EntityFrameworkCore;

namespace Imagist_Backend.Data;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Photo> Photos { get; set; }
}