using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using LibrarySystem.HelperInterfaces;


namespace LibrarySystem.Models
{
    class ContextLibrary
    {
        public IData DataSource { get; set; }

        public string Name { get { return DataSource.Name; } }
        
        public List<User> Users { get { return DataSource.Users; } }
        public List<Book> Books { get { return DataSource.Books; } }

        public ContextLibrary(IData datasource)
        {
            DataSource = datasource;
        }

        public void OpenOrCreateBooks()
        {
            DataSource.OpenOrCreateBooks();
        }

        public void OpenOrCreateUsers()
        {
            DataSource.OpenOrCreateUsers();
        }


        public void SaveUsersChanges()
        {
            DataSource.SaveUsersChanges();
        }

        public void SaveBooksChanges()
        {
            DataSource.SaveBooksChanges();
            
        }
    }
}
