using System;
using System.Text.RegularExpressions;
using LibrarySystem.Views;
using LibrarySystem.Controllers;

namespace LibrarySystem
{
    class Program
    {
        static int Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите Режим");
                Console.WriteLine("1 - Администратор");
                Console.WriteLine("2 - Обычный");
                Console.WriteLine("3 - Выход");

                string strInput = Console.ReadLine();
                Regex regex = new Regex(@"\b[1-3]{1}\b");
                
                int caseSwitch = (regex.IsMatch(strInput)) ? int.Parse(strInput) : 4;

                switch (caseSwitch)
                {
                    case 1:
                        {
                            AdminController adminController = new AdminController();
                            adminController.SelectSource();
                        }
                        break;
                    case 2:
                        {
                            HomeController homeController = new HomeController();
                            homeController.SelectSource();
                        }
                        break;                  
                    case 3:
                        return 1;
                    default:
                        SystemView.Error("Некорректный ввод");
                        break;
                }
            }
        }
    }
}
