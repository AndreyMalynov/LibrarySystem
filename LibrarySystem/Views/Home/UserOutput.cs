using System;
using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Views.Home
{
    class UserOutput
    {
        public static void Users(IEnumerable<User> users)
        {
            Console.Clear();
            Console.WriteLine("Список пользователей\n");

            foreach (User user in users)
            {
                Console.WriteLine("Имя: {0}", user.Name);
                Console.WriteLine("Паспорт: {0} \n", user.Pasport);
                Console.WriteLine("-----------------------------------");
            }

            Console.WriteLine("Для продолжения нажмите любую клавишу..");
            Console.ReadKey();
        }

    }
}
