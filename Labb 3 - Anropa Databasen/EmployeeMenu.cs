using System;
using System.Collections.Generic;
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
                    var employees = MenuInteraction.Context.Employee;
                    List<string> jobStrings = new List<string>();
                    foreach (var item in MenuInteraction.Context.Job)
                    {
                        jobStrings.Add(item.JobTitle);
                    }

                    MenuInteraction.Headline("VISA SAMTLIGA ANSTÄLLDA\n");

                    foreach (var item in employees)
                    {
                        string space = new string(' ', (16 - ((item.Fname.Length) + (item.Lname.Length))));
                        Console.WriteLine($"Personnr: {item.PersonalId} | Namn: {item.Fname} {item.Lname} {space} | Arbetsroll: {jobStrings[item.JobId - 1]}");
                    }

                    Escape();
                    break;
                case 3:
                    MenuInteraction.RunMenu(empListMenu);
                    break;
                default:
                    break;
            }          
        }
    }
}
