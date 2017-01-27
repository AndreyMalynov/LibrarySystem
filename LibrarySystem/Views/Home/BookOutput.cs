using System;
using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Views.Home
{
    class BookOutput
    {

        public static void Books(IEnumerable<Book> books)
        {
            Console.Clear();
            Console.WriteLine("Список имеющихся книг\n");

            foreach (Book book in books)
            {
                if (book.LastDate != null)
                    Console.WriteLine("В данный момент находится у пользователя");
                Console.WriteLine("Название: {0}", book.Name);
                Console.WriteLine("Автор: {0} \n", book.Autor);
                Console.WriteLine("--------------------------------------------");
            }

            Console.WriteLine("Для продолжения нажмите любую клавишу..");
            Console.ReadKey();
        }
    }
}
