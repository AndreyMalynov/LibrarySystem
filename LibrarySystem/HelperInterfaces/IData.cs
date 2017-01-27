using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;

namespace LibrarySystem.HelperInterfaces
{
    interface IData
    {
        string Name { get; }

        List<Book> Books { get; set; }
        List<User> Users { get; set; }

        void OpenOrCreateBooks();
        void OpenOrCreateUsers();

        void SaveUsersChanges();
        void SaveBooksChanges();
    }
}
