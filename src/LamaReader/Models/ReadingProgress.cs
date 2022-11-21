using System;
using System.Collections.Generic;

namespace LamaReader.Models
{
    public partial class ReadingProgress
    {
        public ReadingProgress()
        {
            Bookmarks = new HashSet<Bookmark>();
        }

        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string PathToFile { get; set; } = null!;
        public int LastPage { get; set; }
        public bool IsFavourite { get; set; }
        public int Theme { get; set; }
        public int FontSize { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual User1 User { get; set; } = null!;
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
    }
}
