using System;
using System.Collections.Generic;

namespace LamaReader.Models
{
    public partial class Bookmark
    {
        public int Id { get; set; }
        public int ReadingProgressId { get; set; }
        public string? Note { get; set; }
        public int PageNumber { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ReadingProgress ReadingProgress { get; set; } = null!;
    }
}
