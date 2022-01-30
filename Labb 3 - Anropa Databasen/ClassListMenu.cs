using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Labb_3___Anropa_Databasen
{
    class ClassListMenu : Menu
    {
        public ClassListMenu()
        {
            menuSections.AddRange(new List<string>() { "VISA SÄRSKILD KLASS", "", "[ ] Visa Klass19", "[ ] Visa Klass20" });

        }
        public override void RunFunction(int selection)
        {
            var students = MenuInteraction.Context.Student.Where(e => e.ClassId == selection - 1);
            List<string> classTitles = new List<string>();
            foreach (var item in MenuInteraction.Context.Class)
            {
                classTitles.Add(item.ClassName);
            }

            Console.Clear();
            MenuInteraction.Headline(classTitles[selection - 2] + "\n");

            foreach (var item in students)
            {
                Console.WriteLine($"Personnr: {item.PersonalId} | Namn: {item.Fname} {item.Lname}");
            }
            Escape();
        }
    }
}
