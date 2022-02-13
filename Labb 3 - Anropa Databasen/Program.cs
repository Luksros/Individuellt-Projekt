using System;
using Labb_3___Anropa_Databasen.Models;

namespace Labb_3___Anropa_Databasen
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuInteraction.Intro();
            MainMenu mainMenu = new MainMenu();
            MenuInteraction.RunMenu(mainMenu);
        }
    }
}
