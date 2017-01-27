using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Views.Home
{
    /// <summary>  
    /// Представление возврата книги от пользователя 
    /// </summary>  
    class BookFromUser
    {

        /// <summary>  
        /// Представление запрашивает паспортные данные пользователя.
        /// Возвращает паспортные данные пользователя.
        /// </summary>  
        public static string SelectUser()
        {
            Console.Clear();
            Console.WriteLine("Введите паспортные данные пользователя (10 цифр)");
            return Console.ReadLine();
        }

        /// <summary>  
        /// Представление позволяет выбрать книгу на сдачу из тех, что в наличии у пользователя.
        /// Возвращает номер этой книги
        /// </summary>  
        public static string SelectBook(string userName, List<Models.Book> books)
        {
            Console.Clear();
            Console.WriteLine("Выберите номер книги которую собирается сдать {0}", userName);

            for (int i = 0; i < books.Count; i++)
            {
                    Console.WriteLine("{0} - {1}", i+1, books[i].Name);
            }

            return Console.ReadLine();
        }

        /// <summary>  
        /// Представление оповещает о том, что пользователь не найден
        /// </summary>  
        public static void UserNotFound()
        {
            Console.Clear();
            Console.WriteLine("Пользователь не найден");
            Console.WriteLine("Для продолжения нажмите любую клавишу..");
            Console.ReadKey();
        }

        /// <summary>  
        /// Представление оповещает об успехе
        /// </summary>
        public static void Success(string userName)
        {
            Console.Clear();
            Console.WriteLine("Пользователь {0} сдал книгу", userName);
            Console.WriteLine("Для продолжения нажмите любую клавишу..");
            Console.ReadKey();
        }
    }
}
