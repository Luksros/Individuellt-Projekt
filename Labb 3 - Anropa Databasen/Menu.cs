using System;
using System.Collections.Generic;
using System.Text;
using Labb_3___Anropa_Databasen.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Labb_3___Anropa_Databasen
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Menu
    {
        public List<string> menuSections;
        public Menu()
        {
            menuSections = new List<string>();
        }

        public abstract void RunFunction(int selection);
        public void Escape()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nTryck Esc för att återvända");
            Console.ResetColor();
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(intercept: true).Key;
            } while (key != ConsoleKey.Escape);
        }
    }
}
