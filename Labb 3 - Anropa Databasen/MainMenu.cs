using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_3___Anropa_Databasen
{
    class MainMenu : Menu
    {
        EmployeeMenu empMenu;
        StudentMenu stuMenu;
        GradeMenu graMenu;
        AddEmpMenu addEmpMenu;
        public MainMenu()
        {
            menuSections.AddRange(new List<string>() { "HUVUDMENY", "", "[ ] Visa Personal", "[ ] Visa Elever", "[ ] Visa Betyg", "[ ] Visa Aktiva Kurser", "[ ] Lägg Till Personal" });
            empMenu = new EmployeeMenu();
            stuMenu = new StudentMenu();
            graMenu = new GradeMenu();
            addEmpMenu = new AddEmpMenu();
        }

        public override void RunFunction(int selection)
        {
            Console.Clear();
            switch (selection)
            {
                case 2:
                    MenuInteraction.RunMenu(empMenu);
                    break;
                case 3:
                    MenuInteraction.RunMenu(stuMenu);
                    break;
                case 4:
                    MenuInteraction.RunMenu(graMenu);
                    break;
                case 5:
                    ActiveCourses();
                    break;
                case 6:
                    MenuInteraction.RunMenu(addEmpMenu);
                    break;
                default:
                    break;
            }
        }
        public void ActiveCourses()
        {
            Console.Clear();
            MenuInteraction.Headline("AKTIVA KURSER\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Dagens datum: {DateTime.Now.ToShortDateString()}\n");

            var actCour = from actCourse in MenuInteraction.Context.ActiveCourses
                          join course in MenuInteraction.Context.Course on actCourse.CourseId equals course.Id
                          join classes in MenuInteraction.Context.Class on actCourse.ClassId equals classes.Id
                          where actCourse.StartDate < DateTime.Now && actCourse.EndDate > DateTime.Now
                          orderby actCourse.ClassId
                          select new { SDate = actCourse.StartDate, EDate = actCourse.EndDate, CourName = course.CourseName, ClName = classes.ClassName};

            foreach (var item in actCour)
            {
                MenuInteraction.PrintCyan("Klass:     Kurs:      Startdatum:     Slutdatum:");
                Console.WriteLine($"{item.ClName} {new string(' ', 10 - item.ClName.Length)}{item.CourName} {new string(' ', 9 - item.CourName.Length)} {item.SDate.ToShortDateString()}      {item.EDate.ToShortDateString()}\n");
                
            }

            Escape();
        }
    }
}
