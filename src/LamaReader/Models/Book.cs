using System;
using System.Collections.Generic;

namespace LamaReader.Models
{
    public partial class Book
    {
        public Book()
        {
            ReadingProgresses = new HashSet<ReadingProgress>();
        }

        public int Id { get; set; }
        public string UrlToFile { get; set; } = null!;
        public int PublisherId { get; set; }
        public byte[]? TitularPhoto { get; set; }
        public string Author { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string? Description { get; set; }
        public double Rating { get; set; }
        public int? PagesNumber { get; set; }
        public int Status { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User1 Publisher { get; set; } = null!;
        public virtual ICollection<ReadingProgress> ReadingProgresses { get; set; }
    }
}
