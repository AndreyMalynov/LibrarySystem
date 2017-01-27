using System;
using System.Linq;
using System.Text.RegularExpressions;
using LibrarySystem.Models;
using LibrarySystem.Views;
using LibrarySystem.HelperClasses;

namespace LibrarySystem.Controllers
{
    class AdminController
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
            string strInput = AdminView.SelectSourceOfData();

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


        public int Menu()
        {

            try
            {
                while (true)
                {
                    string strInput = AdminView.Menu();

                    Regex regex = new Regex(@"[1-3]{1}");
                    int caseSwitch = (regex.IsMatch(strInput)) ? int.Parse(strInput) : 4;
                    
                    switch (caseSwitch)
                    {
                        case 1:
                            AddUser();

                            break;
                        case 2:
                            AddBook();
                            break;
                        case 3:
                            return 1;                                         
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

        public int AddUser()
        {
            try
            {
                string strInput = AdminView.AddUser();

                if (strInput == "Cancel")
                    return 1;

                Regex regexName = new Regex(@"\b([a-z,A-Z,а-я,А-Я]{2,15}\s{1}[a-z,A-Z,а-я,А-Я]{2,15}\s{1}[a-z,A-Z,а-я,А-Я]{2,15})\b");
                Regex regexPasport = new Regex(@"(\d{10})");

                string name = strInput.Split(',').First().Trim();
                string pasport = strInput.Split(',').Last().Trim();

                if (regexName.IsMatch(name) && regexPasport.IsMatch(pasport))
                {
                    if (Data.Users != null)
                    {
                        if (Data.Users.Exists(x => x.Pasport == pasport))
                        {
                            SystemView.Error("Пользователь существует");
                            AddUser();
                            return 1;
                        }
                    }

                    Data.Users.Add(new User { Name = name, Pasport = pasport });
                        Data.SaveUsersChanges();
                        SystemView.Success("Пользователь добавлен");
                        return 1;
                }

                else
                {
                    SystemView.Error("Некорректный ввод");
                    AddUser();
                    return 1;                
                }
            }

            catch
            {
                SystemView.Error("Неизвестная ошибка, мы уже работаем");
                return 0;
            }
        }

        public int AddBook()
        {
            try
            {
                string strInput = AdminView.AddBook();

                if (strInput == "Cancel")
                    return 1;

                Regex regexName = new Regex(@"\b(\w{1,30})\b");
                Regex regexAutor = new Regex(@"\b(\w{2,15}\s{1}\w{2,15}\s{1}\w{2,15})\b");

                string name = strInput.Split(',').First().Trim();
                string autor = strInput.Split(',').Last().Trim();

                if (regexName.IsMatch(name) && regexAutor.IsMatch(autor))
                {
                        Data.Books.Add(new Book { Name = name, Autor = autor, LastDate = null  });
                        Data.SaveBooksChanges();
                        SystemView.Success("Книга добавлена");
                        return 1;                  
               }
                else
                {
                    SystemView.Error("Некорректный ввод");
                    AddBook();
                    return 1;
                }
            }

            catch 
            {
                SystemView.Error("Неизвестная ошибка, мы уже работаем");
                return 0;
            }
        }
    }
}
