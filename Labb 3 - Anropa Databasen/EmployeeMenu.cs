using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_3___Anropa_Databasen
{
    class EmployeeMenu : Menu
    {
        EmployeeListMenu empListMenu;
        public EmployeeMenu()
        {
            menuSections.AddRange(new List<string>() { "VISA PERSONAL", "", "[ ] Visa Samtliga", "[ ] Visa Särskild Kategori" });
            empListMenu = new EmployeeListMenu();
        }

        public override void RunFunction(int selection)
        {
            Console.Clear();        
            switch (selection)
            {
                case 2:
                    ShowAllEmployees();
                    break;
                case 3:
                    MenuInteraction.RunMenu(empListMenu);
                    break;
                default:
                    break;
            }          
        }
        public void ShowAllEmployees()
        {
            var employees = from emp in MenuInteraction.Context.Employee
                            join jobs in MenuInteraction.Context.Job on emp.JobId equals jobs.Id
                            orderby emp.JobId
                            select new { JobId = emp.JobId, JobTitle = jobs.JobTitle, FName = emp.Fname, LName = emp.Lname, persId = emp.PersonalId };

            MenuInteraction.Headline("VISA SAMTLIGA ANSTÄLLDA");

            int titleCounter = 0;
            foreach (var item in employees)
            {
                if (titleCounter < item.JobId)
                {
                    titleCounter++;
                    MenuInteraction.PrintCyan($"\n{item.JobTitle}{new string(' ', 13 - item.JobTitle.Length)} - {MenuInteraction.Context.Employee.Where(e => e.JobId == titleCounter).Count()} st Anställda");
                }
                string space = new string(' ', (16 - ((item.FName.Length) + (item.LName.Length))));
                Console.WriteLine($"Personnr: {item.persId} | Namn: {item.FName} {item.LName} {space}");
            }

            Escape();
        }
    }
}
