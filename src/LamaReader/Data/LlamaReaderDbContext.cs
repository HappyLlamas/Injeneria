using LamaReader.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaReader.Data
{
    public class LlamaReaderDbContext : DbContext
    {

        public DbSet<User1> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<ReadingProgress> ReadingProgress { get; set; }

        public LlamaReaderDbContext(DbContextOptions<LlamaReaderDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ;
            base.OnConfiguring(optionsBuilder);
        }

    }
}
