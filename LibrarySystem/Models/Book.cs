using System;

namespace LibrarySystem.Models
{
    public class Book
    {
        public Book()
        {

        }

        public string Name { get; set; }
        public string Autor { get; set; }
        public DateTime? LastDate { get; set; }
    }
}
