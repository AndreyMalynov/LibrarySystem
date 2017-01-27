using System;

namespace LibrarySystem.Views
{
    public static class AdminView
    {
        public static string Menu()
        {
            Console.Clear();
            Console.WriteLine("Выберите операцию");
            Console.WriteLine("1 - Добавить пользователя");
            Console.WriteLine("2 - Дабавить книгу");
            Console.WriteLine("3 - Отмена");
            Console.WriteLine("Подтвердите клавишей Enter");
            return Console.ReadLine();
        }

        public static string SelectSourceOfData()
        {
            Console.Clear();
            Console.WriteLine("Выберите источник данных");
            Console.WriteLine("1 - XML");
            Console.WriteLine("2 - Cloud");
            Console.WriteLine("3 - DataBase");
            return Console.ReadLine();
        }

        public static string AddUser()
        {
            Console.Clear();
            Console.WriteLine("Добавление пользователя");
            Console.WriteLine("Введите через запятую:");
            Console.WriteLine("Имя (ФИО через пробел)");
            Console.WriteLine("Паспортные данные (10 цифр)");
            Console.WriteLine("Подтвердите клавишей Enter");
            Console.WriteLine("Для возвращения назад введите Cancel");
            return Console.ReadLine();
        }

        public static string AddBook()
        {
            Console.Clear();
            Console.WriteLine("Добавление книги");
            Console.WriteLine("Введите через запятую:");
            Console.WriteLine("Название");
            Console.WriteLine("Автор (ФИО через пробел)");
            Console.WriteLine("Подтвердите клавишей Enter");
            Console.WriteLine("Для возвращения назад введите Cancel");
            return Console.ReadLine();
        }
    }
}
