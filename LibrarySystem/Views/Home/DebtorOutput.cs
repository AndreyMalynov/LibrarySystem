using System;
using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Views.Home
{
    class DebtorOutput
    {
        public static void Debtors(IEnumerable<User> users)
        {
            Console.Clear();
            Console.WriteLine("Список пользователей с задолжностями\n");

            foreach (User user in users)
            {
                Console.WriteLine("Имя: {0}", user.Name);
                Console.WriteLine("Паспорт: {0} \n", user.Pasport);
            }

            Console.WriteLine("Для продолжения нажмите любую клавишу..");
            Console.ReadKey();
        }
    }
}
