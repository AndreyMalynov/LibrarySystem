using System;
using System.Collections.Generic;
using LibrarySystem.HelperInterfaces;
using System.IO;
using System.Xml.Serialization;
using LibrarySystem.Models;


namespace LibrarySystem.HelperClasses
{
    class DbSource : IData
    {
        XmlSerializer formatterUsers;
        XmlSerializer formatterBooks;

        public DbSource(string name)
        {
            Name = name;
            formatterUsers = new XmlSerializer(typeof(List<User>));
            formatterBooks = new XmlSerializer(typeof(List<Book>));
            OpenOrCreateBooks();
            OpenOrCreateUsers();
        }

        public string Name { get; private set; }


        public List<User> Users { get; set; }


        public List<Book> Books { get; set; }


        public void OpenOrCreateBooks()
        {
            try
            {

                //выбросит исключение если файл еще не создан
                try
                {
                    using (FileStream fs = new FileStream(("../../AppData/BooksFromDb.xml"), FileMode.OpenOrCreate))
                    {
                        Books = (List<Book>)formatterBooks.Deserialize(fs);
                    }
                }

                //сработет в случае если файла еще не существует. создаст его
                catch
                {
                    Books = new List<Book>();
                    using (FileStream fs = new FileStream(("../../AppData/BooksFromDb.xml"), FileMode.OpenOrCreate))
                    {
                        formatterBooks.Serialize(fs, Books);
                    }
                }
            }
            catch
            {
                new Exception("Неизвестная ошибка, мы уже работаем");
            }

        }


        public void OpenOrCreateUsers()
        {
            try
            {
                //выбросит исключение если файл еще не создан
                try
                {

                    using (FileStream fs = new FileStream(("../../AppData/Users.xml"), FileMode.Open))
                    {
                        Users = (List<User>)formatterUsers.Deserialize(fs);
                    }
                }

                //сработет в случае если файла еще не существует. создаст его
                catch
                {
                    Users = new List<User>();
                    using (FileStream fs = new FileStream(("../../AppData/Users.xml"), FileMode.OpenOrCreate))
                    {
                        formatterUsers.Serialize(fs, Users);
                    }
                }
            }
            catch
            {
                new Exception("Неизвестная ошибка, мы уже работаем");
            }
        }


        public void SaveUsersChanges()
        {
            try
            {
                using (FileStream fs = new FileStream(("../../AppData/Users.xml"), FileMode.Create))
                {
                    formatterUsers.Serialize(fs, Users);
                }
            }
            catch
            {
                new Exception("Неизвестная ошибка, мы уже работаем");
            }

        }


        public void SaveBooksChanges()
        {
            try
            {
                using (FileStream fs = new FileStream(("../../AppData/BooksFromDb.xml"), FileMode.Create))
                {
                    formatterBooks.Serialize(fs, Books);
                }
            }
            catch { new Exception("Неизвестная ошибка, мы уже работаем"); }
        }
    }
}
