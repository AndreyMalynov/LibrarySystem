using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Views.Home
{
    class SelectSource
    {
        public static string SelectSourceOfData()
        {
            Console.Clear();
            Console.WriteLine("Выберите источник данных");
            Console.WriteLine("1 - XML");
            Console.WriteLine("2 - Cloud");
            Console.WriteLine("3 - DataBase");
            return Console.ReadLine();
        }
    }
}
