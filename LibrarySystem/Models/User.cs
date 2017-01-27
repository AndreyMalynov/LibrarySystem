using System;
using System.Collections.Generic;


namespace LibrarySystem.Models
{
    public class User
    {
        public User()
        {
            Books = new List<Book>(3);
        }

        public string Name { get; set; }
        public string Pasport { get; set; }
        public List<Book> Books { get; set; }
    }
}
