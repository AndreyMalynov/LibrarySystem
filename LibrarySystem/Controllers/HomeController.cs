using System;
using System.Linq;
using System.Text.RegularExpressions;
using LibrarySystem.Models;
using LibrarySystem.Views;
using LibrarySystem.HelperClasses;
using LibrarySystem.HelperInterfaces;

namespace LibrarySystem.Controllers
{
    class HomeController
    {
        /// <summary>  
        /// Контекст данных. Содержит в себе данные о подключении. Методы взаимодействия с файлом
        /// </summary>  
        ContextLibrary Data;

        /// <summary>  
        /// Позволяет выбрать источник данных
        /// </summary>  
        public int SelectSource()
        {
            string strInput = Views.Home.SelectSource.SelectSourceOfData();

            Regex regex = new Regex(@"\b[1-3]{1}\b");

            int caseSwitch = (regex.IsMatch(strInput)) ? int.Parse(strInput) : 4;

            switch (caseSwitch)
            {
                case 1:
                    {
                        XmlSource xmlSource = new XmlSource("First");
                        Data = new ContextLibrary(xmlSource);
                        Menu();
                    }
                    break;
                case 2:
                    {
                        CloudSource cloudSource = new CloudSource("Second");
                        Data = new ContextLibrary(cloudSource);
                        Menu();
                    }
                    break;
                case 3:
                    {
                        DbSource dbSource = new DbSource("Third");
                        Data = new ContextLibrary(dbSource);
                        Menu();
                    }
                    break;
                default:
                    SystemView.Error("Некорректный ввод");
                    break;
            }
            return 1;
        }

        /// <summary>  
        /// Метод реализует меню
        /// </summary>  
        public int Menu()
        {

            try
            {
                while (true)
                {
                    
                    string strInput = Views.Home.Menu.HomeMenu();

                    Regex regex = new Regex(@"\b[1-6]{1}\b");

                    int caseSwitch = (regex.IsMatch(strInput)) ? int.Parse(strInput) : 7;

                    switch (caseSwitch)
                    {
                        case 1:
                            BookOutput();
                            break;
                        case 2:
                            UserOutput();
                            break;
                        case 3:
                            BookToUser();
                            break;
                        case 4:
                            BookFromUser();
                            break;
                        case 5:
                            DebtorOutput();
                            break;
                        case 6:
                            {
                                Data.SaveBooksChanges();
                                Data.SaveUsersChanges();
                                return 1;
                            }                          
                        default:
                            SystemView.Error("Некорректный ввод");
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                SystemView.Error(ex.Message);
                Menu();
                return 0;
            }
        }

        /// <summary>  
        /// Вывод всех книг
        /// </summary>  
        public int BookOutput()
        {
            Views.Home.BookOutput.Books(Data.Books);      
            return 1;
        }

        /// <summary>  
        /// Вывод всех пользователей
        /// </summary>  
        public int UserOutput()
        {
            Views.Home.UserOutput.Users(Data.Users);
            return 1;
        }

        public int BookToUser()
        {
            string userPasportData = Views.Home.BookToUser.SelectUser();
            User user = Data.Users.FirstOrDefault(x => x.Pasport == userPasportData);

            if(user == null)
            {
                Views.Home.BookToUser.UserNotFound();
                return 1;
            }

            if (user.Books.Count == 3)
            {
                Views.Home.BookToUser.MaxCountOfBook();
                return 1;
            }

            string bookNameAndAutor = Views.Home.BookToUser.SelectBook();
            Book book = Data.Books.FirstOrDefault(x => (x.LastDate == null) && (bookNameAndAutor == x.Name + ", " + x.Autor ));

            if(book == null)
            {
                Views.Home.BookToUser.BookNotFound();
                return 1;
            }

            book.LastDate = DateTime.Now.Date;
            user.Books.Add(book);

            Data.SaveBooksChanges();
            Data.SaveUsersChanges();

            Views.Home.BookToUser.Success(user.Name, book.Name);
            
            return 1;
        }

        public int BookFromUser()
        {
            string userPasportData = Views.Home.BookFromUser.SelectUser();
            User user = Data.Users.FirstOrDefault(x => x.Pasport == userPasportData);

            if (user == null)
            {
                Views.Home.BookToUser.UserNotFound();
                return 1;
            }

            string bookNumber = Views.Home.BookFromUser.SelectBook(user.Name, user.Books);

            Regex regex = new Regex(@"\b[1-3]{1}\b");

            if(regex.IsMatch(bookNumber) && (user.Books[int.Parse(bookNumber) - 1] != null))
            {
                Book book = user.Books[int.Parse(bookNumber) - 1];

                string bookName = book.Name;
                string bookAutor = book.Autor;

                user.Books.Remove(book);

                Data.Books.Find(x => (x.Name == bookName) && (x.Autor == bookAutor)).LastDate = null;

                Data.SaveBooksChanges();
                Data.SaveUsersChanges();

                Views.Home.BookFromUser.Success(user.Name);
            }

            else
            {
                SystemView.Error("Некорректный ввод");
                return 1;
            }

            return 1;
        }

        public int DebtorOutput()
        {          
            var debtors = Data.Users.Where(x => x.Books.Exists(y => y.LastDate.Value.AddMonths(1) < DateTime.Now.Date));
            Views.Home.DebtorOutput.Debtors(debtors);

            return 0;
        }
    }

}
