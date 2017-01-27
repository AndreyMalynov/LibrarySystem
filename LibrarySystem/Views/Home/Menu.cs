using System;

namespace LibrarySystem.Views.Home
{
    public class Menu
    {
        public static string HomeMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите операцию");
            Console.WriteLine("1 - Вывод списка имеющихся книг");
            Console.WriteLine("2 - Вывод списка пользователей");
            Console.WriteLine("3 - Выдача книг пользователю, учитывая бизнес правила");
            Console.WriteLine("4 - Прием книг от пользователя");
            Console.WriteLine("5 - Вывод списка пользователей с просроченными книгами");
            Console.WriteLine("6 - Выход");
            Console.WriteLine("Подтвердите клавишей Enter");
            return Console.ReadLine();
        }
    }
}
