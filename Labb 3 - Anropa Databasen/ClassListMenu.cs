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

            var students = from stud in MenuInteraction.Context.Student.Where(e => e.ClassId == selection - 1)
                           join classes in MenuInteraction.Context.Class on stud.ClassId equals classes.Id
                           select new { clName = classes.ClassName, persId = stud.PersonalId, FName = stud.Fname, LName = stud.Lname };

            Console.Clear();
            MenuInteraction.Headline(menuSections[selection][4..].ToUpper() + "\n");

            foreach (var item in students)
            {
                Console.WriteLine($"Personnr: {item.persId} | Namn: {item.FName} {item.LName}");
            }

            Escape();
        }
    }
}
