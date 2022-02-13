using Labb_3___Anropa_Databasen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_3___Anropa_Databasen
{
    public static class MenuInteraction
    {
        public static SchoolDbContext Context;
        static MenuInteraction()
        {
            Context = new SchoolDbContext();
            Console.SetWindowSize(77, 23);
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
        public static void RunStuInfoMenu(StudentInfoMenu thisMenu)
        {
            bool escape = false;
            int rowSelection = 0;
            List<Student> AllStudents = new List<Student>();
            List<Grade> gradeNames = new List<Grade>();
            List<Course> courses = new List<Course>();
            List<Class> Classes = new List<Class>();
            List<StudentsInCourses> stuCourse = new List<StudentsInCourses>();
            foreach (var item in Context.Student.OrderBy(v => v.ClassId)) { AllStudents.Add(item); }
            foreach (var item in Context.Class) { Classes.Add(item); }
            foreach (var item in MenuInteraction.Context.Grade) { gradeNames.Add(item); }
            foreach (var item in MenuInteraction.Context.Course) { courses.Add(item); }
            foreach (var item in MenuInteraction.Context.StudentsInCourses) { stuCourse.Add(item); }

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
                        PrintCyan(thisMenu.menuSections[i]);
                    }
                }
                Console.WriteLine($"Personnummer: {AllStudents[rowSelection].PersonalId}\n" +
                                  $"Namn:         {AllStudents[rowSelection].Fname} {AllStudents[rowSelection].Lname}\n" +
                                  $"Klass:        {Classes[AllStudents[rowSelection].ClassId - 1].ClassName}\n");
                Console.Write("Kurser:       ");

                int studentId = AllStudents[rowSelection].Id;
                foreach (var item in Context.StudentsInCourses.Where(s => s.StudentId == studentId).OrderBy(c => c.CourseId))
                {
                    Console.Write($"{new String(' ', 14 - Console.CursorLeft)}{courses[item.CourseId - 1].CourseName}{new string(' ', 9 - courses[item.CourseId - 1].CourseName.Length)}- Betyg: ");
                    Console.WriteLine((item.GradeId != null) ? $"{ gradeNames[(item.GradeId ?? default) - 1].Grade1}" : "Pågående kurs.");
                }
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(intercept: true);
                } while (key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);

                if (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.UpArrow && rowSelection > 0)
                    {
                        rowSelection--;
                    }
                    else if (key.Key == ConsoleKey.DownArrow && rowSelection < AllStudents.Count - 1)
                    {
                        rowSelection++;
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    rowSelection = thisMenu.SearchStudent(rowSelection);
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
        public static void PrintCyan(string input)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        public static string PersNumInput()
        {
            StringBuilder personnum = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(36 + i, 2);
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key != ConsoleKey.Escape)
                {
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        i--;
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        return personnum.ToString();
                    }
                    {
                        personnum.Insert(i, key.KeyChar);
                    }
                }
                else
                {
                    return "ESC";
                }
            }
            return personnum.ToString();
        }
        public static void Intro()
        {
            Headline("Välkommen till Skoldatabasen!\n");
            Console.WriteLine("Använd följande knappar för att navigera i menyerna:\n\n[↑]     - Gå upp ett steg i menyn\n[↓]     - Gå ned ett steg i menyn\n[ENTER] - Gör menyval\n[ESC]   - Backa tillbaka till föregående meny/stäng av");
            PrintCyan("\nTryck [ENTER] för att fortsätta till huvudmenyn.");
            Console.ReadLine();
        }
    }
    
}
