using System;

namespace LibrarySystem.Views
{
    public static class SystemView
    {
        public static void Error(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("Для продолжения нажмите любую клавишу..");
            Console.ReadKey();
        }

        public static void Success(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("Для продолжения нажмите любую клавишу..");
            Console.ReadKey();
        }
    }
}
