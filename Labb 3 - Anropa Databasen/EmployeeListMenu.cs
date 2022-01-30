using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Labb_3___Anropa_Databasen
{
    class EmployeeListMenu : Menu
    {
        public EmployeeListMenu()
        {
            menuSections.AddRange(new List<string>() { "VISA SÄRSKILD PERSONAL", "", "[ ] Rektor", "[ ] Vaktmästare", "[ ] Lärare", "[ ] Administratör" });
        }
        public override void RunFunction(int selection)
        {
            var employees = MenuInteraction.Context.Employee.Where(e => e.JobId == selection - 1);
            var jobs = MenuInteraction.Context.Job;

            Console.Clear();
            MenuInteraction.Headline(menuSections[selection][4..].ToUpper() + "\n");

            foreach (var item in employees)
            {
                Console.WriteLine($"Personnr: {item.PersonalId} | Namn: {item.Fname} {item.Lname}");
            }
            Escape();
        }
    }
}
