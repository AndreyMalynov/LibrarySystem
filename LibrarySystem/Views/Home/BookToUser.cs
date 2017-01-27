using System;

namespace LibrarySystem.Views.Home
{
    class BookToUser
    {
        public static string SelectUser()
        {
            Console.Clear();
            Console.WriteLine("Введите паспортные данные пользователя (10 цифр)");
            return Console.ReadLine();
        }

        public static string SelectBook()
        {
            Console.Clear();
            Console.WriteLine("Введите название книги и автора через запятую");
            return Console.ReadLine();
        }

        public static void UserNotFound()
        {
            Console.Clear();
            Console.WriteLine("Пользователь не найден");
            Console.WriteLine("Для продолжения нажмите любую клавишу..");
            Console.ReadKey();
        }

        public static void BookNotFound()
        {
            Console.Clear();
            Console.WriteLine("Книга не найдена");
            Console.WriteLine("Для продолжения нажмите любую клавишу..");
            Console.ReadKey();
        }

        public static void UserFound()
        {
            Console.Clear();
            Console.WriteLine("Пользователь найден");
            Console.WriteLine("Для продолжения нажмите любую клавишу..");
            Console.ReadKey();
        }

        public static void BookFound()
        {
            Console.Clear();
            Console.WriteLine("Книга найдена");
            Console.WriteLine("Для продолжения нажмите любую клавишу..");
            Console.ReadKey();
        }

        public static void MaxCountOfBook()
        {
            Console.Clear();
            Console.WriteLine("Достигнуто максимальное число книг.\nВыдача будет доступна после сдачи");
            Console.WriteLine("Для продолжения нажмите любую клавишу..");
            Console.ReadKey();
        }

        public static void Success(string userName, string bookName)
        {
            Console.Clear();
            Console.WriteLine("{0} получил книгу {1}", userName, bookName);
            Console.WriteLine("Для продолжения нажмите любую клавишу..");
            Console.ReadKey();
        }

    }
}
