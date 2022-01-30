using Labb_3___Anropa_Databasen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_3___Anropa_Databasen
{
   public static class MenuInteraction
    {
        public static SchoolDbContext Context;
        static MenuInteraction()
        {
            Context = new SchoolDbContext();
        }
        public static void RunMenu(Menu thisMenu)
        {
            bool escape = false;
            int rowSelection = 2;
            while (!escape)
            {
                Console.Clear();
                for (int i = 0; i < thisMenu.menuSections.Count; i++)
                {
                    if (i == 0)
                    {
                        Headline(thisMenu.menuSections[i]);
                    }
                    else
                    {
                        Console.WriteLine(thisMenu.menuSections[i]);
                    }
                }
                Console.SetCursorPosition(1, rowSelection);
                Console.Write("*");
                Console.SetCursorPosition(1, rowSelection);
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(intercept: true);
                } while (key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);

                if (key.Key == ConsoleKey.UpArrow && rowSelection > 2)
                {
                    rowSelection--;
                }
                else if (key.Key == ConsoleKey.DownArrow && rowSelection < thisMenu.menuSections.Count - 1)
                {
                    rowSelection++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    thisMenu.RunFunction(rowSelection);
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    escape = true;
                }
            }
        }
        public static void Headline(string input)
        {
            Console.SetCursorPosition(((Console.WindowWidth - input.Length) / 2), 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(input);
            Console.ResetColor();
        }
    }
}
