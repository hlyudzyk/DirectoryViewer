using DirectoryViewer.Models;
using Microsoft.EntityFrameworkCore;

namespace DirectoryViewer.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Data/directories.db").LogTo(Console.WriteLine, LogLevel.Information);
        }

        public DbSet<DirectoryModel> Directories { get; set; }


    }
}
 