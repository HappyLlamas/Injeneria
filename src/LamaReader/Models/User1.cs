using System;
using System.Collections.Generic;

namespace LamaReader.Models
{
    public partial class User1
    {
        public User1()
        {
            Books = new HashSet<Book>();
            ReadingProgresses = new HashSet<ReadingProgress>();
        }

        public User1(int id, string username, string email, string passwordHash)
        {
            Id = id;
            Username = username;
            Email = email;
            Passwordhash = passwordHash;
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Passwordhash { get; set; } = null!;
        public int Role { get; set; }
        public string Username { get; set; } = null!;
        public byte[]? Avatar { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<ReadingProgress> ReadingProgresses { get; set; }
    }
}
